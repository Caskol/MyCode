using FastColoredTextBoxNS;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.Text;
using System.Text.RegularExpressions;

namespace MyCode
{
    public partial class MainForm : Form
    {
        byte plagiatPercentSetting;
        uint maximumSymbolsSetting;

        readonly List<String> availableLanguages;
        public MainForm()
        {
            InitializeComponent();
            availableLanguages = new List<String>(Enum.GetNames(typeof(ProgrammingLanguages)));
            comboBoxLanguage.DataSource = availableLanguages;
            plagiatPercentSetting = Properties.Settings.Default.plagiatPercent;
            maximumSymbolsSetting = Properties.Settings.Default.maximumSymbols;
        }


        private void OpenFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (this.openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StreamReader streamReader = new StreamReader(openFileDialog.FileName); //�������� ����� ��� ������ �����
                    StringBuilder sb = new StringBuilder();
                    try //�������� �������� ������ �� �����
                    {
                        sb.Append(streamReader.ReadToEnd());
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("������ �������� ������ �����. �� ������� ��������� ������ �� �����.");
                        return;
                    }
                    DialogResult dialogResult = MessageBox.Show("���������� ���� �������� �����?", "���������� ���������", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        FCTBLeft.Text = sb.ToString();
                        StatusStripLabel.Text = "����� �����: " + FCTBLeft.LineInfos.Count;
                    }
                    else
                    {
                        FCTBRight.Text = sb.ToString();
                        StatusStripLabel.Text = "����� �����: " + FCTBRight.LineInfos.Count;
                    }
                }
            }
        }

        private void FCTBLeft_TextChanged(object sender, TextChangedEventArgs e)
        {
            StatusStripLabel.Text = "����� ����� � ����� ����: " + FCTBLeft.LinesCount;
            labelLeftCount.Text = "���������� ����� �����: " + FCTBLeft.LinesCount;
        }

        private void FCTBRight_TextChanged(object sender, TextChangedEventArgs e)
        {
            StatusStripLabel.Text = "����� ����� � ������ ����: " + FCTBRight.LinesCount;
            labelRightCount.Text = "���������� ����� ������: " + FCTBRight.LinesCount;
        }

        private void FCTBLeft_Click(object sender, EventArgs e)
        {
            StatusStripLabel.Text = "����� ����� � ����� ����: " + FCTBLeft.LinesCount;
        }

        private void FCTBRight_Click(object sender, EventArgs e)
        {
            StatusStripLabel.Text = "����� ����� � ������ ����: " + FCTBRight.LinesCount;
        }

        private void buttonCompare_Click(object sender, EventArgs e)
        {
            Tokenizer leftCode; //����������� ������ ����
            Shingle? leftCodeShingle = null;//������ �� ���� ������ ����
            List<string>? leftCodeTokenShingles = null; //������ ������� �� ������ ������� (� ����� ������ ���������� 4 ������ ��� ���������� ���������� ����������� �������)
            uint symbolsCount; //���������� �������� � ���������������� ������ ��� ������������� ������ � ���� ������
            string canonizedCode; //������ � ���������������� �����
            List<Tokenizer> codeCompare; //������� ������ �����, � ������� ����� ������������ �������� ��� (�.�. ���, ��� ������ � ����� ���� ���������)
            bool blockFromAddingInDatabase = false;
            try
            {
                //���� �� ������� � ����� ����. ���� � ����� ���� ������ �������, �� ������ ������, ����� ����������
                string testingSpaces = FCTBLeft.Text;
                if (testingSpaces.Replace(" ", "").Replace("\r\n", "").Replace("\t", "").Count() == 0)
                {
                    MessageBox.Show("����� ���� ��������� �� ����� ���� ������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                canonizedCode = ComparatorUtils.Canonize(FCTBLeft, (ProgrammingLanguages)comboBoxLanguage.SelectedIndex); //���������� � ������� ������ � ������� ��������� �������� ������������
                symbolsCount = (uint)canonizedCode.Length;


                if (symbolsCount > maximumSymbolsSetting)
                {
                    MessageBox.Show($"������� ��������� ��������� �� ��������� ������ {symbolsCount} �������� � ��� ����. ������ ������� ����� {maximumSymbolsSetting} �������� � ������ ����.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                leftCode = new Tokenizer((ProgrammingLanguages)comboBoxLanguage.SelectedIndex, canonizedCode);
                try
                {
                    leftCodeTokenShingles = new Shingle(leftCode, 3).Shingles;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "������ ��������������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    blockFromAddingInDatabase = true; //� ���� ������ �� ����� ������������� ���, ������� ����� ���������� �������� � ����������, ������� ����� ��� ����� ������ ����������
                }
                try
                {
                    leftCodeShingle = new Shingle(leftCode.ToString());
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "������ ��������������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    blockFromAddingInDatabase = true;
                }


                //������ ����
                bool isEmpty = false; //�������� �� ������� ������� ����
                codeCompare = new List<Tokenizer>();
                List<string> canonizedComparableCodes = new List<string>();
                if (FCTBRight.LinesCount >= 1)
                {
                    testingSpaces = FCTBRight.Text;
                    if (testingSpaces.Replace(" ", "").Replace("\r\n", "").Replace("\t", "").Count() == 0)
                    {
                        MessageBox.Show("������ ���� �� �������� � ���� ����������. ��������� ����� ����������� ������ �� ������ ��������� �� ���� ������." +
                        "���� ����� ��������� �� �����, �������� �������� ��� � ������ ����, ����� �� � ��� ����������", "������ ��������������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        isEmpty = true;
                    }
                    else
                    {
                        canonizedCode = ComparatorUtils.Canonize(FCTBRight, (ProgrammingLanguages)comboBoxLanguage.SelectedIndex);
                        if (canonizedCode.Length > maximumSymbolsSetting)
                        {
                            MessageBox.Show($"� ����� ���������� �������������� ��������� ������ ������� ����� {maximumSymbolsSetting} ��������. ������� ���������� - {canonizedCode.Length}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        codeCompare.Add(new Tokenizer((ProgrammingLanguages)comboBoxLanguage.SelectedIndex, canonizedCode));//��������� � ������ ����� ���������� �� ������� ����
                        canonizedComparableCodes.Add(canonizedCode);
                    }
                }
                else
                {
                    MessageBox.Show("������ ���� �� �������� � ���� ����������. ��������� ����� ����������� ������ �� ������ ��������� �� ���� ������." +
                        "���� ����� ��������� �� �����, �������� �������� ��� � ������ ����, ����� �� � ��� ����������", "������ ��������������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isEmpty = true;
                }



                //������ � ����� ������
                var listFromDB = FetchDataFromDB(symbolsCount, (ProgrammingLanguages)comboBoxLanguage.SelectedIndex); //���� � ���� ������ �������� ��������
                foreach (var item in listFromDB) //��������� ������ �������
                {
                    canonizedComparableCodes.Add(item.CanonizedCode); //��������� ���������������� ��� � ������
                    codeCompare.Add(new Tokenizer(item.Language, item.CanonizedCode)); //��������� � ������ ���������������� ����� ��� �� ���� ������
                }
                if (codeCompare.Count == 0 && isEmpty)
                {
                    MessageBox.Show("� ���� ������ �� ���� ���������� �������� �����, ������� ����� ������������� �������� ���������� � ������ � ����������� ��������.");
                    return;
                }


                //��������� ���������
                Comparator cmp = new Comparator();
                List<List<float>> percents = new List<List<float>>(); //������ ��������� �������� ��� ������� ����������������� ����

                SwitchControl(this.Controls.Find("waitingPanel", false)[0]);

                Thread thread = new Thread(() =>
                {
                    Parallel.For(0, codeCompare.Count, i =>
                    {
                        percents.Add(cmp.Compare(leftCode, leftCodeTokenShingles, leftCodeShingle, codeCompare[i], i));
                    });
                });
                thread.Start();

                while (thread.IsAlive)
                {
                    Application.DoEvents();
                }

                SwitchControl(this.Controls.Find("waitingPanel", false)[0]);


                //����� �����������
                Results results = new Results(canonizedComparableCodes, percents);
                results.Show();

                float maxPercent = percents.Max(item => item[5]); //������������� ������-��������� ��� ������ ������������� ��������
                labelPlagiatPercent.Text = "������� �������� ��������: " + maxPercent + "%";

                if (plagiatPercentSetting > maxPercent)
                {
                    labelPlagiat.Text = "�������: ���";
                    if (blockFromAddingInDatabase == false)
                    {
                        DialogResult dr = MessageBox.Show("�� ������ �������� ���, ����������� � ����� ���� � ���� ������?", "���������� � ���� ������", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            DBWorker worker = new DBWorker();
                            CodeInfo ci = new CodeInfo(canonizedCode, symbolsCount, (ProgrammingLanguages)comboBoxLanguage.SelectedIndex, DateTime.Now);
                            DBWorker.InsertIntoDB(ci);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("������� ���� ���������. ���������� ���� � ������������ ��� ��������� ��������� ����������", "�������!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    labelPlagiat.Text = "�������: ��";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "��������� ������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonShowTokens_Click(object sender, EventArgs e)
        {
            string testingSpaces = FCTBLeft.Text;
            if (testingSpaces.Replace(" ", "").Replace("\r\n", "").Replace("\t", "").Count() == 0)
            {
                MessageBox.Show("����� ���� ��������� �� ����� ���� ������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string canonizedCode = ComparatorUtils.Canonize(FCTBLeft, (ProgrammingLanguages)comboBoxLanguage.SelectedIndex);
                TokensReview window = new TokensReview(canonizedCode, (ProgrammingLanguages)comboBoxLanguage.SelectedIndex);
                window.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "��������� ������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DBViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Database window = new Database();
            window.Show();
        }
        

        private void DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void DragDrop(object sender, DragEventArgs e)
        {
            string[] fileData = (string[])e.Data.GetData(DataFormats.FileDrop);
            try
            {
                StreamReader streamReader = new StreamReader(fileData[0]); //�������� ����� ��� ������ �����
                StringBuilder sb = new StringBuilder();
                try //�������� �������� ������ �� �����
                {
                    sb.Append(streamReader.ReadToEnd());
                    var FCTB = sender as FastColoredTextBox; //sender ������ ����� ���� �� ����
                    FCTB.Text = sb.ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("������ �������� ������ �����. �� ������� ��������� ������ �� �����.");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings window = new Settings(plagiatPercentSetting, maximumSymbolsSetting);
            if (window.ShowDialog() == DialogResult.OK)
            {
                List<string> data = window.GetData();
                Byte.TryParse(data[0], out plagiatPercentSetting);
                UInt32.TryParse(data[1], out maximumSymbolsSetting);
                Properties.Settings.Default.plagiatPercent = plagiatPercentSetting;
                Properties.Settings.Default.maximumSymbols = maximumSymbolsSetting;
                Properties.Settings.Default.Save();
            }
        }
        private List<CodeInfo> FetchDataFromDB(uint length, ProgrammingLanguages language)
        {
            return DBWorker.Find(length, language);
        }
        private void SwitchControl(Control control)
        {
            control.Visible = !control.Visible;
            control.Enabled = !control.Enabled;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About window = new About(this);
            window.ShowDialog();
        }
    }
}
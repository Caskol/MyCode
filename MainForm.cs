using FastColoredTextBoxNS;
using System.Configuration;
using System.Text;
using System.Text.RegularExpressions;

namespace MyCode
{
    public partial class MainForm : Form
    {
        byte plagiatPercentSetting = Properties.Settings.Default.plagiatPercent;

        readonly List<String> availableLanguages = new List<String>()
        {
            "C", "C++", "C#","Java","Pascal", "Python"
        };
        public MainForm()
        {
            InitializeComponent();
            comboBoxLanguage.DataSource = availableLanguages;
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
            Shingle leftCodeShingle=null;//������ �� ���� ������ ����
            List<string> leftCodeTokenShingles=null; //������ ������� �� ������ ������� (� ����� ������ ���������� 4 ������ ��� ���������� ���������� ����������� �������)
            uint symbolsCount; //���������� �������� � ���������������� ������ ��� ������������� ������ � ���� ������
            string canonizedCode; //������ � ���������������� �����
            List<Tokenizer> codeCompare = new List<Tokenizer>(); //������� ������ �����, � ������� ����� ������������ �������� ��� (�.�. ���, ��� ������ � ����� ���� ���������)
            bool blockFromAddingInDatabase = false;

            if (FCTBLeft.LinesCount > 1 || FCTBLeft.Lines[0].Length != 0) //
            {
                StringBuilder line = new StringBuilder(""); //��������� ����������, � ������� ����� ������������ ������, �� ������� ����� ������� �����������
                for (int i = 0; i < FCTBLeft.LinesCount; i++) //���������� ������ ������ � Stringbuilder
                {
                    line.Append(Regex.Replace(FCTBLeft.Lines[i].ToString(), @"\/\*[\s\S]*?\*\/|([^:]|^)\/\/.*$", " "));
                }
                //������ � ������ ������ C � C++, ������������ � ANTLR4 ������, ����� �������� � �������������� ��������������, ������� ����� ������� �������, ������� ��������� �� �������������
                if (comboBoxLanguage.SelectedValue.ToString().Equals("C") || comboBoxLanguage.SelectedValue.ToString().Equals("C++"))
                    line.Replace("#", "");
                canonizedCode = line.ToString();  //���������� � ������� ������ � ������� ��������� �������� ������������
                leftCode = new Tokenizer(comboBoxLanguage.SelectedValue.ToString(), canonizedCode);
                symbolsCount = (uint)canonizedCode.Length;
                try
                {
                    leftCodeTokenShingles = new Shingle(leftCode, 4).Shingles;
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
            }
            else
            {
                MessageBox.Show("����� ���� ��������� �� ����� ���� ������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }




            bool isEmpty = false; //�������� �� ������� ������� ����
            List<string> canonizedComparableCodes = new List<string>();
            if (FCTBRight.LinesCount > 1 || FCTBRight.Lines[0].Length != 0) //
            {
                string canonizedCodeRight;
                StringBuilder line = new StringBuilder("");
                for (int i = 0; i < FCTBRight.LinesCount; i++) //������� ����������� � ����� ���������
                    line.Append(Regex.Replace(FCTBRight.Lines[i], @"\/\*[\s\S]*?\*\/|([^:]|^)\/\/.*$", " "));
                //������ � ������, ������������ � ANTLR4 ������ ����� �������� � �������������� ��������������, ������� ����� ������� �������, ������� ��������� �� �������������
                if (comboBoxLanguage.SelectedValue.ToString().Equals("C") || comboBoxLanguage.SelectedValue.ToString().Equals("C++"))
                    line.Replace("#", "");
                canonizedCodeRight = line.ToString();
                codeCompare.Add(new Tokenizer(comboBoxLanguage.SelectedValue.ToString(), canonizedCodeRight));//��������� � ������ ����� ���������� �� ������� ����
                canonizedComparableCodes.Add(canonizedCodeRight);
            }
            else
            {
                MessageBox.Show("������ ���� �� �������� � ���� ����������. ��������� ����� ����������� ������ �� ������ ��������� �� ���� ������." +
                    "���� ����� ��������� �� �����, �������� �������� ��� � ������ ����, ����� �� � ��� ����������", "������ ��������������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isEmpty = true;
            }
            var listFromDB = FetchDataFromDB(symbolsCount, comboBoxLanguage.SelectedValue.ToString()); //���� � ���� ������ �������� ��������
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



            Comparator cmp = new Comparator();
            List<List<float>> percents = new List<List<float>>(); //������ ��������� �������� ��� ������� ����������������� ����

            //��������� ���� �������� � ��������� ������
            WaitingForm wf = new WaitingForm();
            Thread thread = new Thread(() =>
            {
                wf.ShowDialog();
            });
            thread.Start(); //��������� ����� - �� ����� �������� ���� �� ���������� �������� ����
            //Application.DoEvents();
            foreach (var item in codeCompare)
            {
                percents.Add(cmp.Compare(leftCode, leftCodeTokenShingles, leftCodeShingle, item));
            }
            //����� ���������� �������� ���� �������� ���� �������
            wf.Invoke((MethodInvoker)(() => { 
                wf.Close();
            }));



            Results results = new Results(canonizedComparableCodes, percents);
            results.Show();
            float maxPercent = 0;
            foreach (var item in percents) //���� ��� ������ ����������� �������� �������� ����� �������
            {
                if (item[4] > maxPercent)
                    maxPercent = item[4];
            }


            labelPlagiatPercent.Text = "������� �������� ��������: " + maxPercent + "%";

            if (plagiatPercentSetting > maxPercent)
            {
                labelPlagiat.Text = "�������: ���";
                DialogResult dr = MessageBox.Show("�� ������ �������� ���, ����������� � ����� ���� � ���� ������?", "���������� � ���� ������", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    DBWorker worker = new DBWorker();
                    CodeInfo ci = new CodeInfo(canonizedCode, symbolsCount, comboBoxLanguage.SelectedValue.ToString(), DateTime.Now);
                    worker.InsertIntoDB(ci);
                }
            }
            else
            {
                MessageBox.Show("������� ���� ���������. ���������� ���� � ������������ ��� ��������� ��������� ����������","�������!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                labelPlagiat.Text = "�������: ��";
            }
        }

        private void buttonShowTokens_Click(object sender, EventArgs e)
        {
            if (FCTBLeft.Text.Length == 0)
            {
                MessageBox.Show("����� ���� ��������� �� ����� ���� ������", "��������������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                TokensReview window = new TokensReview(FCTBLeft.Text, comboBoxLanguage.Text);
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
            Settings window = new Settings(plagiatPercentSetting);
            if (window.ShowDialog() == DialogResult.OK)
            {
                plagiatPercentSetting = window.GetData();
                Properties.Settings.Default.plagiatPercent = plagiatPercentSetting;
                Properties.Settings.Default.Save();
            }
        }
        private List<CodeInfo> FetchDataFromDB(uint length,string language)
        {
            DBWorker worker = new DBWorker();
            return worker.Find(length, language);
        }
    }
}
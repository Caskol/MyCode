using FastColoredTextBoxNS;
using System.Text;
using System.Text.RegularExpressions;

namespace MyCode
{
    public partial class MainForm : Form
    {
        byte plagiatPercentSetting = 70;

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
            Tokenizer leftCode, rightCode;
            StringBuilder text = new StringBuilder("");
            uint symbolsCount;
            string canonizedCode;

            if (FCTBLeft.LinesCount > 1 || FCTBLeft.Lines[0].Length != 0) //
            {
                text.Clear();
                StringBuilder line = new StringBuilder("");
                for (int i = 0; i < FCTBLeft.LinesCount; i++) //������� ����������� � ����� ���������
                {
                    line.Append(FCTBLeft.Lines[i].ToString());
                    //������ � ������ ������ C � C++, ������������ � ANTLR4 ������, ����� �������� � �������������� ��������������, ������� ����� ������� �������, ������� ��������� �� �������������
                    if (comboBoxLanguage.SelectedValue.ToString().Equals("C") || comboBoxLanguage.SelectedValue.ToString().Equals("C++"))
                        line.Replace("#", "");
                    text.Append(Regex.Replace(line.ToString(), @"\/\*[\s\S]*?\*\/|([^:]|^)\/\/.*$", " "));
                    line.Clear();
                }
                leftCode = new Tokenizer(comboBoxLanguage.SelectedValue.ToString(), text.ToString());
                symbolsCount = (uint)text.ToString().Length;
                canonizedCode = text.ToString();
            }
            else
            {
                MessageBox.Show("����� ���� ��������� �� ����� ���� ������", "��������������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }





            if (FCTBRight.LinesCount > 1 || FCTBRight.Lines[0].Length != 0) //
            {
                text.Clear();
                StringBuilder line = new StringBuilder("");
                for (int i = 0; i < FCTBRight.LinesCount; i++) //������� ����������� � ����� ���������
                {
                    line.Append(FCTBRight.Lines[i].ToString());
                    //������ � ������, ������������ � ANTLR4 ������ ����� �������� � �������������� ��������������, ������� ����� ������� �������, ������� ��������� �� �������������
                    if (comboBoxLanguage.SelectedValue.ToString().Equals("C") || comboBoxLanguage.SelectedValue.ToString().Equals("C++"))
                        line.Replace("#", "");
                    text.Append(Regex.Replace(line.ToString(), @"\/\*[\s\S]*?\*\/|([^:]|^)\/\/.*$", " "));
                    line.Clear();
                }
                rightCode = new Tokenizer(comboBoxLanguage.SelectedValue.ToString(), text.ToString());
            }
            else
            {
                //�������� ���� ������ � ��
                rightCode = new Tokenizer(comboBoxLanguage.SelectedValue.ToString(), text.ToString());
            }





            Comparator cmp = new Comparator();
            try
            {
                //������    
                float levenshteinToken = cmp.LevenshteinDistance(leftCode.TokensArray, rightCode.TokensArray);
                float jaccardToken = -1, diceToken = -1;
                try
                {
                    jaccardToken = cmp.JaccardCoefficient(new Shingle(leftCode, 4).Shingles, new Shingle(rightCode, 4).Shingles); //������� k-������ �� �������������, ������ k=4
                    diceToken = cmp.SorensenDiceCoefficient(new Shingle(leftCode, 4).Shingles, new Shingle(rightCode, 4).Shingles);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "������ ��������������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                float lcsToken = cmp.LongestCommonSubsequence(leftCode.GetIdentificatorsString(), rightCode.GetIdentificatorsString());
                if (jaccardToken == -1 && diceToken == -1)
                    cmp.PercentTokens = (levenshteinToken + lcsToken) / 2 * 100;
                else
                    cmp.PercentTokens = (levenshteinToken + jaccardToken + diceToken + lcsToken) / 4 * 100;




                //������
                Shingle left = null, right = null;
                float levenshteinShingle = -1, jaccardShingle = -1, diceShingle = -1, lcsShingle = -1;
                try
                {
                    left = new Shingle(leftCode.ToString());
                    right = new Shingle(rightCode.ToString()); //�������� ������ ����� ������ ���� ������
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "������ ��������������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (left != null && right != null)
                {
                    levenshteinShingle = cmp.LevenshteinDistance(left.Shingles, right.Shingles);
                    jaccardShingle = cmp.JaccardCoefficient(left.Shingles, right.Shingles);
                    diceShingle = cmp.SorensenDiceCoefficient(left.Shingles, right.Shingles);
                    lcsShingle = cmp.LongestCommonSubsequence(left.ToString(), right.ToString());
                    cmp.PercentShingles = (levenshteinShingle + jaccardShingle + diceShingle + lcsShingle) / 4 * 100;
                }

                if (plagiatPercentSetting > cmp.PercentTokens)
                {
                    labelPlagiat.Text = "�������: ���";
                    DialogResult dr = MessageBox.Show("�� ������ �������� ���, ����������� � ����� ���� � ���� ������?", "���������� � ���� ������", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    DBWorker worker = new DBWorker();
                    if (dr == DialogResult.Yes)
                    {

                        CodeInfo ci = new CodeInfo(canonizedCode, symbolsCount, comboBoxLanguage.SelectedValue.ToString(), DateTime.Now);
                        worker.InsertIntoDB(ci);
                    }
                    //worker.Find(symbolsCount);
                }
                else
                {
                    labelPlagiat.Text = "�������: ��";
                }

                labelPlagiatPercent.Text = "������� �������� ��������: " + cmp.PercentTokens + "%";
                MessageBox.Show($"���������:\n����� �������:\n����������:{levenshteinToken * 100}%\n������:{jaccardToken * 100}%\nѸ������:{diceToken * 100}%\nLCS:{lcsToken * 100}%\t����:{cmp.PercentTokens}%\n����� �������:\n����������:{levenshteinShingle * 100}%\n������:{jaccardShingle * 100}%\nѸ������:{diceShingle * 100}%\nLCS:{lcsShingle * 100}%\t����:{cmp.PercentShingles}%");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "��������� ������", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
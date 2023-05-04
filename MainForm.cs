using FastColoredTextBoxNS;
using System.Text;
using System.Text.RegularExpressions;
using LiteDB;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System.Diagnostics;
using System.ComponentModel.Design.Serialization;
using Antlr4.Build.Tasks;

namespace MyCode
{
    public partial class MainForm : Form
    {
        //Tokenizer analyticLeft = null, analyticRight = null;
        byte plagiatPercentSetting=70;
        LiteDatabase db = new LiteDatabase(@"CodeLibrary.db"); //���������� ���� ������ NoSQL � ���������
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
                    catch (Exception ex)
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
                        StatusStripLabel.Text = "����� �����: " + FCTBLeft.LineInfos.Count;
                    }
                }
            }
        }

        private void FCTBLeft_TextChanged(object sender, TextChangedEventArgs e)
        {
            StatusStripLabel.Text = "����� ����� � ����� ����: " + FCTBLeft.LinesCount;
            labelLeftCount.Text="���������� ����� �����: " + FCTBLeft.LinesCount;

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
            Tokenizer leftCode, rightCode=null;
            StringBuilder text = new StringBuilder("");
            if (FCTBLeft.LinesCount > 1 || FCTBLeft.Lines[0].Length!=0) //
            {
                text.Clear();
                StringBuilder line = new StringBuilder("");
                for (int i = 0; i < FCTBLeft.LinesCount; i++) //������� ����������� � ����� ���������
                {
                    line.Append(FCTBLeft.Lines[i].ToString());
                    //������ � ������ ������ C � C++, ������������ � ANTLR4 ������ ����� �������� � �������������� ��������������, ������� ����� ������� �������, ������� ��������� �� �������������
                    if (comboBoxLanguage.SelectedValue.ToString().Equals("C") || comboBoxLanguage.SelectedValue.ToString().Equals("C++"))
                        line.Replace("#", "");
                    text.Append(Regex.Replace(line.ToString(), @"\/\*[\s\S]*?\*\/|([^:]|^)\/\/.*$", " "));
                    line.Clear();
                }
                leftCode = new Tokenizer (comboBoxLanguage.SelectedValue.ToString(),text.ToString());
            }
            else
            {
                MessageBox.Show("����� ���� ��������� �� ����� ���� ������");
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
            Comparator cmp = new Comparator();
            try
            {
                Shingle left = new Shingle(leftCode.ToString());
                Shingle right = new Shingle(rightCode.ToString());
                float levenshteinToken=cmp.LevenshteinDistance(leftCode.TokensArray, rightCode.TokensArray);
                float jaccardToken = cmp.JaccardCoefficient(new Shingle(leftCode,4).Shingles, new Shingle(rightCode, 4).Shingles); //������� k-������ �� �������������, ������ k=4
                float diceToken = cmp.SorensenDiceCoefficient(new Shingle(leftCode, 4).Shingles, new Shingle(rightCode, 4).Shingles);
                float lcsToken = cmp.LongestCommonSubsequence(leftCode.GetIdentificatorsString(),rightCode.GetIdentificatorsString());
                float levenshteinShingle = cmp.LevenshteinDistance(left.Shingles, right.Shingles);
                float jaccardShingle = cmp.JaccardCoefficient(left.Shingles,right.Shingles);
                float diceShingle = cmp.SorensenDiceCoefficient(left.Shingles, right.Shingles);
                float lcsShingle = cmp.LongestCommonSubsequence(left.ToString(),right.ToString());
                if (plagiatPercentSetting > cmp.Percent)
                    labelPlagiat.Text = "�������: ���";
                else
                    labelPlagiat.Text = "�������: ��";
                labelPlagiatPercent.Text = "������� �������� ��������: " + (float)cmp.Percent;
                MessageBox.Show($"���������:\n����� �������:\n����������:{levenshteinToken*100}%\n������:{jaccardToken*100}%\nѸ������:{diceToken*100}%\nLCS:{lcsToken * 100}%\t����:{(levenshteinToken+jaccardToken+diceToken)/3*100}%\n����� �������:\n����������:{levenshteinShingle*100}%\n������:{jaccardShingle*100}%\nѸ������:{diceShingle*100}%\nLCS:{lcsShingle * 100}%\t����:{(levenshteinShingle+jaccardShingle+diceShingle)/3*100}%");
            }
            catch (Exception ex)
            {
                if (ex is NullReferenceException)
                MessageBox.Show("���� ������ ���� ������");
            }

        }

        private void buttonShowTokens_Click(object sender, EventArgs e)
        {
            TokensReview window = new TokensReview(FCTBLeft.Text, comboBoxLanguage.Text);
            window.Show();
        }
    }
}
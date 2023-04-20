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
        List<String> availableLanguages = new List<String>()
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
                for (int i = 0; i < FCTBLeft.LinesCount; i++) //������� ����������� � ����� ���������
                    text.Append(Regex.Replace(FCTBLeft.Lines[i], @"\/\*[\s\S]*?\*\/|([^:]|^)\/\/.*$", " ")); 
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
                for (int i = 0; i < FCTBRight.LinesCount; i++) //
                    text.Append(Regex.Replace(FCTBRight.Lines[i], @"\/\*[\s\S]*?\*\/|([^:]|^)\/\/.*$", " ")); //
                rightCode = new Tokenizer(comboBoxLanguage.SelectedValue.ToString(), text.ToString());
            }
            Comparator cmp = new Comparator();
            try
            {
                cmp.LevenshteinDistance(leftCode.TokensArray, rightCode.TokensArray);
                if (plagiatPercentSetting > cmp.Percent)
                    labelPlagiat.Text = "�������: ���";
                else
                    labelPlagiat.Text = "�������: ��";
                labelPlagiatPercent.Text = "������� �������� ��������: " + (float)cmp.Percent;
                MessageBox.Show($": {(float)cmp.Percent}");
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void buttonShowTokens_Click(object sender, EventArgs e)
        {
            TokensReview window = new TokensReview(FCTBLeft.Text, comboBoxLanguage.Text);
            window.Show();
        }
    }
}
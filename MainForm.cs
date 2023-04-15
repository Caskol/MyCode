using FastColoredTextBoxNS;
using System.Text;
using System.Text.RegularExpressions;
using LiteDB;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System.Diagnostics;
using System.ComponentModel.Design.Serialization;

namespace MyCode
{
    public partial class MainForm : Form
    {
        Tokenizer analyticLeft = null, analyticRight = null;
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
        /// <summary>
        /// LEGACY
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateTokens_Click(object sender, EventArgs e)
        {

            StringBuilder text = new StringBuilder(""); //������� ��������� ����������, ���������� ��������������� �����
            if (FCTBLeft.LinesCount > 0) //���� � ����� ���� ���� �����, �� ������������ ���
            {
                text.Clear();
                for (int i = 0; i < FCTBLeft.LinesCount; i++) //���� ������������ ������ �����
                    text.Append(Regex.Replace(FCTBLeft.Lines[i], @"\/\*[\s\S]*?\*\/|([^:]|^)\/\/.*$", " ")); //������� ����� ������������ � ���������
                analyticLeft = new Tokenizer();
                analyticLeft.Tokenize(text.ToString());
            }
            if (FCTBRight.LinesCount > 0) //���� � ����� ���� ���� �����, �� ������������ ���
            {
                text.Clear();
                for (int i = 0; i < FCTBRight.LinesCount; i++) //���� ������������ ������ �����
                    text.Append(Regex.Replace(FCTBRight.Lines[i], @"\/\*[\s\S]*?\*\/|([^:]|^)\/\/.*$", " ")); //������� ����� ������������ � ���������
                analyticRight = new Tokenizer();
                analyticRight.Tokenize(text.ToString());
            }
            Comparator cmp = new Comparator();
            try
            {
                cmp.LevenshteinDistance(analyticLeft.TokenizedString, analyticRight.TokenizedString);
                MessageBox.Show($"��������� ���������: {(float)cmp.Percent}");
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void FCTBLeft_TextChanged(object sender, TextChangedEventArgs e)
        {
            StatusStripLabel.Text = "����� ����� � ����� ����: " + FCTBLeft.LinesCount;
        }

        private void FCTBRight_TextChanged(object sender, TextChangedEventArgs e)
        {
            StatusStripLabel.Text = "����� ����� � ������ ����: " + FCTBRight.LinesCount;
        }

        private void FCTBLeft_Click(object sender, EventArgs e)
        {
            StatusStripLabel.Text = "����� ����� � ����� ����: " + FCTBLeft.LinesCount;
        }

        private void FCTBRight_Click(object sender, EventArgs e)
        {
            StatusStripLabel.Text = "����� ����� � ������ ����: " + FCTBRight.LinesCount;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TokensAndTree window = new TokensAndTree(FCTBLeft.Text, comboBoxLanguage.Text);
            window.Show();
        }

        private void buttonCompare_Click(object sender, EventArgs e)
        {

        }
    }
}
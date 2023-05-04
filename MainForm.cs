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
        LiteDatabase db = new LiteDatabase(@"CodeLibrary.db"); //подключаем базу данных NoSQL к программе
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
                    StreamReader streamReader = new StreamReader(openFileDialog.FileName); //получаем поток для чтения файла
                    StringBuilder sb = new StringBuilder();
                    try //пытаемся получить строки из файла
                    {
                        sb.Append(streamReader.ReadToEnd());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Выбран неверный формат файла. Не удалось прочитать строки из файла.");
                        return;
                    }
                    DialogResult dialogResult = MessageBox.Show("Разместить этот документ слева?", "Размещение документа", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        FCTBLeft.Text = sb.ToString();
                        StatusStripLabel.Text = "Всего строк: " + FCTBLeft.LineInfos.Count;
                    }
                    else
                    {
                        FCTBRight.Text = sb.ToString();
                        StatusStripLabel.Text = "Всего строк: " + FCTBLeft.LineInfos.Count;
                    }
                }
            }
        }

        private void FCTBLeft_TextChanged(object sender, TextChangedEventArgs e)
        {
            StatusStripLabel.Text = "Всего строк в левом окне: " + FCTBLeft.LinesCount;
            labelLeftCount.Text="Количество строк слева: " + FCTBLeft.LinesCount;

        }

        private void FCTBRight_TextChanged(object sender, TextChangedEventArgs e)
        {
            StatusStripLabel.Text = "Всего строк в правом окне: " + FCTBRight.LinesCount;
            labelRightCount.Text = "Количество строк справа: " + FCTBRight.LinesCount;
        }

        private void FCTBLeft_Click(object sender, EventArgs e)
        {
            StatusStripLabel.Text = "Всего строк в левом окне: " + FCTBLeft.LinesCount;
        }

        private void FCTBRight_Click(object sender, EventArgs e)
        {
            StatusStripLabel.Text = "Всего строк в правом окне: " + FCTBRight.LinesCount;
        }

        private void buttonCompare_Click(object sender, EventArgs e)
        {
            Tokenizer leftCode, rightCode=null;
            StringBuilder text = new StringBuilder("");
            if (FCTBLeft.LinesCount > 1 || FCTBLeft.Lines[0].Length!=0) //
            {
                text.Clear();
                StringBuilder line = new StringBuilder("");
                for (int i = 0; i < FCTBLeft.LinesCount; i++) //убираем комментарии в цикле построчно
                {
                    line.Append(FCTBLeft.Lines[i].ToString());
                    //Лексер и парсер языков C и C++, поставляемые в ANTLR4 базово имеют проблемы с распознаванием препроцессоров, поэтому лучше удалять символы, которые указывают на препроцессинг
                    if (comboBoxLanguage.SelectedValue.ToString().Equals("C") || comboBoxLanguage.SelectedValue.ToString().Equals("C++"))
                        line.Replace("#", "");
                    text.Append(Regex.Replace(line.ToString(), @"\/\*[\s\S]*?\*\/|([^:]|^)\/\/.*$", " "));
                    line.Clear();
                }
                leftCode = new Tokenizer (comboBoxLanguage.SelectedValue.ToString(),text.ToString());
            }
            else
            {
                MessageBox.Show("Левое окно программы не может быть пустым");
                return;
            }
            if (FCTBRight.LinesCount > 1 || FCTBRight.Lines[0].Length != 0) //
            {
                text.Clear();
                StringBuilder line = new StringBuilder("");
                for (int i = 0; i < FCTBRight.LinesCount; i++) //убираем комментарии в цикле построчно
                {
                    line.Append(FCTBRight.Lines[i].ToString());
                    //Лексер и парсер, поставляемый в ANTLR4 базово имеет проблемы с распознаванием препроцессоров, поэтому лучше удалять символы, которые указывают на препроцессинг
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
                float jaccardToken = cmp.JaccardCoefficient(new Shingle(leftCode,4).Shingles, new Shingle(rightCode, 4).Shingles); //создаем k-граммы из идентификатор, причем k=4
                float diceToken = cmp.SorensenDiceCoefficient(new Shingle(leftCode, 4).Shingles, new Shingle(rightCode, 4).Shingles);
                float lcsToken = cmp.LongestCommonSubsequence(leftCode.GetIdentificatorsString(),rightCode.GetIdentificatorsString());
                float levenshteinShingle = cmp.LevenshteinDistance(left.Shingles, right.Shingles);
                float jaccardShingle = cmp.JaccardCoefficient(left.Shingles,right.Shingles);
                float diceShingle = cmp.SorensenDiceCoefficient(left.Shingles, right.Shingles);
                float lcsShingle = cmp.LongestCommonSubsequence(left.ToString(),right.ToString());
                if (plagiatPercentSetting > cmp.Percent)
                    labelPlagiat.Text = "Плагиат: Нет";
                else
                    labelPlagiat.Text = "Плагиат: Да";
                labelPlagiatPercent.Text = "Текущее значение схожести: " + (float)cmp.Percent;
                MessageBox.Show($"Результат:\nМетод токенов:\nЛевенштейн:{levenshteinToken*100}%\nЖаккар:{jaccardToken*100}%\nСёренсен:{diceToken*100}%\nLCS:{lcsToken * 100}%\tИтог:{(levenshteinToken+jaccardToken+diceToken)/3*100}%\nМетод шинглов:\nЛевенштейн:{levenshteinShingle*100}%\nЖаккар:{jaccardShingle*100}%\nСёренсен:{diceShingle*100}%\nLCS:{lcsShingle * 100}%\tИтог:{(levenshteinShingle+jaccardShingle+diceShingle)/3*100}%");
            }
            catch (Exception ex)
            {
                if (ex is NullReferenceException)
                MessageBox.Show("Окно справа было пустым");
            }

        }

        private void buttonShowTokens_Click(object sender, EventArgs e)
        {
            TokensReview window = new TokensReview(FCTBLeft.Text, comboBoxLanguage.Text);
            window.Show();
        }
    }
}
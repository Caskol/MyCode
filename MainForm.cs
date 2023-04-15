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
        LiteDatabase db = new LiteDatabase(@"CodeLibrary.db"); //подключаем базу данных NoSQL к программе
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
        /// <summary>
        /// LEGACY
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateTokens_Click(object sender, EventArgs e)
        {

            StringBuilder text = new StringBuilder(""); //создаем временную переменную, содержащую нормализованный текст
            if (FCTBLeft.LinesCount > 0) //если в левом окне есть текст, то токенизируем его
            {
                text.Clear();
                for (int i = 0; i < FCTBLeft.LinesCount; i++) //Цикл нормализации каждой линии
                    text.Append(Regex.Replace(FCTBLeft.Lines[i], @"\/\*[\s\S]*?\*\/|([^:]|^)\/\/.*$", " ")); //убираем блоки комментариев и табуляции
                analyticLeft = new Tokenizer();
                analyticLeft.Tokenize(text.ToString());
            }
            if (FCTBRight.LinesCount > 0) //если в левом окне есть текст, то токенизируем его
            {
                text.Clear();
                for (int i = 0; i < FCTBRight.LinesCount; i++) //Цикл нормализации каждой линии
                    text.Append(Regex.Replace(FCTBRight.Lines[i], @"\/\*[\s\S]*?\*\/|([^:]|^)\/\/.*$", " ")); //убираем блоки комментариев и табуляции
                analyticRight = new Tokenizer();
                analyticRight.Tokenize(text.ToString());
            }
            Comparator cmp = new Comparator();
            try
            {
                cmp.LevenshteinDistance(analyticLeft.TokenizedString, analyticRight.TokenizedString);
                MessageBox.Show($"Результат сравнения: {(float)cmp.Percent}");
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void FCTBLeft_TextChanged(object sender, TextChangedEventArgs e)
        {
            StatusStripLabel.Text = "Всего строк в левом окне: " + FCTBLeft.LinesCount;
        }

        private void FCTBRight_TextChanged(object sender, TextChangedEventArgs e)
        {
            StatusStripLabel.Text = "Всего строк в правом окне: " + FCTBRight.LinesCount;
        }

        private void FCTBLeft_Click(object sender, EventArgs e)
        {
            StatusStripLabel.Text = "Всего строк в левом окне: " + FCTBLeft.LinesCount;
        }

        private void FCTBRight_Click(object sender, EventArgs e)
        {
            StatusStripLabel.Text = "Всего строк в правом окне: " + FCTBRight.LinesCount;
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
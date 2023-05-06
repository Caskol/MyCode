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
                    StreamReader streamReader = new StreamReader(openFileDialog.FileName); //получаем поток для чтения файла
                    StringBuilder sb = new StringBuilder();
                    try //пытаемся получить строки из файла
                    {
                        sb.Append(streamReader.ReadToEnd());
                    }
                    catch (Exception)
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
                        StatusStripLabel.Text = "Всего строк: " + FCTBRight.LineInfos.Count;
                    }
                }
            }
        }

        private void FCTBLeft_TextChanged(object sender, TextChangedEventArgs e)
        {
            StatusStripLabel.Text = "Всего строк в левом окне: " + FCTBLeft.LinesCount;
            labelLeftCount.Text = "Количество строк слева: " + FCTBLeft.LinesCount;
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
            Tokenizer leftCode, rightCode;
            StringBuilder text = new StringBuilder("");
            uint symbolsCount;
            string canonizedCode;

            if (FCTBLeft.LinesCount > 1 || FCTBLeft.Lines[0].Length != 0) //
            {
                text.Clear();
                StringBuilder line = new StringBuilder("");
                for (int i = 0; i < FCTBLeft.LinesCount; i++) //убираем комментарии в цикле построчно
                {
                    line.Append(FCTBLeft.Lines[i].ToString());
                    //Лексер и парсер языков C и C++, поставляемые в ANTLR4 базово, имеют проблемы с распознаванием препроцессоров, поэтому лучше удалять символы, которые указывают на препроцессинг
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
                MessageBox.Show("Левое окно программы не может быть пустым", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            else
            {
                //ДОПИСАТЬ СЮДА РАБОТУ С БД
                rightCode = new Tokenizer(comboBoxLanguage.SelectedValue.ToString(), text.ToString());
            }





            Comparator cmp = new Comparator();
            try
            {
                //ТОКЕНЫ    
                float levenshteinToken = cmp.LevenshteinDistance(leftCode.TokensArray, rightCode.TokensArray);
                float jaccardToken = -1, diceToken = -1;
                try
                {
                    jaccardToken = cmp.JaccardCoefficient(new Shingle(leftCode, 4).Shingles, new Shingle(rightCode, 4).Shingles); //создаем k-граммы из идентификатор, причем k=4
                    diceToken = cmp.SorensenDiceCoefficient(new Shingle(leftCode, 4).Shingles, new Shingle(rightCode, 4).Shingles);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Важное предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                float lcsToken = cmp.LongestCommonSubsequence(leftCode.GetIdentificatorsString(), rightCode.GetIdentificatorsString());
                if (jaccardToken == -1 && diceToken == -1)
                    cmp.PercentTokens = (levenshteinToken + lcsToken) / 2 * 100;
                else
                    cmp.PercentTokens = (levenshteinToken + jaccardToken + diceToken + lcsToken) / 4 * 100;




                //ШИНГЛЫ
                Shingle left = null, right = null;
                float levenshteinShingle = -1, jaccardShingle = -1, diceShingle = -1, lcsShingle = -1;
                try
                {
                    left = new Shingle(leftCode.ToString());
                    right = new Shingle(rightCode.ToString()); //дописать логику когда второе окно пустое
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Важное предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    labelPlagiat.Text = "Плагиат: Нет";
                    DialogResult dr = MessageBox.Show("Вы хотите добавить код, размещенный в левом окне в базу данных?", "Добавление в базу данных", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                    labelPlagiat.Text = "Плагиат: Да";
                }

                labelPlagiatPercent.Text = "Текущее значение схожести: " + cmp.PercentTokens + "%";
                MessageBox.Show($"Результат:\nМетод токенов:\nЛевенштейн:{levenshteinToken * 100}%\nЖаккар:{jaccardToken * 100}%\nСёренсен:{diceToken * 100}%\nLCS:{lcsToken * 100}%\tИтог:{cmp.PercentTokens}%\nМетод шинглов:\nЛевенштейн:{levenshteinShingle * 100}%\nЖаккар:{jaccardShingle * 100}%\nСёренсен:{diceShingle * 100}%\nLCS:{lcsShingle * 100}%\tИтог:{cmp.PercentShingles}%");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Произошла ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonShowTokens_Click(object sender, EventArgs e)
        {
            if (FCTBLeft.Text.Length == 0)
            {
                MessageBox.Show("Левое окно программы не может быть пустым", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                TokensReview window = new TokensReview(FCTBLeft.Text, comboBoxLanguage.Text);
                window.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Произошла ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                StreamReader streamReader = new StreamReader(fileData[0]); //получаем поток для чтения файла
                StringBuilder sb = new StringBuilder();
                try //пытаемся получить строки из файла
                {
                    sb.Append(streamReader.ReadToEnd());
                    var FCTB = sender as FastColoredTextBox; //sender всегда будет одно из окон
                    FCTB.Text = sb.ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("Выбран неверный формат файла. Не удалось прочитать строки из файла.");
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
using FastColoredTextBoxNS;
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

        readonly List<String> availableLanguages = new List<String>()
        {
            "C", "C++", "C#","Java","Pascal", "Python"
        };
        public MainForm()
        {
            InitializeComponent();
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
            Tokenizer leftCode; //токенизатор левого окна
            Shingle leftCodeShingle = null;//шинглы из кода левого окна
            List<string> leftCodeTokenShingles = null; //список шинглов на основе токенов (в одном шингле содержится 4 токена для уменьшения количества совпадающих шинглов)
            uint symbolsCount; //количество символов в канонизированном тексте для потенциальной записи в базу данных
            string canonizedCode; //строка с канонизированным кодом
            List<Tokenizer> codeCompare = new List<Tokenizer>(); //создаем список кодов, с которым будет сравниваться основной код (т.е. тот, что введен в левом окне программы)
            bool blockFromAddingInDatabase = false;

            if (FCTBLeft.LinesCount < 1 && FCTBLeft.Lines[0].Length == 0) //
            {
                MessageBox.Show("Левое окно программы не может быть пустым", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            //Левое окно
            StringBuilder line = new StringBuilder(""); //временная переменная, в которую будет записываться строка, из которой будут удалены комментарии
            string tempLine; 
            for (int i = 0; i < FCTBLeft.LinesCount; i++) //записываем каждую строку в Stringbuilder
            {
                tempLine = Regex.Replace(FCTBLeft.Lines[i].ToString(), @"\/\*[\s\S]*?\*\/|([^:]|^)\/\/.*$", " ");
                if (comboBoxLanguage.SelectedValue.ToString().Equals("C") || comboBoxLanguage.SelectedValue.ToString().Equals("C++") || comboBoxLanguage.SelectedValue.ToString().Equals("Python"))
                {
                    if (tempLine.IndexOf("#") < 0)
                        line.Append(tempLine);
                    else if (tempLine.IndexOf("#") > 0)
                        line.Append(tempLine.Substring(0, tempLine.IndexOf("#")));
                }
                else
                    line.Append(tempLine);
            }
            canonizedCode = line.ToString();  //записываем в готовую строку с текстом результат удаления комментариев
            symbolsCount = (uint)canonizedCode.Length;
            if (symbolsCount > maximumSymbolsSetting)
            {
                MessageBox.Show($"Текущие настройки программы не позволяют ввести {symbolsCount} символов в оба окна. Нельзя вводить более {maximumSymbolsSetting} символов в каждое окно.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            leftCode = new Tokenizer(comboBoxLanguage.SelectedValue.ToString(), canonizedCode);
            try
            {
                leftCodeTokenShingles = new Shingle(leftCode, 4).Shingles;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Важное предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                blockFromAddingInDatabase = true; //в базе данных не нужен неполноценный код, который будет доставлять проблемы в дальнейшем, поэтому такой код лучше только сравнивать
            }
            try
            {
                leftCodeShingle = new Shingle(leftCode.ToString());
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Важное предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                blockFromAddingInDatabase = true;
            }


            //Правое окно
            bool isEmpty = false; //проверка на пустоту правого окна
            List<string> canonizedComparableCodes = new List<string>();
            if (FCTBRight.LinesCount > 1 || FCTBRight.Lines[0].Length != 0) //
            {
                string canonizedCodeRight;
                line = new StringBuilder("");
                for (int i = 0; i < FCTBRight.LinesCount; i++) //убираем комментарии в цикле построчно
                {
                    tempLine = Regex.Replace(FCTBRight.Lines[i].ToString(), @"\/\*[\s\S]*?\*\/|([^:]|^)\/\/.*$", " ");
                    if (comboBoxLanguage.SelectedValue.ToString().Equals("C") || comboBoxLanguage.SelectedValue.ToString().Equals("C++") || comboBoxLanguage.SelectedValue.ToString().Equals("Python"))
                    {
                        if (tempLine.IndexOf("#") < 0)
                            line.Append(tempLine);
                        else if (tempLine.IndexOf("#") > 0)
                            line.Append(tempLine.Substring(0, tempLine.IndexOf("#")));
                    }
                    else
                        line.Append(tempLine);
                }
                canonizedCodeRight = line.ToString();
                if (canonizedCodeRight.Length > maximumSymbolsSetting)
                {
                    MessageBox.Show($"В целях увеличения быстродействия программы нельзя вводить более 25000 символов. Текущее количество - {canonizedCodeRight.Length}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                codeCompare.Add(new Tokenizer(comboBoxLanguage.SelectedValue.ToString(), canonizedCodeRight));//добавляем в список кодов информацию из правого окна
                canonizedComparableCodes.Add(canonizedCodeRight);
            }
            else
            {
                MessageBox.Show("Правое окно не содержит в себе информации. Сравнение будет происходить только на основе элементов из базы данных." +
                    "Если таких элементов не будет, придется вставить код в правое окно, иначе не с чем сравнивать", "Важное предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isEmpty = true;
            }



            //Работа с базой данных
            var listFromDB = FetchDataFromDB(symbolsCount, comboBoxLanguage.SelectedValue.ToString()); //ищем в базе данных подобные элементы
            foreach (var item in listFromDB) //добавляем каждый элемент
            {
                canonizedComparableCodes.Add(item.CanonizedCode); //добавляем канонизированный код в список
                codeCompare.Add(new Tokenizer(item.Language, item.CanonizedCode)); //Добавляем в список токенизированных кодов код из базы данных
            }
            if (codeCompare.Count == 0 && isEmpty)
            {
                MessageBox.Show("В базе данных не было обнаружено исходных кодов, которые могут удовлетворить условиям совпадения с языком и количеством символов.");
                return;
            }


            //Сравнение элементов
            Comparator cmp = new Comparator();
            List<List<float>> percents = new List<List<float>>(); //список процентов плагиата для каждого канонизированного кода

            //запускаем окно ожидания в отдельном потоке
            WaitingForm wf = new WaitingForm();
            Thread thread = new Thread(() =>
            {
                wf.ShowDialog();
            });
            thread.Start(); //запускаем поток - он будет работать пока не выполнятся операции ниже
            //Распараллеливаем процесс сравнения для каждого кода
            Parallel.For(0, codeCompare.Count, i =>
            {
                percents.Add(cmp.Compare(leftCode, leftCodeTokenShingles, leftCodeShingle, codeCompare[i], i));
            });
            //после выполнения операций окно ожидания надо закрыть
            wf.Invoke((MethodInvoker)(() =>
            {
                wf.Close();
            }));


            //Вывод результатов
            Results results = new Results(canonizedComparableCodes, percents);
            results.Show();
            float maxPercent = 0;
            foreach (var item in percents) //цикл для поиска наибольшего процента плагиата среди токенов
            {
                if (item[5] > maxPercent)
                    maxPercent = item[5];
            }


            labelPlagiatPercent.Text = "Текущее значение схожести: " + maxPercent + "%";

            if (plagiatPercentSetting > maxPercent)
            {
                labelPlagiat.Text = "Плагиат: Нет";
                DialogResult dr = MessageBox.Show("Вы хотите добавить код, размещенный в левом окне в базу данных?", "Добавление в базу данных", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    DBWorker worker = new DBWorker();
                    CodeInfo ci = new CodeInfo(canonizedCode, symbolsCount, comboBoxLanguage.SelectedValue.ToString(), DateTime.Now);
                    worker.InsertIntoDB(ci);
                }
            }
            else
            {
                MessageBox.Show("Плагиат кода обнаружен. Посмотрите окно с результатами для получения подробной информации", "Плагиат!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                labelPlagiat.Text = "Плагиат: Да";
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
                StringBuilder line = new StringBuilder(""); //временная переменная, в которую будет записываться строка, из которой будут удалены комментарии
                for (int i = 0; i < FCTBLeft.LinesCount; i++) //записываем каждую строку в Stringbuilder
                {
                    line.Append(Regex.Replace(FCTBLeft.Lines[i].ToString(), @"\/\*[\s\S]*?\*\/|([^:]|^)\/\/.*$", " "));
                    line.Append('\n');
                }
                //Лексер и парсер языков C и C++, поставляемые в ANTLR4 базово, имеют проблемы с распознаванием препроцессоров, поэтому лучше удалять символы, которые указывают на препроцессинг
                if (comboBoxLanguage.SelectedValue.ToString().Equals("C") || comboBoxLanguage.SelectedValue.ToString().Equals("C++"))
                    line.Replace("#", "");
                string canonizedCode = line.ToString();  //записываем в готовую строку с текстом результат удаления комментариев
                TokensReview window = new TokensReview(canonizedCode, comboBoxLanguage.Text);
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
        private List<CodeInfo> FetchDataFromDB(uint length, string language)
        {
            DBWorker worker = new DBWorker();
            return worker.Find(length, language);
        }
    }
}
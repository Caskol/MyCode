
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;


namespace MyCode
{
    public class Tokenizer
    {
        public char[] excludedChars = new char[] { '(', ' ', ')', '{', '}', '"', ';', ',', ':', '[', ']', '\r', '\n', '.' }; //исключаем из списка токенов ненужные символы (мусор при сравнении
        private string _language;
        private Lexer _lexer;
        //private ParserRuleContext _tree;
        private CommonTokenStream _cts;
        //private CharStreams _inputStream = null;
        /// <summary>
        /// int - номер строки, string - название токена, string - содержимое токена
        /// </summary>
        private List<Tuple<int, string, string>> _tokens = new List<Tuple<int, string, string>>();
        public string Language
        {
            get { return _language; }
        }
        public Lexer Lexer
        {
            get { return _lexer; }
        }
        public CommonTokenStream CTS
        {
            get { return _cts; }
        }

        public List<Tuple<int, string, string>> TokensArray
        {
            get { return _tokens; }
        }
        
        /// <summary>
        /// Конструктор класса Tokenizer. Создает экземпляр класса, содержащий в себе список токенов и дерево парса 
        /// </summary>
        /// <param name="language">Язык программирования, к которому привязан введенный текст</param>
        /// <param name="inputText">Введённый текст</param>
        public Tokenizer(string language, string inputText)
        {
            if (inputText.Length == 0)
            {
                throw new ArgumentException("Строка с текстом была пуста");
            }
            var _inputStream = CharStreams.fromString(inputText);
            //_inputStream = new AntlrInputStream(inputText); //преобразовываем текст в особый формат для ANTLR
            switch (language)
            {
                case "C":
                    {
                        _lexer = new CLexer(_inputStream); //создаем лексер на основе введенного текста
                        _cts = new CommonTokenStream(_lexer); //создаем поток токенов, полученных в результате работы лексера
                        _cts.Fill(); //заполняем его
                        break;
                    }
                case "C++":
                    {
                        _lexer = new CPP14Lexer(_inputStream);
                        _cts = new CommonTokenStream(_lexer);
                        _cts.Fill();
                        break;
                    }
                case "Pascal":
                    {
                        _lexer = new pascalLexer(_inputStream);
                        _cts = new CommonTokenStream(_lexer);
                        _cts.Fill();
                        break;
                    }
                case "Python":
                    {
                        _lexer = new Python3Lexer(_inputStream);
                        _cts = new CommonTokenStream(_lexer);
                        _cts.Fill();
                        break;
                    }
                case "Java":
                    {
                        _lexer = new Java9Lexer(_inputStream);
                        _cts = new CommonTokenStream(_lexer);
                        _cts.Fill();
                        break;
                    }
                case "C#":
                    {
                        _lexer = new CSharpLexer(_inputStream);
                        _cts = new CommonTokenStream(_lexer);
                        _cts.Fill();
                        break;
                    }
                default:
                    {
                        throw new ArgumentException("Программа не поддерживает такой язык программирования");
                    }
            }
            _language = language;
            if (_lexer != null && _cts != null)//если получилось создать лексер и поток токенов, то можно записать токены в список
            {
                foreach (var Token in _cts.GetTokens())
                    if (Token.Text.IndexOfAny(excludedChars) == -1 && Token.Text!="<EOF>") //если токен не содержит исключаемых символов, описанных в excludedChars
                        _tokens.Add(new Tuple<int, string, string>(Token.Line, _lexer.Vocabulary.GetSymbolicName(Token.Type), Token.Text));
            }
        }
        /// <summary>
        /// Метод для получения
        /// </summary>
        /// <returns>Строку без разделителей, состояющую из элементов, которые были получены при лексическом анализаторе (название токенов)</returns>
        public override string ToString()
        {
            try
            {
                StringBuilder sb = new StringBuilder("");
                foreach (var Token in _tokens)
                    sb.Append(Token.Item3);
                return sb.ToString();
            }
            catch (ArgumentNullException)
            {
                return "Cannot convert Tokenizer into string without tokens array";
            }
        }
        /// <summary>
        /// Метод для получения идентификаторов, полученных при токенизации.
        /// </summary>
        /// <returns></returns>
        public List<string> GetIdentificatorsList()
        {
            List<string> ids = new List<string>();
            try
            {
                foreach (var Token in _tokens)
                    ids.Add(Token.Item2);
                return ids;
            }
            catch (ArgumentNullException)
            {
                return ids;
            }
        }
        /// <summary>
        /// Метод, который превращает поток полученных идентификаторов в виде строки для поиска LCS
        /// </summary>
        /// <returns>Строка, содержащая последовательность идентификаторов, полученных при токенизации</returns>
        public string GetIdentificatorsString()
        {
            StringBuilder sb = new StringBuilder("");
            try
            {
                foreach (var Token in _tokens)
                    sb.Append(Token.Item2);
                return sb.ToString();
            }
            catch (ArgumentNullException)
            {
                return string.Empty;
            }
        }
    }
    public class Shingle
    {
        private string _canonizedCodeArrayInString;
        private List<string> _shingleList = new List<string>();
        public List<string> Shingles
        {
            get { return _shingleList; }
        }
        /// <summary>
        /// Конструктор класса, который принимает список идентификаторов из токенизатора а затем составляет из них список шинглов длиной n (по умолчанию n=4)
        /// </summary>
        /// <param name="tokenizer"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public Shingle (Tokenizer tokenizer,int n)
        {
            if (tokenizer==null)
            {
                throw new ArgumentNullException("Была попытка вызвать конструктор класса Shingle с пустым объектом класса Tokenizer.");
            }
            else
            {
                StringBuilder sb = new StringBuilder("");
                List<string> ids = tokenizer.GetIdentificatorsList(); //записываем в список все идентификаторы из токенизатора
                if (ids.Count < n)
                    throw new ArgumentException($"Количество токенов меньше чем длина шингла (т.е. {n}). При данном наборе данных невозможно узнать коэффициенты на основе шинглов (Жаккар и Сёренсен)");
                for (int i=0;i<ids.Count-n+1;i++)
                {
                    sb.Clear();
                    for (int j=i;j<i+n;j++)
                        sb.Append(ids[j]);
                    _shingleList.Add(sb.ToString());
                }
            }    
        }
        /// <summary>
        /// Конструктор класса, который принимает строку, которую разделяет на список шинглов
        /// </summary>
        /// <param name="input"></param>
        /// <exception cref="ArgumentException"></exception>
        public Shingle (string input)
        {
            if (input.Length < 2)
                throw new ArgumentException("Сравнение текстов при помощи метода шинглов недоступно, т.к. один из текстов содержит менее двух символов (требуется 2 и более)");
            _canonizedCodeArrayInString= input;
            for (int i = 0; i < _canonizedCodeArrayInString.Length-1; i++)
                _shingleList.Add(_canonizedCodeArrayInString.Substring(i, 2));
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("");
            try
            {
                foreach (var Shingle in Shingles)
                    sb.Append(Shingle);
                return sb.ToString();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
    public class Comparator
    {
        private float percentageTokens = 0;
        private float percentageShingles = 0;
        public float PercentTokens { get { return percentageTokens; } set { percentageTokens = value; } }
        public float PercentShingles { get { return percentageShingles; } set { percentageShingles = value; } }
        /// <summary>
        /// Алгоритм Вагнера-Фишера (расстояние Левенштейна). Количество операций вставок, удаления, которые необходимо сделать из одного текста чтобы получить другой
        /// </summary>
        /// <param name="array1">Массив токенов, полученных из первого текста</param>
        /// <param name="array2">Массив токенов, полученных из второго текста</param>
        /// <returns>Процент совпадения фрагментов</returns>
        public float LevenshteinDistance<T>(List<T> array1, List<T> array2)
        {
            if (array1.Count == 0 || array2.Count == 0)
                throw new ArgumentNullException("Как минимум один из сравниваемых массивов был пустым");
            ushort stepCount = 0;
            ushort[] row1 = new ushort[array2.Count+1];//нам не нужно хранить все строки
            ushort[] row2 = new ushort[array2.Count+1];
            for (int i = 1; i < array1.Count+1; i++) //строки
            {
                row1[0] = (ushort)(i - 1);
                row2[0] = (ushort)i;
                for (int j = 1; j<array2.Count + 1;j++)
                {
                    if (i - 1 == 0) //если это первая итерация основного цикла
                        row1[j] = (ushort)j;
                    else
                    {
                        if (array1 is List<Tuple<int, string, string>> tokens1 && array2 is List<Tuple<int, string, string>> tokens2) //преобразовываем T в тип Tuple
                        {
                            if (!string.Equals(tokens1[i - 1].Item2, tokens2[j - 1].Item2)) //если i-й токен первого массива не совпадает с j-м токеном второго массива
                                row2[j]=(ushort)Math.Min(Math.Min(row1[j] + 1, row2[j - 1] + 1), row1[j - 1] + 1);// D(1,1) = Min (D(0,1)+1, D(1,0)+1,D(0,0)+1)
                             else
                                row2[j] = (ushort)Math.Min(Math.Min(row1[j] + 1, row2[j - 1] + 1), row1[j - 1]);// D(1,1) = Min (D(0,1)+1, D(1,0)+1,D(0,0))
                        }
                        else if (typeof(T) == typeof(string))
                        {
                            if (!string.Equals(array1[i - 1], array2[j - 1])) //если i-й шингл первого массива не совпадает с j-м шинглом второго массива
                                row2[j] = (ushort)Math.Min(Math.Min(row1[j] + 1, row2[j - 1] + 1), row1[j - 1] + 1);// D(1,1) = Min (D(0,1)+1, D(1,0)+1,D(0,0)+1)
                            else
                                row2[j] = (ushort)Math.Min(Math.Min(row1[j] + 1, row2[j - 1] + 1), row1[j - 1]);// D(1,1) = Min (D(0,1)+1, D(1,0)+1,D(0,0))
                        }
                        else
                            throw new ArgumentException("Как минимум один из переданных списков не содержит объектов типа string или Tuple");
                    }
                }
                Array.Copy(row2, row1, row1.Length);//копируем второй ряд и вставляем его вместо первого
            }
            stepCount = row2.Last();
            return 1 - (float)stepCount / (float)Math.Max(array1.Count, array2.Count);
        }
        /// <summary>
        /// Коэффициент Жаккара для вычисления степени схожести двух массивов. Используется сравнение уникальных элементов
        /// </summary>
        /// <param name="array1">Массив элементов (токены или шинглы), полученных из первого текста</param>
        /// <param name="array2">Массив элементов (токены или шинглы), полученных из второго текста</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public float JaccardCoefficient(List<string> array1, List<string> array2)
        {
            if (array1.Count == 0 || array2.Count == 0)
                throw new ArgumentNullException("Как минимум один из переданных списков не содержит объектов типа string или Tuple");
            int intersection, union;
            var hashedArray1 = new HashSet<string>(array1);//убираем повторяющиеся элементы
            var hashedArray2 = new HashSet<string>(array2);
            intersection = hashedArray1.Intersect(hashedArray2).Count(); //получаем значение пересечения двух массивов между собой (т.е. количество элементов, которые присутствуют в обоих массивах)
            union = array1.Union(array2).Count();//получаем значение объединения двух массивов между собой (т.е. общее количество элементов)
            return (float)intersection / union;
        }
        /// <summary>
        /// Коэффициент Сёренсена-Дайса для вычисления схожести двух массивов.
        /// </summary>
        /// <param name="array1">Список шинглов, полученных из первого текста</param>
        /// <param name="array2">Список шинглов, полученных из второго текста</param>
        /// <returns></returns>
        public float SorensenDiceCoefficient(List<string> gramms1, List<string> gramms2)
        {
            if (gramms1.Count == 0 || gramms2.Count == 0)
                throw new ArgumentNullException("Как минимум один из переданных списков не содержит объектов типа string");
            var hashedGramms1 = new HashSet<string>(gramms1);
            var hashedGramms2 = new HashSet<string>(gramms2);
            var intersection = hashedGramms1.Intersect(hashedGramms2).Count();
            var total = hashedGramms1.Count + hashedGramms2.Count;
            hashedGramms1 = null;
            hashedGramms2 = null;
            return (float)(2 * intersection) / total;
        }
        /// <summary>
        /// Коэффициент схожести на основе количества символов, входящих в наибольную общую подпоследовательность (LCS)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public float LongestCommonSubsequence(string x, string y)
        {
            if (x.Length <= 0 || y.Length <= 0)
                throw new ArgumentNullException("Одна из строк была пуста");
            ushort[] row1 = new ushort[y.Length + 1];
            ushort[] row2 = new ushort[y.Length + 1];
            for (int i=1;i<x.Length+1;i++)
            {
                row1[0] = 0;
                row2[0] = 0;
                for (int j = 1; j < y.Length + 1; j++) //столбец y
                {
                    if (y[j - 1].Equals(x[i - 1])) //если j-й элемент строки совпадает с i-м элементов столбца
                        row2[j] = (ushort)(row1[j - 1] + 1);//если совпадает, то берем значения из диагональной ячейки и прибавляем 1
                    else
                        row2[j] = Math.Max(row1[j], row2[j - 1]);//если не совпадает, то берем максимальный из значений левого символа или верхнего символа
                }
                Array.Copy(row2 , row1, row2.Length);
            }
            //сами подпоследовательности нас не интересуют, т.к. необходимо найти коэффициент схожести, а не само сходство. Это будет количество совпадений, деленное на длину текста максимальной длины
            int lcsLength = row2.Last(); //берем самый последний элемент
            return (float)lcsLength / Math.Max(x.Length, y.Length); //и возвращаем его, поделив на длину текста
        }

        public List<float> Compare(Tokenizer leftCode, List<string> leftCodeTokenShingles, Shingle leftCodeShingles, Tokenizer rightCode, int order)
        {
            List<float> result = new List<float>() { order };//создаем список результатов и помещаем номер сравниваемого текста
            //ТОКЕНЫ    
            float levenshteinToken = LevenshteinDistance(leftCode.TokensArray, rightCode.TokensArray);
            float jaccardToken = -1, diceToken = -1;
            try
            {
                jaccardToken = JaccardCoefficient(leftCodeTokenShingles, new Shingle(rightCode, 4).Shingles); //создаем k-граммы из идентификатор, причем k=4
                diceToken = SorensenDiceCoefficient(leftCodeTokenShingles, new Shingle(rightCode, 4).Shingles);
            }
            catch (Exception) { }
            float lcsToken = LongestCommonSubsequence(leftCode.GetIdentificatorsString(), rightCode.GetIdentificatorsString());
            if (jaccardToken == -1 && diceToken == -1)
                PercentTokens = (levenshteinToken + lcsToken) / 2 * 100;
            else
                PercentTokens = (levenshteinToken + jaccardToken + diceToken + lcsToken) / 4 * 100;
            result.Add(levenshteinToken*100);
            result.Add(jaccardToken*100);
            result.Add(diceToken*100);
            result.Add(lcsToken*100);
            result.Add(PercentTokens);
            GC.Collect();

            //ШИНГЛЫ
            Shingle right = null;
            float levenshteinShingle=-1, jaccardShingle=-1, diceShingle=-1, lcsShingle=-1;
            try
            {
                right = new Shingle(rightCode.ToString());
            }
            catch (ArgumentException) { }
            if (leftCodeShingles != null && right != null)
            {
                levenshteinShingle = LevenshteinDistance(leftCodeShingles.Shingles, right.Shingles);
                jaccardShingle = JaccardCoefficient(leftCodeShingles.Shingles, right.Shingles);
                diceShingle = SorensenDiceCoefficient(leftCodeShingles.Shingles, right.Shingles);
                lcsShingle = LongestCommonSubsequence(leftCodeShingles.ToString(), right.ToString());
                PercentShingles = (levenshteinShingle + jaccardShingle + diceShingle + lcsShingle) / 4 * 100;
            }
            result.Add(levenshteinShingle*100);
            result.Add(jaccardShingle*100);
            result.Add(diceShingle*100);
            result.Add(lcsShingle*100);
            result.Add(PercentShingles);
            GC.Collect();
            return result;
        }
    }
}

﻿
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;


namespace MyCode
{
    public enum ProgrammingLanguages : byte
    {
        C,
        Cpp,
        CSharp,
        Java,
        Pascal,
        Python
    }
    public class Tokenizer
    {
        private char[] excludedChars = new char[] { '(', ' ', ')', '{', '}', '"', ';', ',', ':', '[', ']', '\r', '\n', '.' }; //исключаем из списка токенов ненужные символы (мусор при сравнении
        public ProgrammingLanguages Language { get; private set; }
        public Lexer? Lexer { get; private set; }
        public CommonTokenStream? CTS { get; private set; }
        /// <summary>
        /// int - номер строки, string - название токена, string - содержимое токена
        /// </summary>
        public List<Tuple<int, string, string>> TokensArray { get; private set; }
        
        /// <summary>
        /// Конструктор класса Tokenizer. Создает экземпляр класса, содержащий в себе список токенов и дерево парса 
        /// </summary>
        /// <param name="language">Язык программирования, к которому привязан введенный текст</param>
        /// <param name="inputText">Введённый текст</param>
        public Tokenizer(ProgrammingLanguages language, string inputText)
        {
            if (inputText.Length == 0)
            {
                throw new ArgumentException("Строка с текстом была пуста");
            }
            TokensArray = new List<Tuple<int, string, string>>();
            var inputStream = CharStreams.fromString(inputText);
            switch (language)
            {
                case ProgrammingLanguages.C:
                    {
                        Lexer = new CLexer(inputStream); //создаем лексер на основе введенного текста
                        CTS = new CommonTokenStream(Lexer); //создаем поток токенов, полученных в результате работы лексера
                        CTS.Fill(); //заполняем его
                        break;
                    }
                case ProgrammingLanguages.Cpp:
                    {
                        Lexer = new CPP14Lexer(inputStream);
                        CTS = new CommonTokenStream(Lexer);
                        CTS.Fill();
                        break;
                    }
                case ProgrammingLanguages.Pascal:
                    {
                        Lexer = new pascalLexer(inputStream);
                        CTS = new CommonTokenStream(Lexer);
                        CTS.Fill();
                        break;
                    }
                case ProgrammingLanguages.Python:
                    {
                        Lexer = new Python3Lexer(inputStream);
                        CTS = new CommonTokenStream(Lexer);
                        CTS.Fill();
                        break;
                    }
                case ProgrammingLanguages.Java:
                    {
                        Lexer = new Java9Lexer(inputStream);
                        CTS = new CommonTokenStream(Lexer);
                        CTS.Fill();
                        break;
                    }
                case ProgrammingLanguages.CSharp:
                    {
                        Lexer = new CSharpLexer(inputStream);
                        CTS = new CommonTokenStream(Lexer);
                        CTS.Fill();
                        break;
                    }
                default:
                    {
                        throw new ArgumentException("Программа не поддерживает такой язык программирования");
                    }
            }
            Language = language;
            if (Lexer != null && CTS != null)//если получилось создать лексер и поток токенов, то можно записать токены в список
            {
                foreach (var Token in CTS.GetTokens())
                    if (Token.Text.IndexOfAny(excludedChars) == -1 && Token.Text!="<EOF>") //если токен не содержит исключаемых символов, описанных в excludedChars
                        TokensArray.Add(new Tuple<int, string, string>(Token.Line, Lexer.Vocabulary.GetSymbolicName(Token.Type), Token.Text));
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
                foreach (var Token in TokensArray)
                    sb.Append(Token.Item3);
                return sb.ToString();
            }
            catch (ArgumentNullException)
            {
                return "Cannot convert empty Tokenizer into string";
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
                foreach (var Token in TokensArray)
                    ids.Add(Token.Item2);
                return ids;
            }
            catch (ArgumentNullException)
            {
                return ids;
            }
        }
    }
    public class Shingle
    {
        private string _canonizedCodeArrayInString;
        public List<string> Shingles { get; private set; }
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
                Shingles = new List<string>();
                StringBuilder sb = new StringBuilder("");
                List<string> ids = tokenizer.GetIdentificatorsList(); //записываем в список все идентификаторы из токенизатора
                if (ids.Count < n)
                    throw new ArgumentException($"Количество токенов меньше чем длина шингла (т.е. {n}). При данном наборе данных невозможно узнать коэффициенты на основе шинглов (Жаккар и Сёренсен)");
                for (int i=0;i<ids.Count-n+1;i++)
                {
                    sb.Clear();
                    for (int j=i;j<i+n;j++)
                        sb.Append(ids[j]);
                    Shingles.Add(sb.ToString());
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
            Shingles = new List<string>();
            if (input.Length < 2)
                throw new ArgumentException("Сравнение текстов при помощи метода шинглов недоступно, т.к. один из текстов содержит менее двух символов (требуется 2 и более)");
            _canonizedCodeArrayInString= input;
            for (int i = 0; i < _canonizedCodeArrayInString.Length-1; i++)
                Shingles.Add(_canonizedCodeArrayInString.Substring(i, 2));
        }
    }
    public class Comparator
    {
        public float PercentTokens { get; private set; }
        public float PercentShingles { get; private set; }
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
            ushort[] row1 = new ushort[array2.Count+1];//нам не нужно хранить все строки
            ushort[] row2 = new ushort[array2.Count+1];
            for (int i = 1; i < array1.Count+1; i++) //строки
            {
                row1[0] = (ushort)(i - 1);
                row2[0] = (ushort)i;
                if (i - 1 == 0) //если это первая итерация, то первую строку нужно заполнить порядковыми номерами
                    for (int j=1;j<array2.Count+1;j++)
                        row1[j]=(ushort)j;
                for (int j = 1; j<array2.Count + 1;j++)
                {
                    if (array1 is List<Tuple<int, string, string>> tokens1 && array2 is List<Tuple<int, string, string>> tokens2) //преобразовываем T в тип Tuple
                    {
                        if (!string.Equals(tokens1[i - 1].Item2, tokens2[j - 1].Item2)) //если i-й токен первого массива не совпадает с j-м токеном второго массива
                            row2[j] = (ushort)Math.Min(Math.Min(row1[j] + 1, row2[j - 1] + 1), row1[j - 1] + 1);// D(1,1) = Min (D(0,1)+1, D(1,0)+1,D(0,0)+1)
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
                Array.Copy(row2, row1, row1.Length);//копируем второй ряд и вставляем его вместо первого
            }
            return 1 - row2.Last() / (float)Math.Max(array1.Count, array2.Count);
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
        /// <returns></returns>
        public float SorensenDiceCoefficient(List<string> gramms1, List<string> gramms2)
        {
            if (gramms1.Count == 0 || gramms2.Count == 0)
                throw new ArgumentNullException("Как минимум один из переданных списков не содержит объектов типа string");
            var hashedGramms1 = new HashSet<string>(gramms1);
            var hashedGramms2 = new HashSet<string>(gramms2);
            var intersection = hashedGramms1.Intersect(hashedGramms2).Count();
            var total = hashedGramms1.Count + hashedGramms2.Count;
            return (float)(2 * intersection) / total;
        }
        /// <summary>
        /// Коэффициент схожести на основе количества символов, входящих в наибольную общую подпоследовательность (LCS)
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public float LongestCommonSubsequence<T>(List<T> array1, List<T> array2)
        {
            if (array1.Count == 0 || array2.Count == 0)
                throw new ArgumentNullException("Как минимум один из сравниваемых массивов был пустым");
            ushort[] row1 = new ushort[array2.Count + 1];
            ushort[] row2 = new ushort[array2.Count + 1];
            for (int i=1;i<array1.Count+1;i++)
            {
                row1[0] = 0;
                row2[0] = 0;
                for (int j = 1; j < array2.Count + 1; j++) //столбец y
                {
                    if (array1 is List<Tuple<int, string, string>> tokens1 && array2 is List<Tuple<int, string, string>> tokens2) //преобразовываем T в тип Tuple
                    {
                        if (!string.Equals(tokens1[i - 1].Item2, tokens2[j - 1].Item2)) //если i-й токен первого массива не совпадает с j-м токеном второго массива
                            row2[j] = Math.Max(row1[j], row2[j - 1]);// то берем максимальный из значений левого символа или верхнего символа
                        else
                            row2[j] = (ushort)(row1[j-1]+1);// если совпадает, то берем значения из диагональной ячейки и прибавляем 1
                    }
                    else if (typeof(T) == typeof(string))
                    {
                        if (!string.Equals(array1[i - 1], array2[j - 1])) //если i-й шингл первого массива не совпадает с j-м шинглом второго массива
                            row2[j] = Math.Max(row1[j], row2[j - 1]);//то берем максимальный из значений левого символа или верхнего символа
                        else
                            row2[j] = (ushort)(row1[j - 1] + 1);// если совпадает, то берем значения из диагональной ячейки и прибавляем 1
                    }
                    else
                        throw new ArgumentException("Как минимум один из переданных списков не содержит объектов типа string или Tuple");
                }
                Array.Copy(row2 , row1, row2.Length);
            }
            //сами подпоследовательности нас не интересуют, т.к. необходимо найти коэффициент схожести, а не само сходство. Это будет количество совпадений, деленное на длину текста максимальной длины
            return (float)row2.Last() / Math.Max(array1.Count, array2.Count); //делим значение самого последнего элемента на максимальную длину текста
        }

        public List<float> Compare(Tokenizer leftCode, List<string> leftCodeTokenShingles, Shingle leftCodeShingles, Tokenizer rightCode, int order)
        {
            List<float> result = new List<float>() { order };//создаем список результатов и помещаем номер сравниваемого текста
            //ТОКЕНЫ    
            float levenshteinToken = LevenshteinDistance(leftCode.TokensArray, rightCode.TokensArray);
            float? jaccardToken = null, diceToken = null; //nullable структура если следующий участок кода не выполнится
            try
            {
                jaccardToken = JaccardCoefficient(leftCodeTokenShingles, new Shingle(rightCode, 3).Shingles); //создаем k-граммы из идентификатор, причем k=3
                diceToken = SorensenDiceCoefficient(leftCodeTokenShingles, new Shingle(rightCode, 3).Shingles);
            }
            catch (Exception) { }
            float lcsToken = LongestCommonSubsequence(leftCode.TokensArray, rightCode.TokensArray);
            if (jaccardToken.HasValue && diceToken.HasValue)
                PercentTokens = (levenshteinToken + jaccardToken.Value + diceToken.Value + lcsToken) / 4 * 100;
            else
                PercentTokens = (levenshteinToken + lcsToken) / 2 * 100;
            result.Add(levenshteinToken*100);
            result.Add(jaccardToken.HasValue ? jaccardToken.Value*100 : 0);
            result.Add(diceToken.HasValue ? diceToken.Value*100 : 0);
            result.Add(lcsToken*100);
            result.Add(PercentTokens);
            GC.Collect();

            //ШИНГЛЫ
            Shingle right = null;
            float? levenshteinShingle=null, jaccardShingle=null, diceShingle=null, lcsShingle=null; //nullable структура
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
                lcsShingle = LongestCommonSubsequence(leftCodeShingles.Shingles, right.Shingles);
                PercentShingles = (levenshteinShingle.Value + jaccardShingle.Value + diceShingle.Value + lcsShingle.Value) / 4 * 100;
            }
            result.Add(levenshteinShingle.HasValue ? levenshteinShingle.Value * 100 : 0);
            result.Add(jaccardShingle.HasValue ? jaccardShingle.Value * 100 : 0);
            result.Add(diceShingle.HasValue ? diceShingle.Value * 100 : 0);
            result.Add(lcsShingle.HasValue ? lcsShingle.Value * 100 : 0);
            result.Add(PercentShingles);
            GC.Collect();
            return result;
        }
    }
}

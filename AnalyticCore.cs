
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System.Collections.Generic;
using System.Text;


namespace MyCode
{
    public class Tokenizer
    {
        public char[] excludedChars = new char[] { '(', ' ', ')', '{', '}', '"', ';', ',', ':', '[', ']', '\r', '\n', '.' }; //исключаем из списка токенов ненужные символы (мусор при сравнении
        private string _language;
        private Lexer _lexer;
        private Parser _parser;
        private ParserRuleContext _tree;
        private CommonTokenStream _cts;
        private AntlrInputStream _inputStream;
        private string _tokenArrayInString;
        private List<string> _ngrams = new List<string>();
        /// <summary>
        /// int - номер строки, string - название токена, string - содержимое токена
        /// </summary>
        private List<Tuple<int,string,string>> _tokens = new List<Tuple<int, string, string>>();
        public string Language
        {
            get { return _language; }
        }
        public Lexer Lexer
        {
            get { return _lexer; }
        }
        public Parser Parser
        {
            get { return _parser; }
        }
        public CommonTokenStream CTS
        {
            get { return _cts; }
        }
        
        public List<Tuple<int, string, string>> TokensArray
        {
            get { return _tokens; }
        }
        public List<string> NGramms
        {
            get { return _ngrams; }
        }
        public AntlrInputStream InputStream
        {
            get { return _inputStream; }
        }
        /// <summary>
        /// Конструктор класса Tokenizer. Создает экземпляр класса, содержащий в себе список токенов и дерево парса 
        /// </summary>
        /// <param name="language">Язык программирования, к которому привязан введенный текст</param>
        /// <param name="inputText">Введённый текст</param>
        public Tokenizer(string language, string inputText) 
        {
            _inputStream = new AntlrInputStream(inputText); //преобразовываем текст в особый формат для ANTLR
            switch (language)
            {
                case "C":
                    {
                        _lexer = new CLexer(_inputStream); //создаем лексер на основе введенного текста
                        _cts = new CommonTokenStream(_lexer); //создаем поток токенов, полученных в результате работы лексера
                        _cts.Fill(); //заполняем его
                        //_parser = new CParser(_cts) { BuildParseTree = true }; //создаем парсер, чтобы получить дерево парса
                        //_tree = ((CParser)_parser).translationUnit(); // получаем дерево парса
                        break;
                    }
                case "C++":
                    {
                        _lexer = new CPP14Lexer(_inputStream);
                        _cts = new CommonTokenStream(_lexer);
                        _cts.Fill();
                        //_parser = new CPP14Parser(_cts) { BuildParseTree = true };
                        //_tree = ((CPP14Parser)_parser).translationUnit(); // получаем дерево парса
                        break;
                    }
                case "Pascal":
                    {
                        _lexer = new pascalLexer(_inputStream);
                        _cts = new CommonTokenStream(_lexer);
                        _cts.Fill();
                        //_parser = new pascalParser(_cts) { BuildParseTree = true };
                        //_tree = ((pascalParser)_parser).program(); // получаем дерево парса
                        break;
                    }
                case "Python":
                    {
                        _lexer = new Python3Lexer(_inputStream);
                        _cts = new CommonTokenStream(_lexer);
                        _cts.Fill();
                        //_parser = new Python3Parser(_cts) { BuildParseTree = true };
                        //_tree = ((Python3Parser)_parser).file_input(); // получаем дерево парса
                        break;
                    }
                case "Java":
                    {
                        _lexer = new Java9Lexer(_inputStream);
                        _cts = new CommonTokenStream(_lexer);
                        _cts.Fill();
                        //_parser = new Java9Parser(_cts) { BuildParseTree = true };
                        //_tree = ((Java9Parser)_parser).compilationUnit(); // получаем дерево парса
                        break;
                    }
                case "C#":
                    {
                        _lexer = new CSharpLexer(_inputStream);
                        _cts = new CommonTokenStream(_lexer);
                        _cts.Fill();
                        //_parser = new CSharpParser(_cts) { BuildParseTree = true };
                        //_tree = ((CSharpParser)_parser).compilation_unit(); // получаем дерево парса
                        break;
                    }
            }
            if (_lexer != null && _cts != null)//если получилось создать лексер и поток токенов, то можно записать токены в список
            {
                foreach (var Token in _cts.GetTokens())
                    if (Token.Text.IndexOfAny(excludedChars) == -1) //если токен не содержит исключаемых символов, описанных в excludedChars
                        _tokens.Add(new Tuple<int, string, string>(Token.Line, _lexer.Vocabulary.GetSymbolicName(Token.Type), Token.Text));
                _tokenArrayInString = this.ToString();
                CreateNGramms();
            }
        }
        public override string ToString()
        {
            try
            {
                StringBuilder sb = new StringBuilder("");
                foreach (var Token in _tokens)
                    sb.Append(Token.Item2);
                return sb.ToString();
            }
            catch (ArgumentNullException ex)
            {
                return "Can't convert Tokenizer into string without tokens array";
            }
        }
        private void CreateNGramms()
        {
            try
            {
                for (int i=0;i< _tokenArrayInString.Length;i++)
                    _ngrams.Add(_tokenArrayInString.Substring(i, 2));
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
        public class Comparator
    {
        private float percentage;
        public float Percent { get { return percentage; } }
        /// <summary>
        /// Алгоритм Вагнера-Фишера (расстояните Левенштейна)
        /// </summary>
        /// <param name="tokensArray1">Массив токенов, полученных из первого текста</param>
        /// <param name="tokensArray2">Массив токенов, полученных из второго текста</param>
        /// <returns>Процент совпадения фрагментов</returns>
        public float LevenshteinDistance(List<Tuple<int, string, string>> tokensArray1, List<Tuple<int, string, string>> tokensArray2)
        {
            if (tokensArray1 != null || tokensArray2 != null)
            {
                percentage = 0; //переменная, которая будет хранить информацию о проценте сходства текста
                int[,] LevenshteinArray = new int[tokensArray1.Count, tokensArray2.Count];
                for (int i = 0; i < tokensArray1.Count; i++) //столбец
                {
                    LevenshteinArray[i, 0] = i;//первый столбец заполняем порядковыми цифрами 
                    for (int j = 1; j < tokensArray2.Count; j++) //строка
                    {
                        if (i == 0) //если идёт первый столбец, то заполняем его порядковыми цифрами
                            LevenshteinArray[i, j] = j;//первый столбец заполняем порядковыми цифрами 
                        else
                        {
                            if (!string.Equals(tokensArray1[i - 1].Item2, tokensArray2[j-1].Item2)) //если i-й токен первого массива не совпадает с j-м токеном второго массива
                            //if (!tokensArray1[i - 1].Item2.Equals(tokensArray2[j-1].Item2)) 
                            //if (!text1[i - 1].Equals(text2[j - 1])) //если i-ый символ из первой строки  НЕ совпадает с j-ым символом второй строки
                                LevenshteinArray[i, j] = Math.Min(Math.Min(LevenshteinArray[i - 1, j] + 1, LevenshteinArray[i, j - 1] + 1), LevenshteinArray[i - 1, j - 1] + 1);// D(1,1) = Min (D(0,1)+1, D(1,0)+1,D(0,0)+1)
                            else
                                LevenshteinArray[i, j] = Math.Min(Math.Min(LevenshteinArray[i - 1, j] + 1, LevenshteinArray[i, j - 1] + 1), LevenshteinArray[i - 1, j - 1]);// D(1,1) = Min (D(0,1)+1, D(1,0)+1,D(0,0))
                        }
                    }
                }
                int stepCount = LevenshteinArray[tokensArray1.Count - 1, tokensArray2.Count - 1];
                percentage = (1 - (float)stepCount / (float)Math.Max(tokensArray1.Count, tokensArray2.Count)) * 100;
            }
            else
            {
                throw new ArgumentNullException("Одна из сравниваемых строк была пустой");
            }
            return percentage;
        }
        /// <summary>
        /// Коэффициент Жаккара для вычисления степени схожести двух массивов
        /// </summary>
        /// <param name="tokensArray1">Массив токенов, полученных из первого текста</param>
        /// <param name="tokensArray2">Массив токенов, полученных из второго текста</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public float JaccardCoefficient(List<string> gramms1, List<string> gramms2)
        {
            if (gramms1 != null || gramms2 != null)
            {
                var hashedGramms1 = new HashSet<string>(gramms1);
                var hashedGramms2 = new HashSet<string>(gramms2);
                var intersection = gramms1.Intersect(gramms2).Count(); //получаем значение пересечения двух массивов между собой (т.е. количество элементов, которые присутствуют в обоих массивах)
                var union = gramms1.Union(gramms2).Count();//получаем значние объединения двух массивов между собой (т.е. общее количество элементов)
                percentage = (float)intersection/ union;
            }
            else
            {
                throw new ArgumentNullException("Одна из сравниваемых строк была пустой");
            }
            return percentage;
        }
        /// <summary>
        /// Коэффициент Сёренсена-Дайса для вычисления схожести двух массивов
        /// </summary>
        /// <param name="tokensArray1">Массив токенов, полученных из первого текста</param>
        /// <param name="tokensArray2">Массив токенов, полученных из второго текста</param>
        /// <returns></returns>
        public float SorensenDiceCoefficient(List<string> gramms1, List<string> gramms2)
        {
            var hashedGramms1 = new HashSet<string>(gramms1);
            var hashedGramms2 = new HashSet<string>(gramms2);
            var intersection = hashedGramms1.Intersect(hashedGramms2).Count();
            var total = hashedGramms1.Count + hashedGramms2.Count;

            return (float)(2 * intersection) / total;
        }
    }
}

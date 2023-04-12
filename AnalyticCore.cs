
using System.Text;
using System.Text.RegularExpressions;
using Antlr4.Runtime;

public enum TokenTypes
{
    Keyword, //ключевые слова по типу using, namespace,internal,class и т.д.
    Cycle, //слова, означающие начало цикла
    Operator, //операторы унарные и прочие
    DataType, //тип данных int bool и т.д.
    Number, //числа (константы)
    Variable //переменные
}

namespace MyCode
{

    public class Tokenizer
    {
        private List<Token> ListOfTokens = new List<Token>();
        private static Regex regex;
        public string TokenizedString = null;
        //CodeCompileUnit ccu = new CodeCompileUnit();
        static Dictionary<TokenTypes, string> TokenTypesRegEx = new Dictionary<TokenTypes, string>()
        {
            // \b используется для того, чтобы не было путаницы с определением ключевого слова например в переменной basic, где as - могло бы быть воспринято в качестве ключевого слова
            {TokenTypes.Keyword, "(\\babstract\\b|\\bas\\b|\\bbase\\b|\\bbreak\\b|\\bcase\\b|\\bcatch\\b|\\bchecked\\b|\\bclass\\b|\\bconst\\b|\\bcontinue\\b|\\bdefault\\b|\\bdelegate\\b|\\belse\\b|\\benum\\b|\\bevent\\b|\\bexplicit\\b|\\bextern\\b|\\bfalse\\b|\\bfinally\\b|\\bfixed\\b|\\bgoto\\b|\\bif\\b|\\bimplicit\\b|\\bin\\b|\\binterface\\b|\\binternal\\b|\\bis\\b|\\block\\b|\\bnamespace\\b|\\bnew\\b|\\bnull\\b|\\bobject\\b|\\boperator\\b|\\bout\\b|\\boverride\\b|\\bparams\\b|\\bprivate\\b|\\bprotected\\b|\\bpublic\\b|\\breadonly\\b|\\bref\\b|\\breturn\\b|\\bsealed\\b|\\bsizeof\\b|\\bstack\\b|\\balloc\\b|\\bstatic\\b|\\bstruct\\b|\\bswitch\\b|\\bthis\\b|\\bthrow\\b|\\btrue\\b|\\btry\\b|\\btypeof\\b|\\bunchecked\\b|\\bunsafe\\b|\\bushort\\b|\\busing\\b|\\bvirtual\\b|\\bvoid\\b|\\bvolatile\\b)"},
            {TokenTypes.Cycle,"(\\bfor\\b|\\bdo\\b|\\bwhile\\b|\\bforeach\\b)" },
            {TokenTypes.DataType, "(\\bbool\\b|\\bbyte\\b|\\bchar\\b|\\bdecimal\\b|\\bdouble\\b|\\bfloat\\b|\\bint\\b|\\blong\\b|\\bsbyte\\b|\\bshort\\b|\\bstring\\b|\\buint\\b|\\bulong\\b)" }, //набор базовых типов данных C#
            {TokenTypes.Operator, "([\\+]|[-]|[\\*]|[\\/]|[=]|[%]|[>]|[<]|[!]|[~]|[&]|[|]|[\\^])" }, //все УНАРНЫЕ знаки операций
            {TokenTypes.Number, "-?[0-9]+[.]?[0-9]*" }, //регулярное выражение для чисел (поддерживаются отрицательные и дробные числа)
            {TokenTypes.Variable,  "[a-zA-Zа-яА-Я]+\\w*"} //регулярное выражение для определения названия переменных
        };

        /// <summary>
        /// Функция разбиения текста на токены
        /// </summary>
        /// <param name="text">Строка, которую необходимо токенизировать</param>
        public void Tokenize(string text)
        {
            //ccu.Parse
            StringBuilder sb = new StringBuilder(text);
            foreach (TokenTypes type in TokenTypesRegEx.Keys)
            {
                regex = new Regex(@$"{TokenTypesRegEx[type]}"); //создаем regex с паттерном по циклу
                MatchCollection mc = regex.Matches(sb.ToString()); //инициализируем коллекцию совпадений, полученных при выполнении поиска в тексте
                foreach (Match m in mc)
                {
                    //Для каждого совпадения данного типа создаем новый токен и добавляем его в список. Этот список находится в массиве под номером, равным номеру строки
                    ListOfTokens.Add(new Token(type, m.Value, m.Index));
                    //после добавления токена просто очищаем информацию о нем в исходном тексте
                    sb=sb.Remove(m.Index,m.Value.Length); // заменяем совпавший элемент на пробелы (например совпавшее слово из 3-х букв заменится на 3 пробела)
                    sb = sb.Insert(m.Index, new string('.', m.Value.Length));
                }
            }
            ListOfTokens.Sort(); //сортируем токены
            try
            {
                TokenizedString = SimplifyTokens();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }
        }
        /// <summary>
        /// Функция для генерации упрощенного 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public string SimplifyTokens()
        {
            string output;//конечная строка с упрощенным списком токенов
            if (ListOfTokens == null)
                throw new ArgumentNullException("Сначала нужно создать токены");
            else
            {
                StringBuilder sb = new StringBuilder(); //создаем динамический генератор строки
                foreach (Token token in ListOfTokens) //для каждого токена составляем свое упрощенное название
                {
                    try
                    {
                        sb.Append(SimplifyTokenTypes(token.GetType));
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                        return null;
                    }
                }
                output = sb.ToString();
            }
            return output;
        }
        private char SimplifyTokenTypes(TokenTypes type)
        {
            switch (type) 
            {
                case TokenTypes.Keyword:
                    return 'K';
                case TokenTypes.Cycle:
                    return 'C';
                case TokenTypes.Operator:
                    return 'O';
                case TokenTypes.DataType:
                    return 'D';
                case TokenTypes.Number:
                    return 'N';
                case TokenTypes.Variable:
                    return 'V';
                default:
                    throw new ArgumentException("Несуществующий тип токена");
            }
        }    
    }
    public class Token : IComparable
    {
        private TokenTypes Type; //тип токена
        private string Data; //содержимое токена
        private int Index; //индекс символа строки, на которой был найден токен
        /// <summary>
        /// Реализация сравнения двух токенов для верной работы функции Sort у списка
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public int CompareTo(object obj)
        {
            if (obj == null)
                throw new ArgumentException("Попытка сравнить пустой объект");
            Token otherToken = obj as Token; //принимаем объект ТОЛЬКО в виде токена

            if (this.Index < otherToken.Index) //если индекс текущего токена меньше индекса другого токена
                return -1; //то текущий токен должен быть спереди
            else if (this.Index == otherToken.Index)
                return 0; //не имеет значения
            else
                return 1; //текущий токен должен стоять после
        }
        public TokenTypes GetType { get { return Type; } }
        internal Token(TokenTypes type, string data,int index)
        {
            Type = type;
            Data = data;
            Index = index;
        }
    }
    public class Comparator
    {
        private float percentage;
        public float Percent { get { return percentage; } }
        /// <summary>
        /// Основной алгоритм сравнения схожести текстов - алгоритм Вагнера-Фишера
        /// </summary>
        /// <param name="text1">Первый сравниваемый фрагмент текста</param>
        /// <param name="text2">Второй сравниваемый фрагмент текста</param>
        /// <returns>Процент совпадения фрагментов</returns>
        public void LevenshteinDistance(string text1, string text2)
        {
            if (text1 != null || text2 != null)
            {
                percentage = 0; //переменная, которая будет хранить информацию о проценте сходства текста
                int[,] LevenshteinArray = new int[text1.Length, text2.Length];
                for (int i = 0; i < text1.Length; i++) //столбец
                {
                    LevenshteinArray[i, 0] = i;//первый столбец заполняем порядковыми цифрами 
                    for (int j = 1; j < text2.Length; j++) //строка
                    {
                        if (i == 0) //если идёт первый столбец, то заполняем его порядковыми цифрами
                            LevenshteinArray[i, j] = j;//первый столбец заполняем порядковыми цифрами 
                        else
                        {
                            if (!text1[i - 1].Equals(text2[j - 1])) //если i-ый символ из первой строки  НЕ совпадает с j-ым символом второй строки
                                LevenshteinArray[i, j] = Math.Min(Math.Min(LevenshteinArray[i - 1, j] + 1, LevenshteinArray[i, j - 1] + 1), LevenshteinArray[i - 1, j - 1] + 1);// D(1,1) = Min (D(0,1)+1, D(1,0)+1,D(0,0)+1)
                            else
                                LevenshteinArray[i, j] = Math.Min(Math.Min(LevenshteinArray[i - 1, j] + 1, LevenshteinArray[i, j - 1] + 1), LevenshteinArray[i - 1, j - 1]);// D(1,1) = Min (D(0,1)+1, D(1,0)+1,D(0,0))
                        }
                    }
                }
                int stepCount = LevenshteinArray[text1.Length - 1, text2.Length - 1];
                percentage = (1 - (float)stepCount / (float)Math.Max(text1.Length, text2.Length)) * 100;
            }
            else
            {
                throw new ArgumentNullException("Одна из сравниваемых строк была пустой");
            }
        }
    }
}

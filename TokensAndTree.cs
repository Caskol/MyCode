using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Antlr4.Runtime.Tree.Xpath;



namespace MyCode
{
    public partial class TokensReview : Form
    {
        public string textFromParent; //строка, полученная из основного окна
        public string programmingLanguage; //строка, которая указывает, какой язык программирования был выбран для анализа
        private DataTable tokens = new DataTable();
        
        Tokenizer tokenizer;
        public TokensReview(string textFromParent, string programmingLanguage)
        {
            //инициализируем окно и выставляем названия колонкам
            this.textFromParent = textFromParent;
            this.programmingLanguage = programmingLanguage;
            tokenizer = new Tokenizer(programmingLanguage, textFromParent);
            tokens.Columns.Add("Строка");
            tokens.Columns.Add("Токен");
            tokens.Columns.Add("Содержимое токена");
            InitializeComponent();
        }

        private void TokensAndTree_Load(object sender, EventArgs e)
        {
            DataRow tokenRow;
            BindingSource bind = new BindingSource();

            foreach (var Token in tokenizer.TokensArray)
            {
                tokenRow = tokens.NewRow();
                tokenRow[0] = Token.Item1;
                tokenRow[1] = Token.Item2;
                tokenRow[2] = Token.Item3;
                tokens.Rows.Add(tokenRow);
            }
            bind.DataSource = tokens;//привязываем готовую таблицу токенов к bindingsource 
            dataGridViewTokens.DataSource = bind;//привязываем bindingsource к datagridview 

        }
    }
}

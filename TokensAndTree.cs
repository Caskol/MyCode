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
    public partial class TokensAndTree : Form
    {
        public string textFromParent; //строка, полученная из основного окна
        public string programmingLanguage; //строка, которая указывает, какой язык программирования был выбран для анализа
        private DataTable tokens = new DataTable();
        private DataRow tokenRow;
        private BindingSource bind = new BindingSource();
        public TokensAndTree(string textFromParent, string ProgrammingLanguage)
        {
            this.textFromParent = textFromParent;
            this.programmingLanguage = ProgrammingLanguage;
            tokens.Columns.Add("Строка");
            tokens.Columns.Add("Токен");
            tokens.Columns.Add("Содержимое токена");
            InitializeComponent();
        }

        private void TokensAndTree_Load(object sender, EventArgs e)
        {
            var inputStream = new AntlrInputStream(textFromParent);
            CommonTokenStream cts = null;
            //IParseTree tree;
            switch (programmingLanguage)
            {
                case "C":
                    {
                        var lexer = new CLexer(inputStream);
                        cts = new CommonTokenStream(lexer);
                        cts.Fill();
                        var parser = new CParser(cts) { BuildParseTree = true };
                        var tree = parser.translationUnit(); // получаем дерево парса
                        //Explore(tree);
                        textBoxTree.Text = tree.ToStringTree(parser);
                        foreach (var Token in cts.GetTokens())
                        {
                            tokenRow = tokens.NewRow();
                            tokenRow[0] = Token.Line;
                            tokenRow[1] = CLexer.DefaultVocabulary.GetSymbolicName(Token.Type);
                            tokenRow[2] = Token.Text;
                            tokens.Rows.Add(tokenRow);
                            //Debug.WriteLine($"{CLexer.DefaultVocabulary.GetSymbolicName(Token.Type),-15} '{Token.Text}'");
                        }
                        break;
                    }
                case "C++":
                    {
                        var lexer = new CPP14Lexer(inputStream);
                        cts = new CommonTokenStream(lexer);
                        cts.Fill();
                        var parser = new CPP14Parser(cts) { BuildParseTree = true };
                        var tree = parser.translationUnit(); // получаем дерево парса
                        textBoxTree.Text = tree.ToStringTree(parser);
                        foreach (var Token in cts.GetTokens())
                        {
                            tokenRow = tokens.NewRow();
                            tokenRow[0] = Token.Line;
                            tokenRow[1] = CPP14Lexer.DefaultVocabulary.GetSymbolicName(Token.Type);
                            tokenRow[2] = Token.Text;
                            tokens.Rows.Add(tokenRow);
                            //Debug.WriteLine($"{CLexer.DefaultVocabulary.GetSymbolicName(Token.Type),-15} '{Token.Text}'");
                        }
                        break;
                    }
                case "Pascal":
                    {
                        var lexer = new pascalLexer(inputStream);
                        cts = new CommonTokenStream(lexer);
                        cts.Fill();
                        var parser = new pascalParser(cts) { BuildParseTree = true };
                        var tree = parser.program(); // получаем дерево парса
                        Explore(tree);
                        //textBoxTree.Text = tree.ToStringTree(parser);
                        foreach (var Token in cts.GetTokens())
                        {
                            tokenRow = tokens.NewRow();
                            tokenRow[0] = Token.Line;
                            tokenRow[1] = pascalLexer.DefaultVocabulary.GetSymbolicName(Token.Type);
                            tokenRow[2] = Token.Text;
                            tokens.Rows.Add(tokenRow);
                            //Debug.WriteLine($"{CLexer.DefaultVocabulary.GetSymbolicName(Token.Type),-15} '{Token.Text}'");
                        }
                        break;
                    }
                case "Python":
                    {
                        var lexer = new Python3Lexer(inputStream);
                        cts = new CommonTokenStream(lexer);
                        cts.Fill();
                        var parser = new Python3Parser(cts) { BuildParseTree = true };
                        var tree = parser.file_input(); // получаем дерево парса
                        textBoxTree.Text = tree.ToStringTree(parser);
                        foreach (var Token in cts.GetTokens())
                        {
                            tokenRow = tokens.NewRow();
                            tokenRow[0] = Token.Line;
                            tokenRow[1] = Python3Lexer.DefaultVocabulary.GetSymbolicName(Token.Type);
                            tokenRow[2] = Token.Text;
                            tokens.Rows.Add(tokenRow);
                            //Debug.WriteLine($"{CLexer.DefaultVocabulary.GetSymbolicName(Token.Type),-15} '{Token.Text}'");
                        }
                        break;
                    }
                case "Java":
                    {
                        var lexer = new Java9Lexer(inputStream);
                        cts = new CommonTokenStream(lexer);
                        cts.Fill();
                        var parser = new Java9Parser(cts) { BuildParseTree = true };
                        var tree = parser.compilationUnit(); // получаем дерево парса
                        textBoxTree.Text = tree.ToStringTree(parser);
                        foreach (var Token in cts.GetTokens())
                        {
                            tokenRow = tokens.NewRow();
                            tokenRow[0] = Token.Line;
                            tokenRow[1] = Java9Lexer.DefaultVocabulary.GetSymbolicName(Token.Type);
                            tokenRow[2] = Token.Text;
                            tokens.Rows.Add(tokenRow);
                            //Debug.WriteLine($"{CLexer.DefaultVocabulary.GetSymbolicName(Token.Type),-15} '{Token.Text}'");
                        }
                        break;
                    }
                case "C#":
                    {
                        var lexer = new CSharpLexer(inputStream);
                        cts = new CommonTokenStream(lexer);
                        cts.Fill();
                        var parser = new CSharpParser(cts) { BuildParseTree = true };
                        ParserRuleContext tree = parser.compilation_unit(); // получаем дерево парса
                        //Explore(tree);
                        textBoxTree.Text = tree.ToStringTree(parser);

                        foreach (var Token in cts.GetTokens())
                        {
                            tokenRow = tokens.NewRow();
                            tokenRow[0] = Token.Line;
                            tokenRow[1] = CSharpLexer.DefaultVocabulary.GetSymbolicName(Token.Type);
                            tokenRow[2] = Token.Text;
                            tokens.Rows.Add(tokenRow);
                            //Debug.WriteLine($"{CLexer.DefaultVocabulary.GetSymbolicName(Token.Type),-15} '{Token.Text}'");
                        }
                        break;
                    }
            }
            bind.DataSource = tokens;//привязываем готовую таблицу токенов к bindingsource 
            dataGridViewTokens.DataSource = bind;//привязываем bindingsource к datagridview 
        }
        public void Explore(ParserRuleContext ctx, int indentLevel = 0)
        {
            object ruleName=null;
            switch (this.programmingLanguage)
            {
                case "C":
                    ruleName = CParser.ruleNames[ctx.RuleIndex];
                    break;
                case "C++":
                    ruleName = CPP14Parser.ruleNames[ctx.RuleIndex];
                    break;
                case "Java":
                    ruleName = Java9Parser.ruleNames[ctx.RuleIndex];
                    break;
                case "Pascal":
                    ruleName = pascalParser.ruleNames[ctx.RuleIndex];
                    break;
                case "C#":
                    ruleName = CSharpParser.ruleNames[ctx.RuleIndex];
                    break;
                case "Python":
                    ruleName = Python3Parser.ruleNames[ctx.RuleIndex];
                    break;

            }
            var sep = "".PadLeft(indentLevel);
            bool keepRule = ctx.ChildCount > 1;
            StringBuilder sb = new StringBuilder();
            if (keepRule)
                sb.Append(sep + ruleName+"\n");
            try
            {
                foreach (var c in ctx.children)
                {
                    if (c is ParserRuleContext)
                        Explore((ParserRuleContext)c, indentLevel + ((keepRule) ? 4 : 0));
                    else
                    {
                        var sep2 =
                            "".PadLeft(indentLevel + ((keepRule) ? 4 : 0));
                        sb.Append(sep2 + c.ToString()+"\n");
                    }
                }
            }
            catch (Exception e)
            { }
            textBoxTree.Text += sb.ToString();
        }
    }
}

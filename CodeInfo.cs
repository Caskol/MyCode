using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace MyCode
{
    public class CodeInfo
    {
        public uint Id {  get; set; }
        public Tokenizer Tokenizer { get; set; }
        public Shingle Shingle { get; set; }
        public uint SymbolsCount { get; set; }
        public string Language { get; set; }
    }
}

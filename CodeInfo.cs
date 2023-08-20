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
        [BsonId]
        public ObjectId Id { get; set; }
        public string CanonizedCode { get; set; } //канонизированный код
        public uint SymbolsCount { get; set; } //количество символов в канонизированном коде
        public ProgrammingLanguages Language { get; set; } //язык, на котором был написан код
        public DateTime DateTime { get; set; } //дата добавления
        public CodeInfo( string canonizedCode, uint symbolsCount, ProgrammingLanguages language, DateTime dateTime)
        {
            CanonizedCode = canonizedCode;
            SymbolsCount = symbolsCount;
            Language = language;
            DateTime = dateTime;
        }
    }
}

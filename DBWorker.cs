using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCode
{
    public class DBWorker
    {
        LiteDatabase db = new LiteDatabase(@"CodeLibrary.db"); //подключаем базу данных NoSQL к программе
    }
}

using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace MyCode
{
    public class DBWorker
    {
        /// <summary>
        /// Конструктор класса, который откроет базу данных и попробует поместить туда объект класса CodeInfo
        /// </summary>
        /// <param name="data">Информация, которую нужно загрузить в бд</param>
        public void InsertIntoDB (CodeInfo data) 
        {
            using (var db = new LiteDatabase(@"CodeLibrary.db")) //подключаем базу данных NoSQL к программе 
            {
                var collection = db.GetCollection<CodeInfo>("Library"); //получаем набор исходных кодов (CodeInfo) из базы данных в таблице Library

                collection.Insert(data); //вставляем в коллекцию исходный код

                //индексируем
                collection.EnsureIndex(x => x.Id);
                //collection.EnsureIndex(x => x.CanonizedCode,true);
                collection.EnsureIndex(x => x.SymbolsCount);
                collection.EnsureIndex(x => x.Language);
                collection.EnsureIndex(x => x.DateTime);
            }
        }
        public void DeleteFromDB(string codeId)
        {
            using (var db = new LiteDatabase(@"CodeLibrary.db")) //подключаем базу данных NoSQL к программе 
            {
                var collection = db.GetCollection<CodeInfo>("Library"); //получаем набор исходных кодов (CodeInfo) из базы данных в таблице Library
                ObjectId id = new ObjectId(codeId); //создаем экземпляр идентификатора (передать в базу данных строку явно можно, однако это не принесет результата, если идентификатор имел класс, отличный от string)
                collection.Delete(id);//удаляем данные при помощи id
            }
                
        }
        public IList<CodeInfo> GetAll()
        {
            var allCodes = new List<CodeInfo>(); //создаем список, в который будут помещаться данные
            using (var db = new LiteDatabase(@"CodeLibrary.db")) //подключаем базу данных NoSQL к программе 
            {
                var collection = db.GetCollection<CodeInfo>("Library"); //получаем набор исходных кодов (CodeInfo) из базы данных в таблице Library
                var array = collection.FindAll(); //получаем массив всех элементов из коллекции
                foreach (var code in array)
                {
                    allCodes.Add(code);
                }
                return allCodes;
            }
        }
    }
}

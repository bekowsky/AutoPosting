using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;

namespace WordService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "ServiceWord" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы ServiceWord.svc или ServiceWord.svc.cs в обозревателе решений и начните отладку.
    public class ServiceWord : IServiceWord
    {
        Random random = new Random();
        WordsContext db = new WordsContext();
        public void FillDB()
        {
            
          
            HtmlDocument html = new HtmlDocument();
            html.Load(HttpContext.Current.Server.MapPath("allwords_files/words.txt") , UTF8Encoding.UTF8);
           
            HtmlNode Node = html.DocumentNode;
            var NodeList = Node.SelectSingleNode ("/div[1]");
            foreach (HtmlNode node in NodeList.ChildNodes.Where(x => x.Name == "tr"))
            {
                Word word = new Word{ en = node.ChildNodes[1].InnerText, ru = node.ChildNodes[2].InnerText};
                db.Words.Add(word);
               
            }
            db.SaveChanges();

        }
 
    

        public  string [] TakeWordTranslate()
        {
            
          int index =  random.Next(0,4999);
            Word word = db.Words.SingleOrDefault(x => x.id == index);
            string [] arr ={word.ru, word.en };
            return arr;

            
        }


   

    }
}

﻿using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ImageService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public static class HtmlNodeExtension
    {

        public static HtmlNode GetNode(this HtmlNode node, string classname)
        {
            if (node != null)
            {
                foreach (var item in node.ChildNodes)
                    if ((item.Attributes.Count > 0) && (item.Attributes.Contains("class")))
                        if (item.Attributes["class"].Value.Contains(classname))
                            return item;
            }
            return null;
        }

        public static HtmlNode GetNode(this HtmlNode node, string classname1, string classname2)
        {
            if (node != null)
            {
                foreach (var item in node.ChildNodes)
                    if ((item.Attributes.Count > 0) && (item.Attributes.Contains("class")))
                        if (item.Attributes["class"].Value.Contains(classname1)|| item.Attributes["class"].Value.Contains(classname2))
                            return item;
            }
            return null;
        }
    }


        public class ServiceImg : IServiceImg
    {
        
        public string TakeHtml(string Word)
        {
            string data = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://yandex.ru/images/search?text=" + Word + "&isize=large");
                request.Credentials = CredentialCache.DefaultCredentials;
                WebResponse response = request.GetResponse();
                using (Stream dataStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(dataStream);
                    data = reader.ReadToEnd();
                }
                response.Close();
            }
            catch (Exception)
            {
                return null;
            }
            return data;
        }

        public List<string> ParseHtml(string Html, int Count = 1)
        {
            List<string> LinkList = new List<string>();
            try
            {
                HtmlDocument html = new HtmlDocument();
                html.LoadHtml(Html);
                HtmlNode Node = html.DocumentNode;
                // var NodeList = Node.SelectSingleNode("/html[1]/body[1]/div[6]/div[1]/div[1]/div[3]/div[1]");
                var NodeList = Node.SelectSingleNode("/html[1]/body[1]").
                    GetNode("page-layout page-layout_page_search page-layout_layout_serp serp-controller").
                    GetNode("page-layout__column page-layout__column_type_content").
                    GetNode("page-layout__content-wrapper b-page__content").
                    GetNode("serp-controller__content serp-controller__content_size-plates_visible", "serp-controller__content").
                    GetNode("serp-list serp-list_type_search serp-list_unique_yes");
                 
                foreach (HtmlNode node in NodeList.ChildNodes.Where(x => x.Name == "div"))
                {

                    dynamic JsonData = JsonConvert.DeserializeObject(node.Attributes["data-bem"].Value.Replace("serp-item", "Serp"));
                    string ImageLink = JsonData.Serp.preview[0].origin.url;
                    LinkList.Add(ImageLink);
                    Count--;
                    if (Count == 0)
                        break;
                }
            }
            catch (Exception)
            {
                return null;
            }


            return LinkList;
        }

        public string TakeLink(string Word, int Count = 1)
        {
            string html = TakeHtml(Word);
            List<string> link = ParseHtml(html, Count);
            return link.First();

        }
    }
}

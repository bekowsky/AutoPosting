using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;

namespace PictureService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "ServicePicture" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы ServicePicture.svc или ServicePicture.svc.cs в обозревателе решений и начните отладку.
    public class ServicePicture : IServicePicture
    {
        public string CombineTextPicture(string url, string ru, string en)
        {
            System.Drawing.Text.PrivateFontCollection f = new System.Drawing.Text.PrivateFontCollection();
            f.AddFontFile(HttpContext.Current.Server.MapPath("userfont.otf"));        
            var request = WebRequest.Create(url);
            Image img;
            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                img = Bitmap.FromStream(stream);
            }


            Graphics g = Graphics.FromImage(img);
            int size = img.Width / 20;
            Font font = new Font(f.Families[0], size);


            SolidBrush Brush = new SolidBrush(Color.FromArgb(50, 0, 0, 0));
            g.FillRectangle(Brush, 0, 0, img.Width, img.Height);


            g.DrawString(en, font, new SolidBrush(Color.White), img.Width / 2 - size / 2 * en.Length, img.Height / 2 - size);
            g.DrawString(ru, font, new SolidBrush(Color.White), img.Width / 2 - size / 2 * ru.Length, img.Height / 2 + size);


            string name = GetRandomString(5);
            img.Save(@"C:\Users\Xiaomi\source\repos\AutoPosting\Images\" + name + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg); //путь и имя сохранения файла
            return name;
        }

        string GetRandomString(int Length)
        {
            string Alphabet = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";
            Random rnd = new Random();
            StringBuilder sb = new StringBuilder(Length - 1);
            int Position = 0;
            for (int i = 0; i < Length; i++)
            {
                Position = rnd.Next(0, Alphabet.Length - 1);
                sb.Append(Alphabet[Position]);
            }
            return sb.ToString();
        }
    }
}

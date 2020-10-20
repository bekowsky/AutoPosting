using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MasterServcie.ServiceImg;
using MasterServcie.ServicePicture;
using MasterServcie.ServiceVk;
using MasterServcie.ServiceWord;

namespace MasterServcie
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "ServiceMaster" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы ServiceMaster.svc или ServiceMaster.svc.cs в обозревателе решений и начните отладку.
    public class ServiceMaster : IServiceMaster
    {
       

        public void PostPicktureVk()
        {
            ServiceImgClient imgClient = new ServiceImgClient();
            ServiceWordClient wordClient = new ServiceWordClient();
            ServiceVkClient serviceVkClient = new ServiceVkClient();
            ServicePictureClient servicePicture = new ServicePictureClient();

            string [] words = wordClient.TakeWordTranslate();
           string url = imgClient.TakeLink(words[0],1);
           string path0 = servicePicture.CombineTextPicture(url,words[0],words[1]);
            string path = @"C:\Users\Xiaomi\source\repos\AutoPosting\Images\" + path0 + ".jpg";
            serviceVkClient.Posting("3c61a25deb2bad6b45ccb0cda522f5327003bd1e672775e349b96d45c6213c85db0d49dd23fd6eae9498c",path,"199275400");

           

        }
    }
}

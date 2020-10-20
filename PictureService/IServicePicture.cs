using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PictureService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IServicePicture" в коде и файле конфигурации.
    [ServiceContract]
    public interface IServicePicture
    {
        [OperationContract]
        string CombineTextPicture(string url, string en, string ru);
    }
}

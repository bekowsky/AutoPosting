using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace VkService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IServiceVk" в коде и файле конфигурации.
    [ServiceContract]
    public interface IServiceVk
    {
        [OperationContract]
        void Posting(string token, string path, string group);
    }
}

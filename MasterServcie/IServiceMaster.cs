﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MasterServcie
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IServiceMaster" в коде и файле конфигурации.
    [ServiceContract]
    public interface IServiceMaster
    {
        [OperationContract]
        void PostPicktureVk();
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WordService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IServiceWord" в коде и файле конфигурации.
    [ServiceContract]
    public interface IServiceWord
    {

        [OperationContract]
       string [] TakeWordTranslate();

    }
}

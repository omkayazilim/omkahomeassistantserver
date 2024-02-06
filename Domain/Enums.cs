using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public enum IOPortType
    {
        IN='I',
        OUT='O'
    }

    public enum IOPortPropertyType
    {
        OnlyDigital='D',
        OnlyAnalog='A',
        Hybrid='H'
    }

    public enum DeviceType
    {
        Esp32=32,
        Esp01=1
    }
}

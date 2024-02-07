using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public enum IOPortType
    {
        IN=0,
        OUT=1
    }

    public enum IOPortPropertyType
    {
        OnlyDigital=0,
        OnlyAnalog=1,
        Hybrid=2
    }

    public enum DeviceType
    {
        Esp32=32,
        Esp01=1
    }
}

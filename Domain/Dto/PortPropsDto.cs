
namespace Domain.Dto
{
    public class PortPropsDto
    {
        public long Id  { get; set; }
        public int PortNumber { get; set; }
        public string PortKey { get; set; }
        public string PortDesc { get; set; }
        public EspPortPropertyType PortPropertyType { get; set; }
        public EspPortType PortType { get; set; }
        public bool PinStat { get; set; }
    }
}

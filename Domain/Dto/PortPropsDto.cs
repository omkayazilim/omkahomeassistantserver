
namespace Domain.Dto
{
    public class PortPropsDto
    {
        public long Id  { get; set; }
        public long EspPortDefId { get; set; }
        public string? Title { get; set; }
        public int PortNumber { get; set; }
        public string? PortKey { get; set; }
        public string? PortDesc { get; set; }
        public IOPortPropertyType PortPropertyType { get; set; }
        public IOPortType PortType { get; set; }
        public bool PinStat { get; set; }
    }
}

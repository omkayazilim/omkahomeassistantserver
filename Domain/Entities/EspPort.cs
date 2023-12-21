
namespace Domain.Entities
{
    public class EspPort: EntityBase
    {
        public int PortNumber { get; set; }
        public string PortKey { get; set; }
        public string PortDesc { get; set; }
        public EspPortPropertyType PortPropertyType { get; set; }
        public EspPortType PortType { get; set; }
    }
}

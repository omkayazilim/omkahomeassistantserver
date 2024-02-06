
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class DevicePortDef:EntityBase
    {
        public int PortNumber { get; set; }
        [StringLength(5)]
        public string? PortCode { get; set; }

        [StringLength(50)]
        public string? PortDesc { get; set; }

        public long DeviceId { get; set; }
        [ForeignKey("DeviceId")]
        public DeviceDef? DeviceDef { get; set; }

        public IOPortType IOPortType { get; set; }   
    }
}

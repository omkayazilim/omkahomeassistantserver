
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class DeviceDef: EntityBase
    {
        [StringLength(50)]
        public string? DeviceName { get; set; }

        [StringLength(5)]
        public string? DeviceCode { get; set; }

        public long DeviceTypeId { get; set; }
        [ForeignKey("DeviceTypeId")]
        public DeviceTypeDef? DeviceTypeDef { get; set; }
        public  string? DeviceAdressUrl { get; set; }
        public int TotalIOPortCount { get; set; } 

    }
}

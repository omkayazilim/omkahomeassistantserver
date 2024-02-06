
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class DeviceTypeDef:EntityBase
    {
        public DeviceType DeviceType { get; set; }
        [StringLength(50)]
        public string? DeviceTypeDesc { get; set; }
      
    }
}

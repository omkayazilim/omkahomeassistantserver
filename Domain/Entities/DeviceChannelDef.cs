

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class DeviceChannelDef:EntityBase
    {
        public long DevicePortId { get; set; }

        [ForeignKey("DevicePortId")]
        public DevicePortDef? DevicePortDef { get; set; }

        public int DeviceChannelNo { get; set; }

        [StringLength(5)]
        public string? DeviceChannelCode { get; set; }

        [StringLength(100)]
        public string? DeviceChannelDesc { get; set; }

        [StringLength(100)]
        public string? DeviceChannelIcon { get; set; }

    }
}

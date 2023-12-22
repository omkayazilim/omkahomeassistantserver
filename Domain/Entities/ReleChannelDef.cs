
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class ReleChannelDef: EntityBase
    {
        public long EspPortDefId { get; set; }

        [ForeignKey("EspPortDefId")]
        public  EspPortDef? EspPortDef { get; set; }

        [StringLength(20)]
        public string? ReleChannelName { get; set; }
        [StringLength(150)]
        public string? ReleChannelDesc { get; set; }

    }
}

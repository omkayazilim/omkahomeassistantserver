

namespace Domain.Dto
{
    public class ReleChannelModelBase
    {
        public long Id { get; set; }
        public long EspPortDefId { get; set; }
        public string? ReleChannelName { get; set; }
        public string? ReleChannelDesc{ get; set; }
        public bool IsActive { get; set; } 
        public int ChannelNo { get; set; }
    }
}

namespace Domain.Dto
{
    public class DeviceChannelDefDto: DeviceChannelDefDtoBase
    {
        public DevicePortDefDto DevicePortDef { get; set; }

    }

    public class DeviceChannelDefRequestDto: DeviceChannelDefDtoBase
    {
        public long DevicePortDefId { get; set; }
   
    }
    public class DeviceChannelDefDtoBase
    {
        public long Id { get; set; }
        public int DeviceChannelNo { get; set; }
        public string? DeviceChannelCode { get; set; }
        public string? DeviceChannelDesc { get; set; }
        public bool IsActive { get; set; }
        public string? DeviceChannelIcon { get; set; }
        public bool ChannelStatus { get; set; }

    }

}

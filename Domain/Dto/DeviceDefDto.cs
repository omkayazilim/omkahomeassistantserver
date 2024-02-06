
namespace Domain.Dto
{
    public class DeviceDefDto: DeviceDefDtoBase
    {
        public DeviceTypeDefDto DeviceTypeDef { get; set; }
    }

    public class DeviceDefRequestDto: DeviceDefDtoBase
    {
        public long DeviceTypeDefId { get; set; }
    }

    public class DeviceDefDtoBase
    {
        public long Id { get; set; }
        public string DeviceName { get; set; }
        public string DeviceCode { get; set; }
        public string DeviceAdressUrl { get; set; }
        public bool IsActive { get; set; }
        public int TotalIOPortCount { get; set; }
    }


}

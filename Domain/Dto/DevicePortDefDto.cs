using Domain.Entities;
namespace Domain.Dto
{
    public class DevicePortDefDto: DevicePortDefDtoBase
    {
        public DeviceDefDto? DeviceDef { get; set; }
    }

    public class DevicePortDefRequestDto: DevicePortDefDtoBase
    {
        public long DeviceDefId { get; set; }
    }

    public class DevicePortDefDtoBase
    {
        public long Id { get; set; }
        public int PortNumber { get; set; }
        public string PortCode { get; set; }
        public string PortDesc { get; set; }
        public IOPortType IOPortType { get; set; }
        public bool IsActive { get; set; }
    }
}

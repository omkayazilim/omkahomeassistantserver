
namespace Domain.Dto
{
    public class DeviceTypeDefDto
    {
        public long Id { get; set; }
        public DeviceType DeviceType { get; set; }
        public string? DeviceTypeDesc { get; set; }
        public bool IsActive { get; set; }    
    }
}

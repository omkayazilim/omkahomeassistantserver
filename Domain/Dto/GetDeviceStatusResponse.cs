
namespace Domain.Dto
{
    public class GetDeviceStatusResponse
    {
        public DeviceDefDto DeviceDef { get; set; }
        public bool DeviceStatus { get; set; }
        public bool IsAwaible { get; set; }

        public string GetDeviceStatusDesc() 
        {
            return this.DeviceStatus ? "Açık" : "Kapalı";
        }
    }
}



using AutoMapper;
using Domain.Dto;
using Domain.Entities;

namespace Domain.Mappers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<DeviceDef,DeviceDefDto>().ReverseMap();
            CreateMap<DeviceTypeDef, DeviceTypeDefDto>().ReverseMap();
            CreateMap<DevicePortDef, DevicePortDefDto>().ReverseMap();   
            CreateMap<DeviceChannelDef, DeviceChannelDefDto>().ReverseMap();
        }
    }
}

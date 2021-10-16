using AutoMapper;
using Common.Models;
using Common.Models.DTO;

namespace CustomerService.Utility
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerCreationDto, Customer>();

        }
    }
}
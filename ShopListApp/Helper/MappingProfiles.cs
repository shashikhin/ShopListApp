using AutoMapper;
using ShopListApp.Domain.Models;
using ShopListApp.Domain.Models.Input;

namespace ShopListApp.WebAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}

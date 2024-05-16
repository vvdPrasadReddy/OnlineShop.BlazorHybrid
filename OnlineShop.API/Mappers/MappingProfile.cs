using AutoMapper;
using DbModels = OnlineShop.API.Models;
using OnlineShop.API.Shared.ViewModels;

namespace OnlineShop.API.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DbModels.Country, Country>().ReverseMap();
            CreateMap<DbModels.State, State>().ReverseMap();
            CreateMap<DbModels.Product, ProductModel>().ReverseMap();
        }
    }
}

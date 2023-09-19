using AutoMapper;
using SampleRestApi.Models;
using SampleRestApi.ViewModels;

namespace SampleRestApi.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Account, AccountViewModel>().ReverseMap();
            CreateMap<Card, CardViewModel>().ReverseMap();
            CreateMap<Features, FeaturesViewModel>().ReverseMap();
            CreateMap<News, NewsViewModel>().ReverseMap();
            CreateMap<User, UserViewModel>().ReverseMap();
        }
    }
}
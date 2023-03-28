using AutoMapper;
using OnlineShop.Domain.Entities;
using OnlineShop.Service.ViewModels;

namespace OnlineShop.MVC.Configurations
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<AnnouncementViewModel, Announcement>().ReverseMap();
            CreateMap<UserViewModel, User>().ReverseMap();
        }

    }
}
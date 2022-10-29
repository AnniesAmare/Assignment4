using AutoMapper;
using DataLayer;
using DataLayer.Model;
using WebServer.Controllers;
using static WebServer.Controllers.CategoriesController;

namespace WebServer.Models.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryModel>();
            //CreateMap<Category, CategoryCreateModel>().ReverseMap(); //Makes it possible to convert in both directions.
            CreateMap<Category, CategoryCreateModel>();
            CreateMap<Category, CategoryUpdateModel>()
                .ForMember(dst => dst.Id,
                    opt => opt.MapFrom(src => src.Id));


        }
    }

}


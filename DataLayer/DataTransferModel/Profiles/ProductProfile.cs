using AutoMapper;
using DataLayer.Model;
namespace DataLayer.DataTransferModel.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {

        CreateMap<Product, ProductByCategoryListElement>()
            .ForMember(dst => dst.CategoryName, 
                opt => opt.MapFrom(src => src.Category.Name));

        CreateMap<Product, ProductByNameListElement>()
            .ForMember(dst => dst.CategoryName,
                opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dst => dst.ProductName,
                opt => opt.MapFrom(src => src.Name));

    }

}
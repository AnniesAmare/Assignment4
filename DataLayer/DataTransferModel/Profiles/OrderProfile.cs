using AutoMapper;
using DataLayer.Model;

namespace DataLayer.DataTransferModel.Profiles;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        
        CreateMap<Order, OrderListElement>()
            .ForMember(dst => dst.City, 
                opt => opt.MapFrom(src => src.ShipCity));
    }
}
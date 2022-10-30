using AutoMapper;
using DataLayer.Model;

namespace DataLayer.DataTransferModel.Profiles
{
    internal class OrderDetailsProfile : Profile
    {
        public OrderDetailsProfile()
        {
            CreateMap<OrderDetails, OrderDetailsByIdListElement>();
            CreateMap<OrderDetails, OrderDetailsByProductIdListElement>();
        }
    }
}

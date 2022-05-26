using AutoMapper;
using OrderService.Microservice.DTOs;
using OrderService.Microservice.Model;

namespace OrderService.Microservice.Profiles
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile()
        {
            //Source -> target
            CreateMap<Bid, BidReadDTO>();
            CreateMap<BidCreateDTO, Bid>();
        }
    }
}

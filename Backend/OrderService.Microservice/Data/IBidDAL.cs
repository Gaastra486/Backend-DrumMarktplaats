using Microsoft.AspNetCore.Mvc;
using OrderService.Microservice.Model;

namespace OrderService.Microservice.Data
{
    public interface IBidDAL
    {
        
        ActionResult AddBid(Bid bid);
        List<Bid> GetBidsByProductId(int id);
        List<Bid> GetBidsByUserId(int id);
        List<Bid> GetBids();
        Bid UpdateBid(Bid bid);
        ActionResult DeleteBidById(int id);

    }
}

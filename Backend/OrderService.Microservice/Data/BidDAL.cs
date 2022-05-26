using Microsoft.AspNetCore.Mvc;
using OrderService.Microservice.Context;
using OrderService.Microservice.Model;

namespace OrderService.Microservice.Data
{
    public class BidDAL : IBidDAL
    {
        private readonly OrderDbContext db;

        public BidDAL(OrderDbContext db)
        {
            this.db = db;
        }
        public ActionResult AddBid(Bid bid)
        {
           db.Bid.Add(bid);
           db.SaveChanges();
           return new OkResult();

        }

        public ActionResult DeleteBidById(int id)
        {
            db.Bid.Remove(db.Bid.Where(x => x.Id == id).FirstOrDefault());
            db.SaveChanges();
            return new OkResult();
        }

        public List<Bid> GetBidsByProductId(int id)
        {

            var listOfBids = db.Bid.ToList().Where(x => x.productId == id);
            List<Bid> bids = listOfBids.ToList();
            return bids;
            
        }

        public List<Bid> GetBidsByUserId(int id)
        {
            throw new NotImplementedException();
        }

        public Bid UpdateBid(Bid bid)
        {
            throw new NotImplementedException();
        }

        public List<Bid> GetBids() => db.Bid.ToList();
    }
}

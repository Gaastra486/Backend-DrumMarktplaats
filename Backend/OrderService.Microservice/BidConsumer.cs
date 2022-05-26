using MassTransit;
using OrderService.Microservice.Data;
using SharedLibrary;

namespace OrderService.Microservice
{
    internal class BidConsumer : IConsumer<Bid>
    {
        private ILogger<BidConsumer> _logger;
        private IBidDAL db;

        public BidConsumer(ILogger<BidConsumer> logger, IBidDAL db)
        {
            _logger = logger;
            this.db = db;
        }

        public async Task Consume(ConsumeContext<Bid> context)
        {
            // log message in console
            _logger.LogInformation($"Got a new message {context.Message.bidAmount}");
            Model.Bid bid = new Model.Bid();
            bid.bidAmount = context.Message.bidAmount;
            bid.created = context.Message.created;  
            bid.productId = context.Message.productId;
            bid.userId = context.Message.userId;
            db.AddBid(bid);
        }
    }
}

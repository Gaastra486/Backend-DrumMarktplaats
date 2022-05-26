using MassTransit;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary;

namespace WebApplicationBidSender.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BidController : ControllerBase
    {
        //Endpoint Interface
        private readonly IPublishEndpoint publishEndpoint;

        public BidController(IPublishEndpoint publishEndpoint)
        {
            this.publishEndpoint = publishEndpoint;
        }

        // Since the controller doesn't have any calls, this will be the base call. You can call this by connection to: [localhost:port]/api/order; 
        [HttpPost]
        public async Task<ActionResult> Create(Bid bid)
        {
            // The publish endpoint publishes the message into [model] exchange, the [model] exchange passes it to [model] queue. 
            await publishEndpoint.Publish<Bid>(bid);
            return Ok();
        }
    }
}

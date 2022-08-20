using MassTransit.Contracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MassTransit.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase {
        readonly ILogger<OrderController> _logger;
        private readonly IRequestClient<SubmitOrder> _submitOrderRequestClient;

        public OrderController(ILogger<OrderController> logger, IRequestClient<SubmitOrder> submitOrderRequestClient) {
            _submitOrderRequestClient = submitOrderRequestClient;
            _logger = logger;

        }
        
        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<string> Get() {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public string Get(int id) {
            return "value";
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<IActionResult> Post(Guid id, string customerNumber)
        {
            var (accepted, rejected) = await _submitOrderRequestClient.GetResponse<OrderSubmissionAccepted, OrderSumissionRejected>(new
            {
                OrderId = id,
                InVar.Timestamp,
                CustomerNumber = customerNumber
            });
            if (accepted.IsCompletedSuccessfully)
            {
                var response = await accepted;

                return Ok(response.Message);
            }
            else
            {
                var response = await rejected;
                return BadRequest(response.Message);
            }
        }

    // PUT api/<OrderController>/5
    [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}

 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order_Processing_Serverless_in_aws.Models;
using Order_Processing_Serverless_in_aws.Services;

namespace Order_Processing_Serverless_in_aws.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderProcessing _orderProcessing;

        public OrderController(IOrderProcessing orderProcessing)
        {
            _orderProcessing = orderProcessing;
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Order=  await _orderProcessing.InvokeLambdaFunction(order);

            return Ok("Order created successfully.");
       
        }
    }

}

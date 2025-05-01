using ApiDataFetcher.Interfaces;
using ApiDataFetcher.Models.Request;
using ApiDataFetcher.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace ApiDataFetcher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ResponseCache(Duration = 300, Location = ResponseCacheLocation.Client)]
    public class SilverwareDataController(ISilverwareDataFetcher apiService) : ControllerBase
    {
        private readonly ISilverwareDataFetcher _apiService = apiService;

        [HttpPost("daily-totals")]
        public async Task<ActionResult<DailyTotalsResponse>> GetDailyTotals([FromBody] DailyTotalsRequest request)
        {
            var response = await _apiService.GetDailyTotalsAsync(request);
            return Ok(response);
        }

        [HttpGet("orders")]
        public async Task<ActionResult<GetOrdersResponse>> GetOrders([FromQuery] GetOrdersRequest request)
        {
            var response = await _apiService.GetOrdersAsync(request);
            return Ok(response);
        }

        [HttpGet("order")]
        public async Task<ActionResult<GetOrderRequest>> GetOrder([FromQuery] GetOrderRequest request)
        {
            var response = await _apiService.GetOrderAsync(request);
            return Ok(response);
        }
    }
}
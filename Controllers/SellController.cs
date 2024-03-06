using a2Algo.DTO.Purchase;
using a2Algo.DTO.Sell;
using a2Algo.Interfaces.Services;
using a2Algo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace a2Algo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellController : ControllerBase
    {
        private readonly ISellService _sellService;
        public SellController(ISellService sellService)
        {
            _sellService = sellService;
        }

        [HttpPost]
        public async Task<IActionResult> POST(ForSellOrderDTO Order)
        {
            CreateResponse Response = await _sellService.PlaceSellOrderAsync(Order);

            int Code = Response.StatusCode;
            return Code switch
            {
                201 => CreatedAtAction(nameof(GET), new { Id = Response.Id }, Order),
                500 => StatusCode(StatusCodes.Status500InternalServerError, Response.Message)
            };
        }


        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GET(int Id)
        {
            return Ok(await _sellService.GetSellOrderByIdAsync(Id));
        }

        [HttpGet]
        public async Task<IActionResult> GET()
        {
            var Response = await _sellService.GetSellOrderAsync();
            return Ok(Response);
        }

        [HttpDelete("{Id:int}")]
        public async Task<IActionResult> DELETE(int Id)
        {
            GlobalResponse Response = await _sellService.DeleteSellOrderAsync(Id);
            int Code = Response.StatusCode;

            return Code switch
            {
                500 => StatusCode(StatusCodes.Status500InternalServerError, Response.Message),
                200 => Ok(Response.Message),
                404 => BadRequest(Response.Message)
            };
        }

        [HttpPut]
        public async Task<IActionResult> PUT(UpdatingSaleOrderDTO Order)
        {
            GlobalResponse Response = await _sellService.UpdateSellOrderAsync(Order);
            int Code = Response.StatusCode;

            return Code switch
            {
                500 => StatusCode(StatusCodes.Status500InternalServerError, Response.Message),
                200 => Ok(Response.Message),
                404 => BadRequest(Response.Message)
            };
        }
    }
}

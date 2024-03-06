using a2Algo.DTO.Product;
using a2Algo.DTO.Purchase;
using a2Algo.Interfaces.Services;
using a2Algo.Models;
using a2Algo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace a2Algo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {

        private readonly IPurchaseService _purchaseService;
        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpPost]
        public async Task<IActionResult> POST(PurchaseOrderDTO Order)
        {
            CreateResponse Response = await _purchaseService.PlacePurchaseOrderAsync(Order);

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
            var response = await _purchaseService.GetPurchaseOrderByIdAsync(Id);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GET()
        {
            var Response = await _purchaseService.GetAllPurchaseOrdersAsync();
            return Ok(Response);
        }

        [HttpDelete("{Id:int}")]
        public async Task<IActionResult> DELETE(int Id)
        {
            GlobalResponse Response = await _purchaseService.DeletePurchaseOrderAsync(Id);
            int Code = Response.StatusCode;

            return Code switch
            {
                500 => StatusCode(StatusCodes.Status500InternalServerError, Response.Message),
                200 => Ok(Response.Message),
                404 => BadRequest(Response.Message)
            };
        }

        [HttpPut]
        public async Task<IActionResult> PUT(UpdatingPurchaseOrderDTO Order)
        {
            GlobalResponse Response = await _purchaseService.UpdatePurchaseOrderAsync(Order);
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

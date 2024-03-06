using a2Algo.DTO.Product;
using a2Algo.Interfaces.Services;
using a2Algo.Models;
using a2Algo.SolidImplementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace a2Algo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

        [HttpPost]
        public async Task<IActionResult> POST(CreateProductDTO Product)
        {
            CreateResponse Response = await productService.AddProduct(Product);
            int Code = Response.StatusCode;
            return Code switch
            {
                201 => CreatedAtAction(nameof(GET), new { Id = Response.Id }, Product),
                500 => StatusCode(StatusCodes.Status500InternalServerError, Response.Message)
            };
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GET( int Id)
        {
            var Response = await productService.GetProductById(Id);
            return Ok(Response);
        }

        [HttpGet]
        public async Task<IActionResult> GET()
        {
            var Response = await productService.GetAllAsync();
            return Ok(Response);
        }

        [HttpDelete ("{Id:int}")]
        public async Task<IActionResult> DELETE(int Id)
        {
            GlobalResponse Response = await productService.DeleteProduct(Id);
            int Code = Response.StatusCode;

            return Code switch
            {
                500 => StatusCode(StatusCodes.Status500InternalServerError, Response.Message),   
                200 => Ok(Response.Message),
                404 => BadRequest(Response.Message)
            };
        }

        [HttpPut]
        public async Task<IActionResult> PUT(UpdateProductDTO Product)
        {
            GlobalResponse Response = await productService.UpdateProduct(Product);
            int Code = Response.StatusCode;

            return Code switch
            {
                500 => StatusCode(StatusCodes.Status500InternalServerError, Response.Message),
                200 => Ok(Response.Message),
                404 => BadRequest(Response.Message)
            };
        }


        [HttpGet]
        [Route("ProductUserEnd")]
        public async Task<IActionResult> ProductUserEnd()
        {
            var response = await productService.ProductForUser();
            return Ok(response);
        }



        [HttpGet]
        [Route("ProductSellingOrderDetail")]
        public async Task<IActionResult> ProductSellingOrderDetail()
        {
            var response = await productService.ProductWithSellingDetail();
            return Ok(response);
        }


    }
}

using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Fleetmatics.Service.Contracts;

namespace Fleetmatics.ProductWebApi.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Authorize]
        [Route("products")]
        public HttpResponseMessage GetProducts()
        {
            HttpResponseMessage response;

            try
            {
                var lstProducts = _productService.GetProducts();
                response = Request.CreateResponse(HttpStatusCode.OK, lstProducts);
            }
            catch (Exception)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return response;
        }
    }
}

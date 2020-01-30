using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models;
using DataAccess;
using Newtonsoft.Json;
using System.Web.Helpers;

namespace WebApiService.Controllers
{
    public class ProductReviewsController : ApiController
    {

    public  ProductReviewsController()
        {

        }

        #region Fields
        private ProductReviewDataProvider productReviewDP = new ProductReviewDataProvider();
        #endregion


        // GET: api/ProductReviews/5
        [AllowAnonymous]
        [HttpGet]
        //[Route("api/ProductReviews/Generate")]
        public IHttpActionResult Generate(int randomIndex)
        {
            var productReviewJsonString = Json(productReviewDP.GetJsonReviewFromFile(randomIndex));
            
            return productReviewJsonString;
        }
      
    }
}

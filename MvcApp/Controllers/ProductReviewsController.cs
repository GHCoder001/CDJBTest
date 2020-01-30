
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;


namespace MvcApp.Controllers
{
    public class ProductReviewsController : Controller
    {
        // GET: ProductReviews
       
        public ActionResult Index()
        {
            var reviewsModel = new List<ProductReview>();

            // TODO: Call api to get reviews json, parse to list of reviews

            return View(reviewsModel);
        }


        public ActionResult Get()
        {
            var reviewsModel = new List<ProductReview>();
   

            // TODO: Call api to get reviews json, parse to list of reviews, sort and return
            return View("_Reviews",reviewsModel);
        }


        // GET: ProductReviews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductReviews/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductReview review)
        {
            try
            {
                // TODO: Add insert logic here - something like below
                //ServiceRepository serviceObj = new ServiceRepository();
                //HttpResponseMessage response = serviceObj.PostResponse("api/ProductReviews/Create", review);
                //response.EnsureSuccessStatusCode();
             
                return RedirectToAction("Get");
            }
            catch
            {
                return View();
            }
        }
            

       
    }
}
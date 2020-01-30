using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Models;
using System.Collections.Generic;

namespace DataAccess
{
    public class ProductReviewDataProvider
    {
        public void SaveReviewToFile(string newReviewJson)
        {
            //TODO: Get json reviews and add new review
            var existingReviewsJson = GetJsonReviewsFromFile();
          

            var array = JArray.Parse(existingReviewsJson);

            // Create json object of new review submitted
            var itemToAdd = new JObject(newReviewJson);
            //itemToAdd["id"] = 1234;
            //itemToAdd["name"] = "carl2";
            array.Add(itemToAdd);

            var jsonToSave = JsonConvert.SerializeObject(array, Formatting.Indented);

            //save to file here
            // serialize JSON to a string and then write string to a file
            File.WriteAllText(@"source/Automotive_5.json", jsonToSave);
        }

        public string GetJsonReviewFromFile(int index)
        {
            // TODO: Get file from cache if there , add if not
            string productReviewsJsonArray = File.ReadAllText(@"C:/temp/DataFiles/Automotive_5.json");

            // Deserialize to type
            List<ProductReview> productReviews  = JsonConvert.DeserializeObject<List<ProductReview>>(productReviewsJsonArray);
            
            // Retrieve review at index specified
            ProductReview aProductReview = productReviews.Select(r => r).ElementAt(index);

            // Convert back to json
            var reviewJson = JsonConvert.SerializeObject(aProductReview);

            return reviewJson;
        }
        public string GetJsonReviewsFromFile()
        {
            JObject reviews = JObject.Parse(File.ReadAllText(@"source/Automotive_5.json"));

            return reviews.ToString();
        }
    }
}

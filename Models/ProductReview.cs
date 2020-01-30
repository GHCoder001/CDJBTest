using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;


namespace Models
{
    public class ProductReview
    {
        public string ReviewerId { get; set; }
        public string ASIN { get; set; } // Maps to Product ID
        public string ReviewerName { get; set; }
        public int[] Helpful { get; set; }
        public string ReviewText { get; set; }
        public double Overall { get; set; }
        public string Summary { get; set; }
        [JsonConverter(typeof(MicrosecondEpochConverter))]
        public DateTime UnixReviewTime { get; set; }
        public DateTime ReviewTime { get; set; }
 
    }
    public class MicrosecondEpochConverter : DateTimeConverterBase
    {
       // Source: https://stackoverflow.com/questions/19971494/how-to-deserialize-a-unix-timestamp-%ce%bcs-to-a-datetime-from-json


        private static readonly DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue(((DateTime)value - _epoch).TotalMilliseconds + "000");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null) { return null; }
            return _epoch.AddMilliseconds((long)reader.Value / 1000d);
        }
    }
}


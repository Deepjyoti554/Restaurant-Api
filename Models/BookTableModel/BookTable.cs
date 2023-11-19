using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace RestaurantApi.Models.BookTableModel
{
    [BsonIgnoreExtraElements]
    public class BookTable
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("customerId")]
        public string CustomerId { get; set; } = string.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("date")]
        public string Date { get; set; } = string.Empty;

        [BsonElement("time")]
        public string Time { get; set; } = string.Empty;

        [BsonElement("status")]
        public string Status { get; set; } = string.Empty;

        [BsonElement("tableNo")]
        public double TableNo { get; set; } = double.MinValue;
    }
}

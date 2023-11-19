using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using RestaurantApi.Models.IngredientModel;
using RestaurantApi.Models.ItemModel;

namespace RestaurantApi.Models.OrderModel
{
    [BsonIgnoreExtraElements]
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("customerId")]
        public string CustomerId { get; set; } = String.Empty;

        [BsonElement("items")]
        public List<Item> Items { get; set; } = new List<Item>();

        [BsonElement("totalBill")]
        public double TotalPrice { get; set; } = Double.MaxValue;

        [BsonElement("status")]
        public string Status { get; set; } = String.Empty;

        [BsonElement("customization")]
        public string Customization { get; set; } = String.Empty;
    }
}

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using RestaurantApi.Models.ItemModel;
using RestaurantApi.Models.OrderModel;

namespace RestaurantApi.Models.CustomerModel
{
    [BsonIgnoreExtraElements]
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("customerId")]
        public string CustomerId { get; set; } = string.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("email")]
        public string Email { get; set; } = string.Empty;

        [BsonElement("password")]
        public string Password { get; set; } = string.Empty;

        [BsonElement("role")]
        public string Role { get; set; } = string.Empty;

        [BsonElement("cart")]
        public List<Item> Cart { get; set; } = new List<Item>();

        [BsonElement("status")]
        public string Status { get; set; } = string.Empty;


        [BsonElement("totalBill")]
        public double TotalBill { get; set; } = double.MaxValue;

        [BsonElement("customization")]
        public string Customization { get; set; } = string.Empty;
    }
}

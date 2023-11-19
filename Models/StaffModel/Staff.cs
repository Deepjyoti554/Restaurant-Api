using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using RestaurantApi.Models.ItemModel;
using RestaurantApi.Models.CustomerModel;

namespace RestaurantApi.Models.StaffModel
{
    [BsonIgnoreExtraElements]
    public class Staff
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;

        [BsonElement("email")]
        public string Email { get; set; } = String.Empty;

        [BsonElement("password")]
        public string Password { get; set; } = String.Empty;

        [BsonElement("role")]
        public string Role { get; set; } = String.Empty;

        [BsonElement("shift")]
        public string Shift { get; set; } = String.Empty;

        [BsonElement("rating")]
        public double Rating { get; set; } = Double.MaxValue;

        [BsonElement("customers")]
        public Customer Customers { get; set; } = new Customer();

    }
}

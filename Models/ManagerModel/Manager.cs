using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using RestaurantApi.Models.ItemModel;

namespace RestaurantApi.Models.ManagerModel
{
    [BsonIgnoreExtraElements]
    public class Manager
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
    }
}

using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace RestaurantApi.Models.IngredientModel
{
    [BsonIgnoreExtraElements]
    public class Ingredient
    {

        [BsonElement("ingredientId")]
        public string IngredientId { get; set; } = String.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;

        [BsonElement("quantity")]
        public double Quantity { get; set; } = Double.MaxValue;
    }
}

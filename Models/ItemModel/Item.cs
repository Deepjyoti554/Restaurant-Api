using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using RestaurantApi.Models.IngredientModel;

namespace RestaurantApi.Models.ItemModel
{
    [BsonIgnoreExtraElements]
    public class Item
    {

        [BsonElement("itemId")]
        public string ItemId { get; set; } = String.Empty;

        [BsonElement("itemName")]
        public string Name { get; set; } = String.Empty;

        [BsonElement("itemImage")]
        public string Image { get; set; } = String.Empty;


        [BsonElement("itemDescription")]
        public string Description { get; set; } = String.Empty;

        [BsonElement("category")]
        public string Category { get; set; } = String.Empty;

        [BsonElement("price")]
        public double Price { get; set; } = Double.MinValue;

        [BsonElement("rating")]
        public double Rating { get; set; } = double.MinValue;

        [BsonElement("quantity")]
        public double Quantity { get; set; } = 1;

        [BsonElement("customization")]
        public string Customization { get; set; } = string.Empty;

        [BsonElement("ingredients")]
        public Ingredient Ingredients { get; set; } = new Ingredient();

    }
}

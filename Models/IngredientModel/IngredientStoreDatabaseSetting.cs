namespace RestaurantApi.Models.IngredientModel
{
    public class IngredientStoreDatabaseSetting : IIngredientStoreDatabaseSetting
    {
        public string IngredientCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}

namespace RestaurantApi.Models.ItemModel
{
    public class ItemStoreDatabaseSetting : IItemStoreDatabseSetting
    {
        public string ItemCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}

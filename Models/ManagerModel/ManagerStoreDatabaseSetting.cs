namespace RestaurantApi.Models.ManagerModel
{
    public class ManagerStoreDatabaseSetting : IManagerStoreDatabaseSetting
    {
        public string ManagerCollectionName { get; set; } = String.Empty;

        public string ConnectionString { get; set; } = String.Empty;

        public string DatabaseName { get; set; } = String.Empty;
    }
}

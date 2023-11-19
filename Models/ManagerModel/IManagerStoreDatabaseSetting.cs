namespace RestaurantApi.Models.ManagerModel
{
    public interface IManagerStoreDatabaseSetting
    {
        string ManagerCollectionName { get; }

        string ConnectionString { get; }

        string DatabaseName { get; }
    }
}

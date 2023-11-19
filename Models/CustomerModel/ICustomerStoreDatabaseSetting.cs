namespace RestaurantApi.Models.CustomerModel
{
    public interface ICustomerStoreDatabaseSetting
    {
        string CustomerCollectionName { get; }

        string ConnectionString { get; }

        string DatabaseName { get; }
    }
}

namespace RestaurantApi.Models.OrderModel
{
    public interface IOrderStoreDatabaseSetting
    {
        string OrderCollectionName { get; }

        string ConnectionString { get;}

        string DatabaseName { get; }
    }
}

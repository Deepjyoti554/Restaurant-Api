namespace RestaurantApi.Models.OrderModel
{
    public class OrderStoreDatabaseSetting: IOrderStoreDatabaseSetting
    {
        public string OrderCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}

namespace RestaurantApi.Models.CustomerModel
{
    public class CustomerStoreDatabaseSetting : ICustomerStoreDatabaseSetting
    {
        public string CustomerCollectionName { get; set; } = String.Empty;

        public string ConnectionString { get; set; } = String.Empty;

        public string DatabaseName { get; set; } = String.Empty;
    }
}

namespace RestaurantApi.Models.StaffModel
{
    public class StaffStoreDatabaseSetting : IStaffStoreDatabaseSetting
    {
        public string StaffCollectionName { get; set; } = String.Empty;

        public string ConnectionString { get; set; } = String.Empty;

        public string DatabaseName { get; set; } = String.Empty;
    }
}

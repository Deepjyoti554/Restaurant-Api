namespace RestaurantApi.Models.StaffModel
{
    public interface IStaffStoreDatabaseSetting
    {
        string StaffCollectionName { get; }

        string ConnectionString { get; }

        string DatabaseName { get; }
    }
}

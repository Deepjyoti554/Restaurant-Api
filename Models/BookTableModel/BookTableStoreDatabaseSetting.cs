namespace RestaurantApi.Models.BookTableModel
{
    public class BookTableStoreDatabaseSetting : IBookTableStoreDatabaseSetting
    {
        public string BookTableCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName  {  get; set; } = string.Empty;
    }
}

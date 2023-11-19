namespace RestaurantApi.Models.BookTableModel
{
    public interface IBookTableStoreDatabaseSetting
    {
        public string BookTableCollectionName { get; set; }

        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}

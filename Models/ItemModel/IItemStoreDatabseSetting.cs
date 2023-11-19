namespace RestaurantApi.Models.ItemModel
{
    public interface IItemStoreDatabseSetting
    {
        string ItemCollectionName { get;}

        string ConnectionString { get;}

        string DatabaseName { get;}
    }
}

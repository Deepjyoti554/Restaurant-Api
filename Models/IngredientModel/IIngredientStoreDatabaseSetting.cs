namespace RestaurantApi.Models.IngredientModel
{
    public interface IIngredientStoreDatabaseSetting
    {
        string IngredientCollectionName { get;}

        string ConnectionString { get;}

        string DatabaseName { get;}
    }
}

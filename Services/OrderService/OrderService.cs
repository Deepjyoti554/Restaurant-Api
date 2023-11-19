using MongoDB.Bson;
using MongoDB.Driver;

using RestaurantApi.Models.OrderModel;

namespace RestaurantApi.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IMongoCollection<Order> _orders;

        public OrderService(IOrderStoreDatabaseSetting settings, IMongoClient mongoClient) {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _orders = database.GetCollection<Order>(settings.OrderCollectionName);
        }

        Order IOrderService.Create(Order order)
        {
            order.Id = ObjectId.GenerateNewId().ToString();
            foreach (var item in order.Items)
            {
                item.ItemId = ObjectId.GenerateNewId().ToString();
                item.Ingredients.IngredientId = ObjectId.GenerateNewId().ToString();
            }
            _orders.InsertOne(order);
            return order;
        }

        List<Order> IOrderService.Get()
        {
            return _orders.Find(Order => true).ToList();
        }

        Order IOrderService.Get(string id)
        {
                return _orders.Find(Order => Order.Id == id).FirstOrDefault();
        }

        void IOrderService.Remove(string id)
        {
            _orders.DeleteOne(Order => Order.Id == id);
        }

        void IOrderService.Update(string id, Order newOrder)
        {
            var filter = Builders<Order>.Filter.Eq("_id", new ObjectId(id));

            var update = Builders<Order>.Update
                .Set("customerId", newOrder.CustomerId)
                .Set("items", newOrder.Items)
                .Set("totalBill", newOrder.TotalPrice)
                .Set("status", newOrder.Status)
                .Set("cutomization", newOrder.Customization);

            _orders.UpdateOne(filter, update);
        }
    }
}

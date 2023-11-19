using MongoDB.Bson;
using MongoDB.Driver;
using RestaurantApi.Models.CustomerModel;
using RestaurantApi.Models.ManagerModel;
using RestaurantApi.Models.OrderModel;

namespace RestaurantApi.Services.ManagerService
{
    public class ManagerService : IManagerService
    {
        private readonly IMongoCollection<Manager> _manager;

        public ManagerService(IManagerStoreDatabaseSetting setting, IMongoClient mongoClient ) {
            var database = mongoClient.GetDatabase(setting.DatabaseName);
            _manager = database.GetCollection<Manager>(setting.ManagerCollectionName);
        }
        public Manager Create(Manager manager)
        {
            manager.Id = ObjectId.GenerateNewId().ToString();
            _manager.InsertOne(manager);
            return manager;
        }

        public List<Manager> Get()
        {
            return _manager.Find(Manager => true).ToList();
        }

        public Manager Get(string id)
        {
            return _manager.Find(Manager => Manager.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _manager.DeleteOne(Manager => Manager.Id == id);
        }

        public void Update(string id, Manager manager)
        {
            manager.Id = id;

            _manager.ReplaceOneAsync(t => t.Id == id, manager);
        }
    }
}

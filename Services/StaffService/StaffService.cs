using MongoDB.Bson;
using MongoDB.Driver;
using RestaurantApi.Models.CustomerModel;
using RestaurantApi.Models.OrderModel;
using RestaurantApi.Models.StaffModel;

namespace RestaurantApi.Services.StaffService
{
    public class StaffService : IStaffService
    {
        private readonly IMongoCollection<Staff> _staff;

        public StaffService(IStaffStoreDatabaseSetting setting, IMongoClient mongoClient) {
            var database = mongoClient.GetDatabase(setting.DatabaseName);
            _staff = database.GetCollection<Staff>(setting.StaffCollectionName);
        } 
        
        public Staff Create(Staff staff)
        {
            staff.Id = ObjectId.GenerateNewId().ToString();
            
            staff.Customers.Id = ObjectId.GenerateNewId().ToString();
            return staff;
        }

        public List<Staff> Get()
        {
            return _staff.Find(Stuff => true).ToList();
        }

        public Staff Get(string id)
        {
            return _staff.Find(Staff => Staff.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _staff.DeleteOne(Staff => Staff.Id == id);
        }

        public void Update(string id, Staff staff)
        {
            staff.Id = id;

            _staff.ReplaceOneAsync(t => t.Id == id, staff);
        }
    }
}

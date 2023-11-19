using MongoDB.Bson;
using MongoDB.Driver;
using RestaurantApi.Models.BookTableModel;
using RestaurantApi.Models.CustomerModel;
using RestaurantApi.Models.OrderModel;

namespace RestaurantApi.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly IMongoCollection<Customer> _customer;

        public CustomerService(ICustomerStoreDatabaseSetting setting, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(setting.DatabaseName);
            _customer = database.GetCollection<Customer>(setting.CustomerCollectionName);
        }


        public Customer Create(Customer customer)
        {
            //string idString = customer.Id.ToString();
            //customer.Id = idString;
            customer.Id = ObjectId.GenerateNewId().ToString();
            foreach (var item in customer.Cart)

            {
                item.ItemId = ObjectId.GenerateNewId().ToString();
                item.Ingredients.IngredientId = ObjectId.GenerateNewId().ToString();
            }
            _customer.InsertOne(customer);
            return customer;
        }

        public List<Customer> Get()
        {
            return _customer.Find(Customer => true).ToList();
        }

        public Customer Get(string id)
        {
            return _customer.Find(Customer => Customer.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _customer.DeleteOne(Customer => Customer.Id == id);
        }


        public void Update(string id, Customer customer)
        {
            //var filter = Builders<Customer>.Filter.Eq("_id", id);
            //customer.Carts.ItemId = ObjectId.GenerateNewId().ToString();

            //var update = Builders<Customer>.Update
            //.Set("customerId", customer.CustomerId)
            //.Set("name", customer.Name)
            //.Set("email", customer.Email)
            //.Set("password", customer.Password)
            //.Set("orders", customer.Orders);

            //_customer.UpdateOne(filter, update);

            customer.Id = id;

            _customer.ReplaceOneAsync(t => t.Id == id, customer);
        }
    }
}

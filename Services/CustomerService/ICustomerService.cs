using RestaurantApi.Models.BookTableModel;
using RestaurantApi.Models.CustomerModel;

namespace RestaurantApi.Services.CustomerService
{
    public interface ICustomerService
    {
        List<Customer> Get();
        Customer Get(string id);
        Customer Create(Customer customer);
        void Update(string id, Customer customer);
        void Remove(string id);
    }
}

using RestaurantApi.Models.CustomerModel;
using RestaurantApi.Models.ManagerModel;

namespace RestaurantApi.Services.ManagerService
{
    public interface IManagerService
    {
        List<Manager> Get();
        Manager Get(string id);
        Manager Create(Manager manager);
        void Update(string id, Manager manager);
        void Remove(string id);
    }
}

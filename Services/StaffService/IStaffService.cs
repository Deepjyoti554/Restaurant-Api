using RestaurantApi.Models.CustomerModel;
using RestaurantApi.Models.OrderModel;
using RestaurantApi.Models.StaffModel;

namespace RestaurantApi.Services.StaffService
{
    public interface IStaffService
    {
        List<Staff> Get();

        Staff Get(string id);
        Staff Create(Staff staff);
        void Update(string id, Staff staff);
        void Remove(string id);
    }
}

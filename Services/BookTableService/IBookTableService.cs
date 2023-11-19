using RestaurantApi.Models.BookTableModel;
using RestaurantApi.Models.OrderModel;

namespace RestaurantApi.Services.BookTableService
{
    public interface IBookTableService
    {
        List<BookTable> Get();
        BookTable Get(string id);
        BookTable Create(BookTable bookTable);
        void Update(string id, BookTable bookTable);
        void Remove(string id);
    }
}

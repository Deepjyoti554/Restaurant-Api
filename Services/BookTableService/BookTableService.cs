using MongoDB.Bson;
using MongoDB.Driver;
using RestaurantApi.Models.BookTableModel;
using RestaurantApi.Models.OrderModel;

namespace RestaurantApi.Services.BookTableService
{
    public class BookTableService: IBookTableService
    {
        private readonly IMongoCollection<BookTable> _bookTable;

        public BookTableService(IBookTableStoreDatabaseSetting settings, IMongoClient mongoClient) {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _bookTable = database.GetCollection<BookTable>(settings.BookTableCollectionName);
        }

        public BookTable Create(BookTable bookTable)
        {
            bookTable.Id = ObjectId.GenerateNewId().ToString();
            _bookTable.InsertOne(bookTable);
            return bookTable;
        }

        public List<BookTable> Get()
        {
            return _bookTable.Find(BookTable => true).ToList();
        }

        public BookTable Get(string id)
        {
            return _bookTable.Find(BookTable => BookTable.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _bookTable.DeleteOne(BookTable => BookTable.Id == id);
        }

        public void Update(string id, BookTable newTable)
        {
            var filter = Builders<BookTable>.Filter.Eq("_id", id);

            var update = Builders<BookTable>.Update
                .Set("customerId", newTable.CustomerId)
                .Set("name", newTable.Name)
                .Set("date", newTable.Date)
                .Set("time", newTable.Time)
                .Set("status", newTable.Status);

            _bookTable.UpdateOne(filter, update);
        }
    }
}

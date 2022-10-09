using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CountryCity.Models.MongoDB.Services
{
    public class CountriesService
    {
        private readonly IMongoCollection<CountryMongoDB> _booksCollection;

        public CountriesService(
            IOptions<CountryCityNoSqlDatabaseSettings> bookStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                bookStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                bookStoreDatabaseSettings.Value.DatabaseName);

            _booksCollection = mongoDatabase.GetCollection<CountryMongoDB>(
                bookStoreDatabaseSettings.Value.BooksCollectionName);
        }

        public async Task<List<CountryMongoDB>> GetAsync() =>
            await _booksCollection.Find(_ => true).ToListAsync();

        public async Task<CountryMongoDB?> GetAsync(string id) =>
            await _booksCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(CountryMongoDB newBook) =>
            await _booksCollection.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, CountryMongoDB updatedBook) =>
            await _booksCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _booksCollection.DeleteOneAsync(x => x.Id == id);


    }
}

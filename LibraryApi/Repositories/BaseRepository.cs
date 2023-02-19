using LibraryApi.Core;
using LibraryApi.Models;
using LibraryApi.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace LibraryApi.Repositories;

public abstract class BaseRepository<T>
    where T : BaseModel
{
    private readonly IMongoDatabase _database;

    public BaseRepository(
        IOptions<DatabaseSettings> databaseSettings)
    {
        var mongoClient = new MongoClient(
            databaseSettings.Value.ConnectionString);

        _database = mongoClient.GetDatabase(
            databaseSettings.Value.DatabaseName);
    }

    public async Task CreateAsync(T model) =>
        await GetCollection().InsertOneAsync(model);

    public async Task<List<T>> GetAsync() =>
        await GetCollection().Find(_ => true).ToListAsync();

    public async Task<T> GetAsync(string id) =>
        await GetCollection().Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task UpdateAsync(string id, T updatedModel) =>
        await GetCollection().ReplaceOneAsync(x => x.Id == id, updatedModel);

    public async Task DeleteAsync(string id) =>
        await GetCollection().DeleteOneAsync(x => x.Id == id);

    private static string? GetCollectionName()
    {
        return (typeof(T).GetCustomAttributes(typeof(BsonCollectionAttribute), true).FirstOrDefault()
            as BsonCollectionAttribute)?.CollectionName;
    }

    private IMongoCollection<T> GetCollection() =>
        _database.GetCollection<T>(GetCollectionName());
}

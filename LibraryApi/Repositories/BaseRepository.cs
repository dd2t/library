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
        IOptions<BookStoreDatabaseSettings> databaseSettings)
    {
        var mongoClient = new MongoClient(
            databaseSettings.Value.ConnectionString);

        _database = mongoClient.GetDatabase(
            databaseSettings.Value.DatabaseName);
    }

    private static string? GetCollectionName()
    {
        return (typeof(T).GetCustomAttributes(typeof(BsonCollectionAttribute), true).FirstOrDefault()
            as BsonCollectionAttribute)?.CollectionName;
    }

    public async Task CreateAsync(T model)
    {
        var collectionName = GetCollectionName();
        var collection = _database.GetCollection<T>(collectionName);
        await collection.InsertOneAsync(model);
    }

    public async Task<List<T>> GetAsync()
    {
        var collectionName = GetCollectionName();
        var collection = _database.GetCollection<T>(collectionName);
        return await collection.Find(_ => true).ToListAsync();
    }

    public async Task<T> GetAsync(string id)
    {
        var collectionName = GetCollectionName();
        var collection = _database.GetCollection<T>(collectionName);
        return await collection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task UpdateAsync(string id, T updatedModel)
    {
        var collectionName = GetCollectionName();
        var collection = _database.GetCollection<T>(collectionName);
        await collection.ReplaceOneAsync(x => x.Id == id, updatedModel);
    }

    public async Task DeleteAsync(string id)
    {
        var collectionName = GetCollectionName();
        var collection = _database.GetCollection<T>(collectionName);
        await collection.DeleteOneAsync(x => x.Id == id);
    }
}

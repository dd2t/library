using LibraryApi.Models;
using LibraryApi.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace LibraryApi.Repositories;

public class BooksRepository : BaseRepository<Book>
{
    public BooksRepository(IMongoClient mongoClient, 
        IOptions<DatabaseSettings> databaseSettings) : base(mongoClient, databaseSettings) { }
}

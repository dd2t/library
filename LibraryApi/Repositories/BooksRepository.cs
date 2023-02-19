using LibraryApi.Models;
using LibraryApi.Settings;
using Microsoft.Extensions.Options;

namespace LibraryApi.Repositories;

public class BooksRepository : BaseRepository<Book>
{
    public BooksRepository(IOptions<DatabaseSettings> databaseSettings) : base(databaseSettings)
    {
    }
}

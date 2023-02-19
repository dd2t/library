using System.Text.Json.Serialization;
using LibraryApi.Core;
using MongoDB.Bson.Serialization.Attributes;

namespace LibraryApi.Models;

[BsonCollectionAttribute("Books")]
public record Book : BaseModel
{
    [BsonElement("Name")]
    [JsonPropertyName("Name")]
    public string BookName { get; set; } = null!;

    public decimal Price { get; set; }

    public string Category { get; set; } = null!;

    public string Author { get; set; } = null!;
}

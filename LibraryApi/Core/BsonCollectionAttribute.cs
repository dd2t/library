namespace LibraryApi.Core;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class BsonCollectionAttribute : Attribute
{
    public string CollectionName { get; init; }
    public BsonCollectionAttribute(string collectionName) => 
        CollectionName = collectionName;
}

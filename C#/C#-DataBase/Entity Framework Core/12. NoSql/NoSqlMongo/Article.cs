using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NoSqlMongo
{
    class Article : BsonDocument
    {
        [BsonElement]
        public string Name { get; set; }
    }
}

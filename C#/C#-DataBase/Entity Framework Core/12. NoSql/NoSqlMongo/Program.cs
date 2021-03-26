using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace NoSqlMongo
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new MongoClient(
                "mongodb://127.0.0.1:27017");

            IMongoDatabase database = client.GetDatabase("test");

            var collection = database.GetCollection<BsonDocument>("softuniArticles");

            //3. Create a new article
            collection.InsertOne(new BsonDocument
            {
                {"Author", "Steve Jobs" },
                {"Date", "05-05-2005" },
                {"Name", "The story of Apple" },
                {"Rating", "60" }
            });

            List<BsonDocument> allArticles = collection.Find(new BsonDocument { }).ToList();

            foreach (var article in allArticles)
            {
                //2. Read
                string name = article.GetElement("name").Value.AsString;
                //Console.WriteLine(name);

                //4. Update
                int newRating = int.Parse(article.GetElement("rating").Value.AsString) + 10;

                var filterQuery = Builders<BsonDocument>.Filter.Eq("_id", article.GetElement("_id").Value);

                var updateQuery = Builders<BsonDocument>.Update.Set("rating", newRating.ToString());

                collection.UpdateOne(filterQuery, updateQuery);

                Console.WriteLine($"{name} : rating: {article.GetElement("rating").Value}");

                //TODO:
                //5. Delete
            }
        }
    }
}

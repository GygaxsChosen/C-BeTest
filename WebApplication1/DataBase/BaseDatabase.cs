using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebApplication1.DataBase
{
    public class BaseDatabase<GenericObject>
    {
        public static void UpdateOne(String collectionToHit, GenericObject newObject, string valueToUpdate)
        {
            var client = new MongoClient("mongodb+srv://Jodeal:3g9nHaFa4n4ypd5T@freedb.s0mt1.mongodb.net/FreeDb?retryWrites=true&w=majority");
            var database = client.GetDatabase("FreeDB");

            var collection = database.GetCollection<GenericObject>(collectionToHit);
            var IdValueOfObject = typeof(GenericObject).GetProperty("RealId").GetValue(newObject);

            var filter = Builders<GenericObject>.Filter.Eq("RealId", IdValueOfObject.ToString());

            var somethign = typeof(GenericObject).GetProperty(valueToUpdate).GetValue(newObject);


            var update = Builders<GenericObject>.Update.Set(valueToUpdate, somethign);
            var newItemToUpdate = collection.UpdateOne(filter, update);
                }

        public static List<GenericObject> FindMany(string collectionToHit)
        {
            var client = new MongoClient("mongodb+srv://Jodeal:3g9nHaFa4n4ypd5T@freedb.s0mt1.mongodb.net/FreeDb?retryWrites=true&w=majority");
            var database = client.GetDatabase("FreeDB");

            var collection = database.GetCollection<BsonDocument>(collectionToHit);

            var filter = Builders<BsonDocument>.Filter.Empty;
            var result = collection.Find(filter).ToList();
            List<GenericObject> ParsedResults = new List<GenericObject>();

            foreach (BsonDocument doc in result)
            {
                GenericObject tempGeneric = BsonSerializer.Deserialize<GenericObject>(doc);
                ParsedResults.Add(tempGeneric);
            }
            return ParsedResults;
        }
        public static void CreateOne(string collectionToHit, GenericObject newObject)
        {
            MongoClient client = new MongoClient("mongodb+srv://Jodeal:3g9nHaFa4n4ypd5T@freedb.s0mt1.mongodb.net/FreeDb?retryWrites=true&w=majority");
            var database = client.GetDatabase("FreeDB");

            var collection = database.GetCollection<GenericObject>(collectionToHit);
      
            collection.InsertOne(newObject);
        }
        public static GenericObject UpdateAndReplaceOne(string collectionToHit, GenericObject newObject)
        {
            MongoClient client = new MongoClient("mongodb+srv://Jodeal:3g9nHaFa4n4ypd5T@freedb.s0mt1.mongodb.net/FreeDb?retryWrites=true&w=majority");
            var database = client.GetDatabase("FreeDB");

            var collection = database.GetCollection<GenericObject>(collectionToHit);
            var IdValueOfObject = typeof(GenericObject).GetProperty("RealId").GetValue(newObject);
            var filter = Builders<GenericObject>.Filter.Eq("RealId", IdValueOfObject.ToString());

            collection.ReplaceOne(filter, newObject);
            return newObject;

        }

        public static GenericObject FindOne(string collectionToHit, string Id)
        {
            var client = new MongoClient("mongodb+srv://Jodeal:3g9nHaFa4n4ypd5T@freedb.s0mt1.mongodb.net/FreeDb?retryWrites=true&w=majority");
            var database = client.GetDatabase("FreeDB");
            var filter = Builders<BsonDocument>.Filter.Eq("RealId", Id);

            var collection = database.GetCollection<BsonDocument>(collectionToHit);
            var result = collection.Find(filter).ToList();
            if(result.Count == 1)
            {
             GenericObject tempGeneric = BsonSerializer.Deserialize<GenericObject>(result[0]);
             return tempGeneric;
            }
            else
            {
                throw new InvalidOperationException("object not correctrlt found");
            }
           
           
          


        }
        public static void DeleteOne(string CollectionToHit, GenericObject objectToDelete)
        {
            var client = new MongoClient("mongodb+srv://Jodeal:3g9nHaFa4n4ypd5T@freedb.s0mt1.mongodb.net/FreeDb?retryWrites=true&w=majority");
            var database = client.GetDatabase("FreeDB");

            var collection = database.GetCollection<Employee>(CollectionToHit);
            var IdValue = typeof(GenericObject).GetProperty("RealId").GetValue(objectToDelete);

            var result = collection.DeleteOne(a => a.RealId == IdValue.ToString()) ;

        }
    }
}

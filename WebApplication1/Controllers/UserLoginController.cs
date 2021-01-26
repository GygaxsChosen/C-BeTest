using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserLoginController : Controller
    {
        [HttpPost]
        public bool AttemptLogin(User attemptedLogin)
        {
            var client = new MongoClient("mongodb+srv://Jodeal:3g9nHaFa4n4ypd5T@freedb.s0mt1.mongodb.net/FreeDb?retryWrites=true&w=majority");
            var database = client.GetDatabase("FreeDB");

            var collection = database.GetCollection<BsonDocument>("UserNameAndPasswords");
            var filter = Builders<BsonDocument>.Filter.Eq("userName", attemptedLogin.userName);
            var result = collection.Find(filter).ToList();
            if(result.Count == 1)
            {
                var singleUser = result[0];
                User parsedValue = BsonSerializer.Deserialize<User>(singleUser);
            

                if(parsedValue.passWord == attemptedLogin.passWord)
                {
                    return true;
                }
                
            }
            return false;
        }
       
    }
}

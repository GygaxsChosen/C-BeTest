using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class User
    {
        private string UserName;
        private string Password;
        private string _Id;

        public string userName {
            get { return UserName; }
            set { UserName = value; } }

        public string passWord
        {
            get { return Password; }
            set { Password = value; }
        }
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        public User()
        {

        }

    }
}

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class DocumentationData
    {
        private string _Id;
        private string realId;
        private string documentationText;

            public string DocumentationText
        {
            get { return documentationText; }
            set { documentationText = value; }
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        public string RealId
        {
            get { return realId; }
            set { realId = value; }
        }
        public DocumentationData()
        {

        }

    }
}

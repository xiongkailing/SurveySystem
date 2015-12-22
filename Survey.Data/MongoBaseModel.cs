using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Data
{
    public class MongoBaseModel
    {
        public ObjectId _id { get; set; }
    }
}

using MongoDB.Bson;
using Survey.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Models
{
    public class Answer:MongoBaseModel
    {
        public int UserId { get; set; }
        public ObjectId QuestionId { get; set; }
        public string Description { get; set; }
    }
}

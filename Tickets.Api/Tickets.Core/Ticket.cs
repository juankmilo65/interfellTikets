using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Tickets.Core
{
    public class Ticket
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string User { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool Status { get; set; }
    }
}

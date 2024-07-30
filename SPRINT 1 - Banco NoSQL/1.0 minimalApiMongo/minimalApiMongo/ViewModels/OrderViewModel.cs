using minimalApiMongo.Domains;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace minimalApiMongo.ViewModels
{
    public class OrderViewModel
    {
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Date { get; set; }
        public string Status { get; set; }
        public string ClientId { get; set; }
        public List<string> ProductId { get; set; }
        public Dictionary<string, string> AdditionalAttributes { get; set; }
    }
}

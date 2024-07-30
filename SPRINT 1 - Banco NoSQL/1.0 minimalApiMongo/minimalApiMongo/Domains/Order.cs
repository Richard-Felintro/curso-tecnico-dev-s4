using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace minimalApiMongo.Domains
{
    public class Order
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("date")]
        public string? Date { get; set; }
        [BsonElement("status")]
        public string Status { get; set; }

        public Client Client { get; set; }
        public ICollection<Product> Products { get; set; }
        public Dictionary<string, string> AdditionalAttributes { get; set; }

        public Order()
        {
            AdditionalAttributes = new Dictionary<string, string>();
        }
    }
}
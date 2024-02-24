// Promotion.cs
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PromoAPI.Models
{
    public class Promotion()
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; } = 0;

        public Promotion(PromotionRequest promotionRequest) : this()
        {
            Id = ObjectId.GenerateNewId().ToString();
            Name = promotionRequest.Name;
            Description = promotionRequest.Description;
            Price = promotionRequest.Price;
        }
    }
}
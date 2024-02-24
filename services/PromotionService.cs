// PromotionService.cs

using PromoAPI.Models;
using MongoDB.Driver;

namespace PromoAPI.Services
{
    public class PromotionService
    {
        private readonly IMongoClient _mongoClient;
        private readonly IMongoCollection<Promotion> _promotions;

        public PromotionService(IMongoClient mongoClient)
        {
            _mongoClient = mongoClient;
            var database = _mongoClient.GetDatabase("PromoAPI");
            _promotions = database.GetCollection<Promotion>("Promotions");
        }

        public List<Promotion> Get() =>
            _promotions.Find(promotion => true).ToList();

        public Promotion Get(string name, decimal price) =>
            _promotions.Find<Promotion>(promotion => promotion.Name == name && promotion.Price == price).FirstOrDefault();

        public Promotion Get(string id) =>
            _promotions.Find<Promotion>(promotion => promotion.Id == id).FirstOrDefault();

        public Promotion Create(Promotion promotion)
        {
            _promotions.InsertOne(promotion);
            return promotion;
        }


        public void Update(string id, Promotion promotionIn) =>
                    _promotions.ReplaceOne(promotion => promotion.Id == id, promotionIn);

        public void Remove(Promotion promotionIn) =>
            _promotions.DeleteOne(promotion => promotion.Id == promotionIn.Id);

        public void Remove(string id) =>
            _promotions.DeleteOne(promotion => promotion.Id == id);
    }
}
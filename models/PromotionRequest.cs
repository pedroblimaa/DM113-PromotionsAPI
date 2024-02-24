namespace PromoAPI.Models
{
    public class PromotionRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public PromotionRequest()
        {
            Name = string.Empty;
            Description = string.Empty;
        }
    }
}
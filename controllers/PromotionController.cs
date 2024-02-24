using Microsoft.AspNetCore.Mvc;
using PromoAPI.Models;
using PromoAPI.Services;

namespace PromoAPI.Controllers;

[ApiController]
[Route("api/promo")]
public class PromotionController(PromotionService promotionService) : ControllerBase
{
    private readonly PromotionService _promotionService = promotionService;

    [HttpGet("Promotions")]
    public IActionResult GetPromotions()
    {
        return Ok("GetPromotions");
    }

    [HttpGet]
    public ActionResult<List<Promotion>> Get() => _promotionService.Get();

    [HttpGet("{id:length(24)}", Name = "GetPromotion")]
    public ActionResult<Promotion> Get(string id)
    {
        var promotion = _promotionService.Get(id);

        if (promotion == null)
        {
            return NotFound();
        }

        return promotion;
    }

    [HttpPost]
    public ActionResult<Promotion> Create(PromotionRequest promotionRequest)
    {
        var promotion = new Promotion(promotionRequest);

        var existingPromotion = _promotionService.Get(promotion.Name, promotion.Price);
        if (existingPromotion != null)
        {
            return BadRequest("Promotion with same name and price already exist");
        }

        _promotionService.Create(promotion);

        return CreatedAtRoute("GetPromotion", new { id = promotion.Id }, promotion);
    }

    [HttpPut("{id:length(24)}")]
    public IActionResult Update(string id, Promotion promotionIn)
    {
        var promotion = _promotionService.Get(id);

        if (promotion == null)
        {
            return NotFound();
        }

        promotionIn.Id = promotion.Id;
        _promotionService.Update(id, promotionIn);
        var updated = _promotionService.Get(id);

        return Ok(updated);
    }

    [HttpDelete("{id:length(24)}")]
    public IActionResult Delete(string id)
    {
        var promotion = _promotionService.Get(id);

        if (promotion == null)
        {
            return NotFound();
        }

        _promotionService.Remove(promotion.Id);

        return NoContent();
    }
}
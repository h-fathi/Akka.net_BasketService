using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NewhouseIT.BasketService.Baskets.Routes
{
    [Route("/baskets")]
    [ApiController]
    public class BasketApiController: ControllerBase
    {
        private GetBasket GetBasket { get; }
        private AddItemToBasket AddItemToBasket { get; }
        private RemoveItemFromBasket RemoveItemFromBasket { get; }

        public BasketApiController(GetBasket getBasket, AddItemToBasket addItemToBasket, RemoveItemFromBasket removeItemFromBasket)
        {
            this.GetBasket = getBasket;
            this.AddItemToBasket = addItemToBasket;
            this.RemoveItemFromBasket = removeItemFromBasket;
        }
        [HttpGet("{customerId}")] public async Task<Basket> Get(int customerId)
        {
            var result = await this.GetBasket.Execute(customerId);
            return result;
        }

        [HttpPost("{customerId}/add")] public async Task<IActionResult> AddOrUpdateItem(int customerId, [FromBody] ApiDsl.AddItem item)
        {
            var result = await this.AddItemToBasket.Execute(customerId, item.ProductId, item.Amount);
            return result;
        }

        [HttpDelete("{customerId}/items/{basketItemId}")] public async Task<IActionResult> DeleteItem(int customerId, Guid basketItemId)
        {
            var result = await this.RemoveItemFromBasket.Execute(customerId, basketItemId);
            return result;
        }
    }
}

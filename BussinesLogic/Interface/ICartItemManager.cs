using DTO;
using System.Collections.Generic;

namespace BussinesLogic.Interface
{
    public interface ICartItemManager
    {
        int AddToCart(CartItemDto cartItem);
        IEnumerable<CartItemDto> GetCartItemsByUserId(int userId);
        void RemoveFromCart(int cartItemId);
    }
}

using DTO;
using System.Collections.Generic;

namespace DAL.Interface
{
    public interface ICartItemDal
    {
        int AddCartItem(CartItemDto cartItem);
        IEnumerable<CartItemDto> GetCartItemsByUserId(int userId);
        void RemoveCartItem(int cartItemId);
    }
}

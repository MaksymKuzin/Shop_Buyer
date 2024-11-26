using BussinesLogic.Interface;
using DAL.Interface;
using DTO;
using System.Collections.Generic;

namespace BussinesLogic.Concrete
{
    public class CartItemManager : ICartItemManager
    {
        private readonly ICartItemDal _cartItemDal;

        public CartItemManager(ICartItemDal cartItemDal)
        {
            _cartItemDal = cartItemDal;
        }

        public int AddToCart(CartItemDto cartItem)
        {
            return _cartItemDal.AddCartItem(cartItem);
        }

        public IEnumerable<CartItemDto> GetCartItemsByUserId(int userId)
        {
            return _cartItemDal.GetCartItemsByUserId(userId);
        }

        public void RemoveFromCart(int cartItemId)
        {
            _cartItemDal.RemoveCartItem(cartItemId);
        }
    }
}

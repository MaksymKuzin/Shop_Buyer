using Microsoft.Data.SqlClient;
using DTO;
using System;
using System.Collections.Generic;
using DAL.Interface;

namespace DAL.Concrete
{
    public class CartItemDal : ICartItemDal
    {
        private readonly string _connectionString;

        public CartItemDal(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int AddCartItem(CartItemDto cartItem)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("INSERT INTO CartItems (UserId, ProductId, Quantity) OUTPUT INSERTED.CartItemId VALUES (@UserId, @ProductId, @Quantity)", connection);
                command.Parameters.AddWithValue("@UserId", cartItem.UserId);
                command.Parameters.AddWithValue("@ProductId", cartItem.ProductId);
                command.Parameters.AddWithValue("@Quantity", cartItem.Quantity);

                connection.Open();
                return (int)command.ExecuteScalar();
            }
        }

        public IEnumerable<CartItemDto> GetCartItemsByUserId(int userId)
        {
            var cartItems = new List<CartItemDto>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT CartItemId, UserId, ProductId, Quantity FROM CartItems WHERE UserId = @UserId", connection);
                command.Parameters.AddWithValue("@UserId", userId);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cartItems.Add(new CartItemDto
                        {
                            CartItemId = reader.GetInt32(0),
                            UserId = reader.GetInt32(1),
                            ProductId = reader.GetInt32(2),
                            Quantity = reader.GetInt32(3)
                        });
                    }
                }
            }

            return cartItems;
        }

        public void RemoveCartItem(int cartItemId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("DELETE FROM CartItems WHERE CartItemId = @CartItemId", connection);
                command.Parameters.AddWithValue("@CartItemId", cartItemId);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    throw new Exception("Cart item removal failed. No rows affected.");
                }
            }
        }
    }
}

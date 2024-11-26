using Microsoft.Data.SqlClient;
using DTO;
using System;
using System.Collections.Generic;
using DAL.Interface;

namespace DAL.Concrete
{
    public class ProductDal : IProductDal
    {
        private readonly string _connectionString;

        public ProductDal(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ProductDto> GetProductsByCategoryId(int categoryId)
        {
            var products = new List<ProductDto>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT ProductId, Name, Price, Description FROM Products WHERE CategoryId = @CategoryId", connection);
                command.Parameters.AddWithValue("@CategoryId", categoryId);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new ProductDto
                        {
                            ProductId = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Price = reader.GetDecimal(2),
                            Description = reader.IsDBNull(3) ? null : reader.GetString(3)
                        });
                    }
                }
            }

            return products;
        }

        public IEnumerable<ProductDto> SearchProductsByName(string productName)
        {
            var products = new List<ProductDto>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT ProductId, Name, Price, Description FROM Products WHERE Name LIKE @ProductName", connection);
                command.Parameters.AddWithValue("@ProductName", "%" + productName + "%");

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new ProductDto
                        {
                            ProductId = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Price = reader.GetDecimal(2),
                            Description = reader.IsDBNull(3) ? null : reader.GetString(3)
                        });
                    }
                }
            }

            return products;


        }

        public IEnumerable<CategoryDto> GetAllCategories()
        {
            var categories = new List<CategoryDto>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT CategoryId, Name, Description FROM Categories", connection);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        categories.Add(new CategoryDto
                        {
                            CategoryId = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Description = reader.IsDBNull(2) ? null : reader.GetString(2)
                        });
                    }
                }
            }

            return categories;
        }
    }
}

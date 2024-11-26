using Microsoft.Data.SqlClient;
using DTO;
using System;
using System.Collections.Generic;
using DAL.Interface;

namespace DAL.Concrete
{
    public class CategoryDal : ICategoryDal
    {
        private readonly string _connectionString;

        public CategoryDal(string connectionString)
        {
            _connectionString = connectionString;
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

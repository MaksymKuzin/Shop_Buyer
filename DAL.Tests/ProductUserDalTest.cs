using NUnit.Framework;
using Microsoft.Extensions.Configuration;
using DAL.Concrete;
using DTO;
using System;
using System.IO;
using System.Collections.Generic;

[TestFixture]
public class ProductDalTests
{
    private string _connectionString;
    private ProductDal _productDal;

    [SetUp]
    public void SetUp()
    {
        
        string basePath = Directory.GetCurrentDirectory();
        string configFilePath = Path.Combine(basePath, @"C:\\VS\\Shop\\ConsolShop\\appsettings.json");

        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile(configFilePath)
            .Build();

       
        _connectionString = configuration.GetConnectionString("Shop") ?? throw new InvalidOperationException("Connection string is missing.");

        
        _productDal = new ProductDal(_connectionString);
    }

    [Test]
    public void GetProductsByCategoryId_ShouldReturnProductsForValidCategory()
    {
        
        int categoryId = 1;

        
        var products = _productDal.GetProductsByCategoryId(categoryId);

        
        Assert.NotNull(products, "Products list should not be null.");
        Assert.That(products, Is.All.Matches<ProductDto>(
            product => product.ProductId > 0 && product.CategoryId == categoryId),
            $"All products should belong to category with ID {categoryId}.");
    }

    [Test]
    public void SearchProductsByName_ShouldReturnMatchingProducts()
    {
       
        string productName = "Phone"; 

      
        var products = _productDal.SearchProductsByName(productName);

     
        Assert.NotNull(products, "Search result should not be null.");
        Assert.That(products, Has.Some.Matches<ProductDto>(
            product => product.Name.Contains(productName, StringComparison.OrdinalIgnoreCase)),
            $"At least one product should match the search keyword '{productName}'.");
    }

    [Test]
    public void GetProductsByCategoryId_ShouldReturnEmptyForInvalidCategory()
    {
        
        int invalidCategoryId = -1;

        
        var products = _productDal.GetProductsByCategoryId(invalidCategoryId);

      
        Assert.NotNull(products, "Products list should not be null.");
        Assert.IsEmpty(products, "Products list should be empty for an invalid category.");
    }

    [Test]
    public void SearchProductsByName_ShouldReturnEmptyForNonexistentName()
    {
      
        string nonexistentName = "NonexistentProductName123";

       
        var products = _productDal.SearchProductsByName(nonexistentName);

      
        Assert.NotNull(products, "Search result should not be null.");
        Assert.IsEmpty(products, "Search result should be empty for a nonexistent product name.");
    }
}

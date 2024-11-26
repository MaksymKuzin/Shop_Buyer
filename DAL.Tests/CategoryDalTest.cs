using NUnit.Framework;
using Microsoft.Extensions.Configuration;
using DAL.Concrete;
using DTO;
using System;
using System.IO;
using System.Collections.Generic;

[TestFixture]
public class CategoryDalTests
{
    private string _connectionString;
    private CategoryDal _categoryDal;

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

        
        _categoryDal = new CategoryDal(_connectionString);
    }

    [Test]
    public void GetAllCategories_ShouldReturnListOfCategories()
    {
        
        var categories = _categoryDal.GetAllCategories();

        
        Assert.NotNull(categories, "Categories list should not be null.");
        Assert.IsInstanceOf<IEnumerable<CategoryDto>>(categories, "Result should be a collection of CategoryDto.");
        Assert.That(categories, Is.Not.Empty, "Categories list should not be empty.");
    }

    [Test]
    public void GetAllCategories_ShouldContainExpectedCategory()
    {
        
        string expectedCategoryName = "Electronics";

        
        var categories = _categoryDal.GetAllCategories();

        
        Assert.That(categories, Has.Some.Matches<CategoryDto>(
            category => category.Name == expectedCategoryName),
            $"The category '{expectedCategoryName}' should exist in the list.");
    }
}

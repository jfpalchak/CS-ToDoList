using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ToDoList.Models;
using System;

namespace ToDoList.Tests
{
  [TestClass]
  public class ItemTests : IDisposable
  {
    public IConfiguration Configuration { get; set; }

    public void Dispose()
    {
      Item.ClearAll();
    }

    // connect to test database for testing
    public ItemTests()
    {
      IConfigurationBuilder builder = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json");
      Configuration = builder.Build();
      DBConfiguration.ConnectionString = Configuration["ConnectionStrings:TestConnection"];
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Item()
    {
      // Arrange, Act
      Item firstItem = new Item("Mow the lawn");
      Item secondItem = new Item("Mow the lawn");

      //Assert
      Assert.AreEqual(firstItem, secondItem);
    }

    [TestMethod]
    public void Save_SavesToDatabase_ItemList()
    {
      // Arrange
      Item testItem = new Item("Mow the lawn");

      // Act
      testItem.Save();
      List<Item> result = Item.GetAll();
      List<Item> testList = new List<Item> {testItem};

      // Assert
      CollectionAssert.AreEqual(testList, result);
    }

    // [TestMethod]
    // public void ItemConstructor_CreatesInstanceOfItem_Item()
    // {
    //   Item newItem = new Item("test");
    //   Assert.AreEqual(typeof(Item), newItem.GetType());
    // }

    // [TestMethod]
    // public void GetDescription_ReturnsDescription_String()
    // {
    //   // Arrange
    //   string description = "Walk the dog.";
    //   // Act
    //   Item newItem = new Item(description);
    //   string result = newItem.Description;
    //   // Assert
    //   Assert.AreEqual(description, result);
    // }

    [TestMethod]
    public void GetAll_ReturnsEmptyListFromDatabase_ItemList()
    {
      // Arrange
      List<Item> newList = new List<Item> { };
      // Act
      List<Item> result = Item.GetAll();
      // Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsItems_ItemList()
    {
      // Arrange
      string description01 = "Walk the dog.";
      string description02 = "Was the dishes.";
      Item newItem1 = new Item(description01);
      newItem1.Save(); // Updated code!
      Item newItem2 = new Item(description02);
      newItem2.Save(); // Updated code!
      List<Item> newList = new List<Item> {newItem1, newItem2};

      // Act
      List<Item> result = Item.GetAll();

      // Assert
      CollectionAssert.AreEqual(newList, result);
    }

    // [TestMethod]
    // public void GetId_ItemsInstantiateWithAnIdAndGetterReturns_Int()
    // {
    //   // arrange
    //   string description = "Walk the dog.";
    //   Item newItem = new Item(description);

    //   // act
    //   int result = newItem.Id;

    //   // assert
    //   Assert.AreEqual(1, result);
    // }

    [TestMethod]
    public void Find_ReturnsCorrectItem_Item()
    {
      // arrange
      string description01 = "Walk the dog.";
      string description02 = "Was the dishes.";
      Item newItem1 = new Item(description01);
      newItem1.Save();  // Updated code!
      Item newItem2 = new Item(description02);
      newItem2.Save(); // Updated code!

      // act
      Item result = Item.Find(2);

      // assert
      Assert.AreEqual(newItem2, result);
    }
  }
}
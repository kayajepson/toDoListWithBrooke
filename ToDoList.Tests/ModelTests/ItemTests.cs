using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using ToDoList.Models;

namespace ToDoList.Tests
{
  [TestClass]
  public class ItemTest : IDisposable
  {

    public void Dispose()
    {
        Item.ClearAll();
    }
    
    public ItemTest()
   {
     DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=to_do_list_test;";
   }

    [TestMethod]
    public void ItemConstructor_CreatesInstanceOfItem_Item()
    {
        Item newItem = new Item("test");
        Assert.AreEqual(typeof(Item), newItem.GetType());
    }

    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
        string description = "Walk the dog.";
        Item newItem = new Item(description);
        string result = newItem.GetDescription();
        Assert.AreEqual(description, result);
    }

    [TestMethod]
    public void SetDescription_SetDescription_String()
    {
      string description = "Walk the dog.";
      Item newItem = new Item(description);
      string updatedDescription = "Do the dishes";
      newItem.SetDescription(updatedDescription);
      string result = newItem.GetDescription();
      Assert.AreEqual(updatedDescription, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_ItemList()
    {
        List<Item> newList = new List<Item> {};
        List<Item> result = Item.GetAll();

        CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsItems_ItemList()
    {
    string description01 = "Walk the dog";
    string description02 = "Wash the dishes";
    Item newItem1 = new Item(description01);
    Item newItem2 = new Item(description02);
    List<Item> newList = new List<Item> { newItem1, newItem2 };
    List<Item> result = Item.GetAll();

    CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectItem_Item()
    {
      //Arrange
      string description01 = "Walk the dog";
      string description02 = "Wash the dishes";
      Item newItem1 = new Item(description01);
      Item newItem2 = new Item(description02);

      //Act
      Item result = Item.Find(2);

      //Assert
      Assert.AreEqual(newItem2, result);
    }
  }
}

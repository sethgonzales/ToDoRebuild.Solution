using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Models;
using System.Collections.Generic;
using System;

namespace ToDoList.Tests
{
  [TestClass]
  public class CategoryTests : IDisposable //test our category constructor class
  {
    public void Dispose()// run this dispose method that will clear all instances of categories in our categories list everytime a test is run
    {
      Category.ClearAll();
    }

    [TestMethod]
    public void CategoryConstructor_CreatesInstancesOfCategory() //first test confirms that we can make an instance of our Category const by making sure it has the correct type
    {
      Category newCat = new Category("test cat");
      Assert.AreEqual(typeof(Category), newCat.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsNameOfCat_String()
    {
      //arrange
      string name = "test cat"; //create string of new cat name
      Category newCategory = new Category(name); //create new instance of category passing in its name
      //act
      string result = newCategory.Name; //look inside of the new Category instance and see what its name is
      //assert
      Assert.AreEqual(name, result); //the name we created should be equal to the name found in the new category instance
    }
    [TestMethod]
    public void GetId_ReturnsCategoryId_Int()
    {
      //Arrange
      string name = "test cat"; //create string of new cat name
      Category newCategory = new Category(name); //create cat inst
      //Act
      int result = newCategory.Id;
      //Assert
      Assert.AreEqual(1, result); //make sure the id is actually 1       
    }

    [TestMethod]
    public void GetAll_ReturnsAllCategoryObjects_CategoryList()
    {
      //Arrange
      string name1 = "work";
      string name2 = "school";
      Category newCat1 = new Category(name1);
      Category newCat2 = new Category(name2); //create new instances of cats with names
      List<Category> newList = new List<Category> { newCat1, newCat2 }; //create a new list of the two categories
      //act
      List<Category> result = Category.GetAll(); //get all of the categories in the list of categories
      //Assert
      CollectionAssert.AreEqual(newList, result); //the hypotheical list and the actual list are equal. use collections assert since we are comparing two LISTS
    }
    [TestMethod]
    public void Find_ReturnsCorrectCategory_Category()
    {
      //Arrange
      string name01 = "Work";
      string name02 = "School";
      Category newCategory1 = new Category(name01);
      Category newCategory2 = new Category(name02);

      //Act
      Category result = Category.Find(2); //find the category with the id of 2. Type is category as we are returning the entire cat instance when we find this
      //assert
      Assert.AreEqual(newCategory2, result); //new cat 2 has an id of two and should therefore be equal to the category that comes up when we "find" the cat with an id of 2
    }


    [TestMethod]
    public void AddItem_AssociatesItemWithCategory_ItemList()
    {
      //Arrange
      string description = "Walk the dog.";
      Item newItem = new Item(description); //create new item with a desctiption
      List<Item> newList = new List<Item>{newItem};//create a list of items and give it the newItem
      string name = "school" ; //name of new cat
      Category newCat = new Category(name);
      newCat.AddItem(newItem); //add newItem to the category list
      //act
      List<Item> result = newCat.Items; //find the items in teh new cat
      //assert
      CollectionAssert.AreEqual(result, newList);
    }
  }
}
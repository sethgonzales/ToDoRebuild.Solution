using System.Collections.Generic;

namespace ToDoList.Models
{
  public class Category //create blueprint for Categories.
  {
    private static List<Category> _instances = new List<Category> { }; //create a static list of all category objects 
    public string Name { get; set; } //Name of category w/get and set abilities
    public int Id { get; } //identification number that we will able to retrieve
    public List<Item> Items { get; set; } //Items contains a list of all items within a category. data type declared as List of Items auto implemented property

    public Category(string categoryName) //what happens when information is passed through and a new category is made
    {
      Name = categoryName; //assign categoryName as the Name field
      _instances.Add(this); //every time a new category is made, add it to the List. It is a new instance of a category
      Id = _instances.Count; //every time a new category is made, its id code is assigned based on the counted number of how many category instances already exist in the list of categories
      Items = new List<Item>{}; //create a new list for this category that will contain a list of items within the category. {} is a stand in for this information
    
    }

    //methods that we make that need to access this class are made within the confines of the class
    public static void ClearAll() //create a method to clear list of instances of categories
    {
      _instances.Clear();
    }

    public static List<Category> GetAll() //create a new method that is going to return an property type of lists containing categories
    {
      return _instances; //return a list of all of the instances of the categories in the categories list
    }

    public static Category Find(int idToSearch) //pass in an id to search
    {
      return _instances[idToSearch-1]; //return instances in the list of index 1 less than the id since indexes start at zero. lists are like array in that they have indexes that we can check
    }
    public  void AddItem(Item item) //method will pass in an item of the class Item not static since we can run and instantiate this method
    {
      Items.Add(item); //add new item to items list of an instance of a category
    }
  }
}
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;


namespace ToDoList.Controllers
{
  public class CategoriesController : Controller
  {
    [HttpGet("/categories")]  //get me this page!
    public ActionResult Index() //lead to index cshtml when accessing this path
    {
      List<Category> allCategories = Category.GetAll(); //when we go to this web page we want to run this get all method to displate the list of all of the categories
      return View(allCategories); //show the web page and pass in the info from all of the categories
    }
    [HttpGet("/categories/new")] //get me to this new page!
    public ActionResult New()
    {
      return View(); //show the page! This is the one with the form
    }


    [HttpPost("/categories")] //deal with form information and redirect it to right place
    public ActionResult Create(string categoryName) //create form data on server taking in the category name from the form
    {
      Category newCat = new Category(categoryName); //create a new cat instance with the cat name given
      return RedirectToAction("Index"); //take back to the page with lists of cats
    }

    [HttpGet("/categories/{id}")]
    public ActionResult Show(int id) //show the items pased on the category id that is passed through
    {
      Dictionary<string, object> model = new Dictionary<string, object>(); //create a new dictionary of key value pairs
      Category selectedCat = Category.Find(id); //find the category based on the id that was passed in
      List<Item> categoryItems = selectedCat.Items; //create a list of the items in the category
      model.Add("category", selectedCat); //add the word category and the found category to the dictionary as a key value pair
      model.Add("items", categoryItems); //add the word items and the items in the category to the dictionary as a key value pair
      return View(model); //show the web page and pass in the dictionary information
      //view can only take in one argument so we have to figureout how to combine the category information AND the item information to one thing -- thus a dictionary called 'model' bc its a mini stand in for our model

    }

    //moved from items controller. This is for creating new ITEMS
    [HttpPost("/categories/{categoryId}/items")] //updated url path
    public ActionResult Create(int categoryId, string itemDescription) //pass in item and category ids
    {
      Dictionary<string, object> model = new Dictionary<string, object>(); //make a dict
      Category foundCategory = Category.Find(categoryId); //find cat by id that our item should belong to
      Item newItem = new Item(itemDescription); //create a new item object with the users input form description
      foundCategory.AddItem(newItem); //add item to found category 
      List<Item> categoryItems = foundCategory.Items; //retrieve all other items that belong to this category as a list

      model.Add("items", categoryItems); //add list of items that belong to the category to dict
      model.Add("category", foundCategory); //add category to the dict
      return View("Show", model); //show the page and pass in the model dictionary
    }



  }
}
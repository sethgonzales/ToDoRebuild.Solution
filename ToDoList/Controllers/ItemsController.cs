using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;

namespace ToDoList.Controllers
{
  public class ItemsController : Controller
  {

    [HttpGet("/categories/{categoryId}/items/new")] //url path to new
    public ActionResult New(int categoryId) //pass in cat id
    {
      Category category = Category.Find(categoryId); //find category in database using this id
      return View(category); //view new page with cat info passed in
    }

    // [HttpPost("/items")]
    // public ActionResult Create(string description)
    // {
    //   Item myItem = new Item(description);
    //   return RedirectToAction("Index");
    // } This got moved ot the cat controller since the act of creating an item is changing stuff about the category it is in. Standard pract for obj within obj


    
  [HttpGet("/categories/{categoryId}/items/{itemId}")]//user clicks on an item and is lead here, 
  public ActionResult Show(int categoryId, int itemId)//pass in cat id and item id values
  {
    Item item = Item.Find(itemId);//find the item
    Category category = Category.Find(categoryId);
    Dictionary<string, object> model = new Dictionary<string, object>();//create another dictionary
    model.Add("item", item);
    model.Add("category", category); //add in the category to the dictionary
    return View(model);//return the page with the information we just creted
  }




  }
}
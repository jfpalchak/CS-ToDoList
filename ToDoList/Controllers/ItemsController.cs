using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoList.Models;

namespace ToDoList.Controllers
{
  public class ItemsController : Controller
  {
    
    [HttpGet("/items")]
    public ActionResult Index()
    {
      // We want Index to have access to _ALL_ Items:
      List<Item> allItems = Item.GetAll();
      return View(allItems);
    }

    [HttpGet("/items/new")]
    public ActionResult New()
    {
      return View();
    }

    // * This route only needs to _create_ a new Item,
    // * so it doesn't care about updating a View!
    // * Create item, then redirect to Index, which will update the corresponding View.
    // * Note: we have two routes that use the "/items" path. We can do this because
    // * GET and POST are two different requests! The server can tell them apart.
    [HttpPost("/items")]
    public ActionResult Create(string description)
    {
      Item myItem = new Item(description);

      // RedirectToAction takes a route method as an argument,
      // and tells the server to invoke that route after Create() has been invoked
      return RedirectToAction("Index");
    }

    [HttpPost("/items/delete")]
    public ActionResult DeleteAll()
    {
      Item.ClearAll();
      return View();
    }

    [HttpGet("/items/{id}")]
    public ActionResult Show(int id)
    {
      Item foundItem = Item.Find(id);
      return View(foundItem);
    }
  }
}
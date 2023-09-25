using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoList.Models;

namespace ToDoList.Controllers
{
  public class HomeController : Controller
  {
    
    [HttpGet("/")]
    public ActionResult Index()
    {
      // We want Index to have access to _ALL_ Items:
      List<Item> allItems = Item.GetAll();
      return View(allItems);
    }

    [HttpGet("/items/new")]
    public ActionResult CreateForm()
    {
      return View();
    }

    // when our form is submitted, this route will be invoked
    // we'll change our route decorator to for this method
    // * This route only needs to _create_ a new Item,
    // * so it doesn't care about updating a View!
    // * Create item, then redirect to Index, which will update the corresponding View.
    [HttpPost("/items")]
    public ActionResult Create(string description)
    {
      Item myItem = new Item(description);

      // RedirectToAction takes a route method as an argument,
      // and tells the server to invoke that route after Create() has been invoked
      return RedirectToAction("Index");
    }
  }
}
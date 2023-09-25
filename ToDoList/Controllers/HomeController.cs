using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
  public class HomeController : Controller
  {
    
    [HttpGet("/")]
    public ActionResult Index()
    {
      Item starterItem = new Item("Add first item to To Do List");
      return View(starterItem);
    }

    [HttpGet("/items/new")]
    public ActionResult CreateForm()
    {
      return View();
    }

    // when our form is submitted, this route will be invoked
    // we'll change our route decorator to for this method
    [HttpPost("/items")]
    public ActionResult Create(string description)
    {
      Item myItem = new Item(description);

      // the first argument here tells View to return the Index view,
      // which means we don't need to add a new Create.cshtml view to 
      // correspond with our Create() route!
      // the second argument specifies what the Model property on the view should be
      return View("Index", myItem);
    }
  }
}
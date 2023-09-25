using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
  public class HomeController : Controller
  {
    
    [Route("/")]
    public ActionResult Index()
    {
      Item starterItem = new Item("Add first item to To Do List");
      return View(starterItem);
    }

    [Route("/items/new")]
    public ActionResult CreateForm()
    {
      return View();
    }

    // when our form is submitted, this route will be invoked
    [Route("/items")]
    public ActionResult Create(string description)
    {
      Item myItem = new Item(description);

      // the first argument here tells View to return the Index view,
      // which means we don't need to add a new Create.cshtml view to 
      // correspond with our Create() route!
      return View("Index", myItem);
    }
  }
}
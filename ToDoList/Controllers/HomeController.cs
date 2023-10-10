using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;
using System.Linq;

namespace ToDoList.Controllers
{
  public class HomeController : Controller
  {
    private readonly ToDoListContext _db;

    public HomeController(ToDoListContext db)
    {
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index()
    {
      // We COULD use ViewBag here instead of a Dictionary, if we wanted.
      Category[] cats = _db.Categories.ToArray();
      Item[] items = _db.Items.ToArray();
      Dictionary<string, object[]> model = new Dictionary<string, object[]> ();
      model.Add("categories", cats);
      model.Add("items", items);
      return View(model);
    }
  }
}
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ToDoList.Controllers
{
  public class TagsController : Controller
  {
    private readonly ToDoListContext _db;

    public TagsController(ToDoListContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Tags.ToList());
    }

    public ActionResult Details(int id)
    {
      Tag thisTag = _db.Tags
                        .Include(tag => tag.JoinEntities) // load each join entity, ie, list of ItemTags (references to a relationship)
                        .ThenInclude(join => join.Item) // then, load the Item object associated with each ItemTag join entity
                        .FirstOrDefault(tag => tag.TagId == id);
      return View(thisTag);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Tag tag)
    {
      _db.Tags.Add(tag);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
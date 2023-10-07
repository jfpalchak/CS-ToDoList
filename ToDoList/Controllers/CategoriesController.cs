using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;
using ToDoList.Models;

namespace ToDoList.Controllers
{
  public class CategoriesController : Controller
  {
    private readonly ToDoListContext _db;

    public CategoriesController(ToDoListContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Category> model = _db.Categories.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Category category)
    {
      _db.Categories.Add(category);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      // If we don't explicitly tell EFCore to include the data for the 
      // navigation property Items with .Include(), it won't gather that data!
      Category foundCategory = _db.Categories
                                  .Include(category => category.Items)
                                  .ThenInclude(item => item.JoinEntities) // Then, grab each Join Entity for each Item
                                  .ThenInclude(join => join.Tag) // THEN, grab each Tag associated with each Join Entity of an Item
                                  .FirstOrDefault(category => category.CategoryId == id);
      return View(foundCategory);
    }

    public ActionResult Edit(int id)
    {
      Category foundCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
      return View(foundCategory);
    }

    [HttpPost]
    public ActionResult Edit(Category category)
    {
      _db.Categories.Update(category);
      _db.SaveChanges();
      return View("Details", category);
    }

    public ActionResult Delete(int id)
    {
      Category foundCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
      return View(foundCategory);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Category thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
      _db.Categories.Remove(thisCategory);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
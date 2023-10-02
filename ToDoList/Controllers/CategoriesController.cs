using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
  public class CategoriesController : Controller
  {
    // // SHOW ALL CATEGORIES
    // [HttpGet("/categories")]
    // public ActionResult Index()
    // {
    //   List<Category> allCategories = Category.GetAll();
    //   return View(allCategories);
    // }

    // // SHOW FORM TO CREATE NEW CATEGORY
    // [HttpGet("/categories/new")]
    // public ActionResult New()
    // {
    //   return View();
    // }

    // // CREATE NEW CATEGORY
    // [HttpPost("/categories")]
    // public ActionResult Create(string categoryName)
    // {
    //   Category newCategory = new Category(categoryName);
    //   return RedirectToAction("Index");
    // }

    // // SHOW SPECIFIC CATEGORY & ITS ITEMS
    // [HttpGet("/categories/{id}")]
    // public ActionResult Show(int id)
    // {
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   Category selectedCategory = Category.Find(id);
    //   List<Item> categoryItems = selectedCategory.Items;
    //   model.Add("category", selectedCategory);
    //   model.Add("items", categoryItems);
    //   return View(model);
    // }

    // // Because new Items all belong to Categories, the act of creating a new Item now alters our Category objects. As such, it's more accurate to say it's related to our Category model now. 
    // // To follow best practices, we've moved the Item's Create() route to the Category Controller.
    // // This is standard practices in applications that use objects within objects, like ours.
    // // * Even though this controller already has a Create() route, they won't get mixed up because they have distinctly different paths.
    // // * CREATE new ITEMS, not new Categories.
    // [HttpPost("/categories/{categoryId}/items")]
    // public ActionResult Create(int categoryId, string itemDescription) 
    // {
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   Category foundCategory = Category.Find(categoryId);
    //   Item newItem = new Item(itemDescription);
    //   newItem.Save(); // Updated code!

    //   foundCategory.AddItem(newItem);
    //   List<Item> categoryItems = foundCategory.Items;

    //   model.Add("items", categoryItems);
    //   model.Add("category", foundCategory);

    //   return View("Show", model);
    // }
  }
}
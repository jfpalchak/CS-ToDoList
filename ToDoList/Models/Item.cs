using System.Collections.Generic;

namespace ToDoList.Models
{
  public class Item
  {
    public string Description { get; set; }
    private static List<Item> _instances = new List<Item> { };

    // To Do Item constructor
    public Item(string description)
    {
      Description = description;
      _instances.Add(this);
    }

    // return list of To Do Items
    public static List<Item> GetAll()
    {
      return _instances;
    }

    // clear list of To Do Items
    public static void ClearAll()
    {
      _instances.Clear();
    }
  }
}
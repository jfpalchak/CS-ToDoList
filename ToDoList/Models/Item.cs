using System.Collections.Generic;

namespace ToDoList.Models
{
  public class Item
  {
    public string Description { get; set; }
    public int Id { get; } // this is a READONLY property
    // * NOTE: We don't add a set method, because this property will be set in the constructor automatically. In fact, we specifically don't ever want to manually edit it. That would increase the risk of IDs not being unique.
    private static List<Item> _instances = new List<Item> { };

    // To Do Item constructor
    public Item(string description)
    {
      Description = description;
      _instances.Add(this);
      // create id upon item construction
      Id = _instances.Count;
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

    // taking an item id, return that item from the list of items
    public static Item Find(int searchId)
    {
      // subtract 1 from id, as index starts at zero and our id count starts at 1
      return _instances[searchId-1];
    }
  }
}
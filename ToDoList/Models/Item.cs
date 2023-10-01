using MySqlConnector;
using System.Collections.Generic;

namespace ToDoList.Models
{
  public class Item
  {
    public string Description { get; set; }
    public int Id { get; } // this is a READONLY property

    // To Do Item constructor
    public Item(string description)
    {
      Description = description;
    }

    // Overloaded constructor
    public Item (string description, int id)
    {
      Description = description;
      Id = id;
    }

    // return list of To Do Items
    public static List<Item> GetAll()
    {
      List<Item> allItems = new List<Item> {};

      MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
      conn.Open();

      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "SELECT * FROM items;";

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int itemId = rdr.GetInt32(0);
        string itemDescription = rdr.GetString(1);
        Item newItem = new Item(itemDescription, itemId);
        allItems.Add(newItem);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allItems;
    }

    // clear list of To Do Items
    public static void ClearAll()
    {
      // refactor
    }

    // taking an item id, return that item from the list of items
    public static Item Find(int searchId)
    {
      // Temporarily return placeholder item to bypass compiler error
      // until we refactor to work with database
      Item placeholderItem = new Item("placeholder item");
      return placeholderItem;
    }
  }
}
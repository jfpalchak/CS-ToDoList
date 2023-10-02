using MySqlConnector;
using System.Collections.Generic;

namespace ToDoList.Models
{
  public class Item
  {
    public string Description { get; set; }
    public int Id { get; set; }

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

    // overriding the build-in method Equals
    // will allow our tests to know when we want two different objects to be considered the same
    public override bool Equals(System.Object otherItem)
    {
      if (!(otherItem is Item))
      {
        return false;
      }
      else
      {
        Item newItem = (Item) otherItem;
        bool descriptionEquality = (this.Description == newItem.Description);
        return descriptionEquality;
      }
    }

    // overriding the GetHashCode method
    public override int GetHashCode()
    {
      return Id.GetHashCode();
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

    // clear entire items table in our database
    public static void ClearAll()
    {
      MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
      conn.Open();

      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "DELETE FROM items;";
      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    // taking an item id, return that item from the list of items
    public static Item Find(int searchId)
    {
      // Temporarily return placeholder item to bypass compiler error
      // until we refactor to work with database
      Item placeholderItem = new Item("placeholder item");
      return placeholderItem;
    }

    public void Save()
    {
      MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
      conn.Open();

      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;

      cmd.CommandText = "INSERT INTO items (description) VALUES (@ItemDescription);";
      MySqlParameter param = new MySqlParameter();
      param.ParameterName = "@ItemDescription";
      param.Value = this.Description;
      cmd.Parameters.Add(param);
      cmd.ExecuteNonQuery();
      Id = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  }
}
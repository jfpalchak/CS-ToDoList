using System.Collections.Generic;

namespace ToDoList.Models
{
  public class Category
  {
    public int CategoryId { get; set; }
    public string Name { get; set; }
    
    // For EF Core, Items is a navigation property;
    // specifically, a "collection navigation property"
    // Navigation Properties are never saved in the database:
    // Instead, they are populated in our projects BY EF Core FROM
    // the data in the database.
    public List<Item> Items { get; set; }
  }
}
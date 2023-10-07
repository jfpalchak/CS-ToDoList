using System.Collections.Generic;

namespace ToDoList.Models
{
  public class Item
  {
    public string Description { get; set; }
    public int ItemId { get; set; }

    // Foreign Key
    public int CategoryId { get; set; }
    // Reference Navigation Property (creates the One-to-Many relationship)
    public Category Category { get; set; }
    // Collection Navigation Property (for our many-to-many relationship with Tag)
    public List<ItemTag> JoinEntities {get; }
  }
}
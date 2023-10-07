using System.Collections.Generic;

namespace ToDoList.Models
{
  public class Tag
  {
    public int TagId { get; set; }
    public string Title { get; set; }

    // Collection Navigation Property (for many-to-many relationship with Item)
    public List<ItemTag> JoinEntities { get; }
  }
}
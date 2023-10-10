using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // directive for Validation Attributes / Data Annotations

namespace ToDoList.Models
{
  public class Item
  {
    [Required(ErrorMessage = "The item's description can't be empty!")]
    public string Description { get; set; }
    public int ItemId { get; set; }
    // public bool IsComplete { get; set; }


    // * VALIDATION ATTRIBUTE
    [Range(1, int.MaxValue, ErrorMessage = "You must add your item to a category. Have you created a category yet?")]
    public int CategoryId { get; set; } // Foreign Key

    // Reference Navigation Property (creates the One-to-Many relationship)
    public Category Category { get; set; }

    // Collection Navigation Property (for our many-to-many relationship with Tag)
    public List<ItemTag> JoinEntities { get; }
  }
}
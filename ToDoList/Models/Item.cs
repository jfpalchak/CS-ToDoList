
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
  }
}
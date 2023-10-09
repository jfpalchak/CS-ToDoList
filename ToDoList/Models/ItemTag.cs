namespace ToDoList.Models
{
  public class ItemTag
  {
    public int ItemTagId { get; set; }
    public int ItemId { get; set; }
    public int TagId { get; set; }
    
    // Reference Navigation Property
    public Item Item { get; set; }
    // Reference Navigation Property
    public Tag Tag { get; set; }
  }
}
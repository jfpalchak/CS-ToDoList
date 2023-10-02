using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models
{
  public class ToDoListContext : DbContext
  {
    // This represents the Items table in our database.
    // This property declares our entity, Items, in our ToDoList database context.
    public DbSet<Item> Items { get; set; }
    
    // We invoke the constructor behavior from the parent DbContext class.
    // The argument for this parameter will be passed through dependency injection
    // from Program.cs when our app is built and run.
    public ToDoListContext(DbContextOptions options) : base(options) { }
  }
}
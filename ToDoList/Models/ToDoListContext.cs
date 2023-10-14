using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models
{
  public class ToDoListContext : IdentityDbContext<ApplicationUser>
  {
    // This represents the Items table in our database.
    // This property declares our entity, Items, in our ToDoList database context.
    public DbSet<Item> Items { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Tag> Tags { get; set; }
    // Join Entity: joining both Items and Tags to track their many-to-many relationship
    public DbSet<ItemTag> ItemTags { get; set; }
    
    // We invoke the constructor behavior from the parent DbContext class.
    // The argument for this parameter will be passed through dependency injection
    // from Program.cs when our app is built and run.
    public ToDoListContext(DbContextOptions options) : base(options) { }
  }
}
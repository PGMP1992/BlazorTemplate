using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Server.Data;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {
        
    }
    public DbSet<Category> Categories  { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Category>().HasData(
           new Category
           {
               CategoryId = 1,
               ThumnailImagePath="uploads/placeholder.jpg",
               Name="Kategori1",
               Description="Beskrivning av kategori 1"
           },
            new Category
            {
                CategoryId = 2,
                ThumnailImagePath = "uploads/placeholder.jpg",
                Name = "Kategori1",
                Description = "Beskrivning av kategori 2"
            },
             new Category
             {
                 CategoryId = 3,
                 ThumnailImagePath = "uploads/placeholder.jpg",
                 Name = "Kategori1",
                 Description = "Beskrivning av kategori 3"
             }
        );
    }
}

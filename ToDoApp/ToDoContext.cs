using Microsoft.EntityFrameworkCore;
using ToDoApp.Model;

namespace ToDoApp
{
    public class ToDoContext : DbContext
    {
        public DbSet<ToDo> Todos { get; set; }

        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {
        }
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "ToDo.db");
        //     optionsBuilder.UseSqlite($"Filename={path}");
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDo>().ToTable("Todos");
        }
    }
}
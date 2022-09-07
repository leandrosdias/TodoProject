using Microsoft.EntityFrameworkCore;
using Todo.API.Models;

namespace Todo.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opt) : base(opt)
        {
        }

        public DbSet<TodoModel> TodoList { get; set; }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Composite.Models;

namespace BaseProject.Web.Models
{
    public class Context:IdentityDbContext<AppUser>
    {

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}

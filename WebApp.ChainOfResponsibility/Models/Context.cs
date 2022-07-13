using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.ChainOfResponsibility.Web.Models;

namespace BaseProject.Web.Models
{
    public class Context:IdentityDbContext<AppUser>
    {

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public  DbSet<Product> Products { get; set; }
    }
}

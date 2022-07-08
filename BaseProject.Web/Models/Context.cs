using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BaseProject.Web.Models
{
    public class Context:IdentityDbContext
    {

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
    }
}

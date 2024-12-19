using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using StudentPortalWeb.Models.Entities;

namespace StudentPortalWeb.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> Options) :base(Options) 

        {
           
        }
        public DbSet<Student> Students { get; set; }
    }
}

using justauth.src.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace justauth.src.DataBase 
{
     public class Context : IdentityDbContext<User> 
    {
       

        public Context(DbContextOptions<Context> options) : base(options) 
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        
    }
}
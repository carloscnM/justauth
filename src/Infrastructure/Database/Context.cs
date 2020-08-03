using justauth.src.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace justauth.src.Infrastructure.DataBase 
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
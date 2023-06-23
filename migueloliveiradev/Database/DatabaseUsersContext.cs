using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace migueloliveiradev.Database
{
    public class DatabaseUsersContext : IdentityDbContext
    {
        public DatabaseUsersContext(DbContextOptions<DatabaseUsersContext> options) : base(options) { }
    }
}

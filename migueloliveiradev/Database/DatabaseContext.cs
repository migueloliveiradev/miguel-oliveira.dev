using Microsoft.EntityFrameworkCore;
using migueloliveiradev.Models.Me;
using migueloliveiradev.Models.Network;
using migueloliveiradev.Models.Works;
using migueloliveiradev.Models.Works.Projetos;

namespace migueloliveiradev.Database;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    public DbSet<Project> Projects { get; set; }
    public DbSet<Technology> Technologies { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<SocialNetwork> SocialNetworks { get; set; }
    public DbSet<About> About { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Service> Services { get; set; }
}

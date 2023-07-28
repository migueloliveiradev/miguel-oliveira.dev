using Microsoft.EntityFrameworkCore;
using migueloliveiradev.Models.Me;
using migueloliveiradev.Models.Network;
using migueloliveiradev.Models.Works;
using migueloliveiradev.Models.Works.Projetos;

namespace migueloliveiradev.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DatabaseContext() { }

        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Tecnologia> Tecnologias { get; set; }
        public DbSet<Imagem> Imagens { get; set; }
        public DbSet<RedeSocial> RedeSociais { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<About> About { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Service> Services { get; set; }
    }
}

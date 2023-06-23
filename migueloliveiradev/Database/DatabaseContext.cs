using Microsoft.EntityFrameworkCore;
using migueloliveiradev.Models.Me;
using migueloliveiradev.Models.Network;
using migueloliveiradev.Models.Works;
using migueloliveiradev.Models.Works.Projetos;

namespace migueloliveiradev.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() { }
        public DatabaseContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(Environment.GetEnvironmentVariable("MYSQL_CONNECTION"), ServerVersion.AutoDetect(Environment.GetEnvironmentVariable("MYSQL_CONNECTION")));
            }
        }

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

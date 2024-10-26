using Microsoft.EntityFrameworkCore;
using TJRJ.Domain.Entities;
using TJRJ.Infra.Data.Mappings;

namespace TJRJ.Infra.Data
{
    public class DataContext : DbContext
    {
        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Livro> Livro { get; set; }
        public DbSet<Assunto> Assunto { get; set; }
        public DbSet<Autor> Autor { get; set; }
        public DbSet<Livro_Assunto> Livro_Assunto { get; set; }
        public DbSet<Livro_Autor> Livro_Autor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new LivroMapping());
            modelBuilder.ApplyConfiguration(new AssuntoMapping());
            modelBuilder.ApplyConfiguration(new AutorMapping());
            modelBuilder.ApplyConfiguration(new Livro_AssuntoMapping());
            modelBuilder.ApplyConfiguration(new Livro_AutorMapping());
            base.OnModelCreating(modelBuilder);
        }




    }
}

using ListasTarefasMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ListasTarefasMVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { CategoriaId = Guid.NewGuid(), Nome = "Trabalho" },
                new Categoria { CategoriaId = Guid.NewGuid(), Nome = "Casa" },
                new Categoria { CategoriaId = Guid.NewGuid(), Nome = "Faculdade" },
                new Categoria { CategoriaId = Guid.NewGuid(), Nome = "Compras" },
                new Categoria { CategoriaId = Guid.NewGuid(), Nome = "Academia" }
            );

            modelBuilder.Entity<Status>().HasData(
                new Status { StatusId = Guid.NewGuid(), Nome = "Aberto" },
                new Status { StatusId = Guid.NewGuid(), Nome = "Completo" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}

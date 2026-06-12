using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Vendinha.Models;


namespace Vendinha.Data
{
    public class VendinhaDbContext : DbContext
    {
        public DbSet<Cliente> Clientes => Set<Cliente>();

        public DbSet<Divida> Dividas =>Set<Divida>();
        
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            
            optionsBuilder.UseNpgsql(
                Environment.GetEnvironmentVariable(
                    "ConnectionStrings__Default"
                )
            );
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {

            var modelCliente = modelBuilder.Entity<Cliente>();
            modelCliente.ToTable("clientes");
            modelCliente.Property(e => e.Id).HasColumnName("id");
            modelCliente.Property(e => e.NomeCompleto).HasColumnName("nome");
            modelCliente.Property(e => e.CPF).HasColumnName("cpf");
            modelCliente.Property(e => e.Email).HasColumnName("email");
            modelCliente.HasKey(e => e.Id);



            var modelDivida = modelBuilder.Entity<Divida>();
            modelDivida.ToTable("dividas");
            modelDivida.Property(e => e.Id).HasColumnName("id");
            modelDivida.Property(e => e.Valor).HasColumnName("valor");
            modelDivida.Property(e => e.Paga).HasColumnName("paga");
            modelDivida.Property(e => e.DataCriacao).HasColumnName("datacriacao");
            modelDivida.Property(e => e.DataPagamento).HasColumnName("datapagamento");
            modelDivida.HasOne(c => c.Cliente)
                .WithMany(c => c.Dividas)
                .HasForeignKey(d => d.ClienteId);
            modelDivida.HasKey(d => d.Id);


            base.OnModelCreating(modelBuilder);
        }


        
    }

    
}

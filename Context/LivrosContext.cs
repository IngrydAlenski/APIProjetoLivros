using APIProjetoLivros.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace APIProjetoLivros.Context
{
    public class LivrosContext : DbContext
    {
        //Cada tabela -> DbSet
        public DbSet<Usuario> Usuarios  { get; set; }
        public DbSet<TipoUsuario> TiposUsuarios  { get; set; }
        public DbSet<Assinatura> Assinaturas { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        public LivrosContext(DbContextOptions<LivrosContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //String de Conexao
            optionsBuilder.UseSqlServer("Data Source=NOTE25-S28\\SQLEXPRESS; Catalog=Livros;User Id=sa;Password=Senai@134;TrustServerCertificate=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>
            (
                //Representano as tabela
            entity =>
            {
            //Primary Key
            entity.HasKey(u => u.UsuarioId);

                // configurando Campos
                entity.Property(u => u.NomeCompleto)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false);

                entity.Property(u => u.Email)
                .HasMaxLength(150)
                .IsRequired()   
                .IsUnicode (false);
                //Email unico
                entity.HasIndex(u => u.Email)
                .IsUnique();

                entity.Property(u => u.Senha)
               .HasMaxLength(255)
               .IsRequired()
               .IsUnicode(false);

                entity.Property(u => u.Telefone)
                .HasMaxLength(15)
                .IsRequired()
                .IsUnicode(false);

                entity.Property(u => u.DataCadastro)
               .IsRequired()
               .IsUnicode(false);

                entity.Property(u => u.DataAtualizacao)
               .IsRequired();

                //Configuracao de relacionamento

                entity.HasOne(u => u.TipoUsuario)
                .WithMany(t => t.Usuarios)
                .HasForeignKey(u => u.TipoUsuarioId)
                .OnDelete(DeleteBehavior.Cascade);
            }
                
            );
        }
    }
}

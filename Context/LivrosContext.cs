using APIProjetoLivros.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace APIProjetoLivros.Context
{
    public class LivrosContext : DbContext
    {
        //Cada tabela -> DbSet
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TipoUsuario> TiposUsuarios { get; set; }
        public DbSet<Assinatura> Assinaturas { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        //Metodoo construtor
        public LivrosContext(DbContextOptions<LivrosContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //String de Conexao
            optionsBuilder.UseSqlServer("Data Source=NOTE25-S28\\SQLEXPRESS; Initial Catalog=Livros;User Id=sa;Password=Senai@134;TrustServerCertificate=true;");
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
                .IsUnicode(false);
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
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                //Configurando primari Key
                entity.HasKey(entity => entity.TipoUsuarioId);

                // Vou campo a campo configurando
                entity.Property(t => t.DescricaoTipo)
                .IsRequired()
                 .HasMaxLength(100)
                 .IsUnicode(false);

                //Descricao nao pode se repetir 
                //Todo campo UNIQUE e um indice
                entity.HasIndex(t => t.DescricaoTipo)
                .IsUnique();

            });

            modelBuilder.Entity<Livro>(entity =>
            {
                entity.HasKey(l => l.LivroId);


                entity.Property(u => u.Titulo)
              .IsRequired()
              .HasMaxLength(200)
              .IsUnicode(false);

                entity.Property(u => u.Autor)
                .HasMaxLength(200)
                .IsRequired()
                .IsUnicode(false);

                entity.Property(u => u.Descricao)
               .HasMaxLength(255)
               .IsUnicode(false);

                entity.Property(u => u.DataPubluicacao)
                .IsRequired();

                //Relacionamento 
                //Livro - Categoria 
                //1 - N

                entity.HasOne(l => l.Categoria)
                .WithMany(c => c.Livros)
                .HasForeignKey(l => l.CategoriaId)
                .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(c => c.CategoriaId);

                entity.Property(c => c.NomeCategoria)
               .IsRequired()
               .HasMaxLength(100)
               .IsUnicode(false);

            });

            modelBuilder.Entity<Assinatura>(entity =>
            {
                entity.HasKey(a => a.AssinaturaId);

                entity.Property(a => a.DataInicio)
                .IsRequired();

                entity.Property(a => a.DataFim)
                .IsRequired();

                entity.Property(a => a.Status)
                .IsRequired()
                .HasMaxLength (20)
                .IsUnicode(false);

                //Assinatura o Usuario 
                entity.HasOne(a => a.Usuario)
                  .WithMany()
                  .HasForeignKey(a => a.UsuarioId)
                  .OnDelete(DeleteBehavior.Cascade);
            });

        }
    }
}

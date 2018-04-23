using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Everton.Dominio.Entidade;
using Everton.Repositorio.EntityTypeConfigurations;

namespace Everton.Repositorio
{
    public class AppContexto : DbContext
    {
        public AppContexto()
            : base("DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(50));

            /*Definimos usando reflexão que toda propriedade que contenha
 "Nome da classe" + Id como "CursoId" por exemplo, seja dada como
 chave primária, caso não tenha sido especificado*/
            modelBuilder.Properties()
               .Where(p => p.Name == "Id" + p.ReflectedType.Name)
               .Configure(p => p.IsKey());

            modelBuilder.Configurations.Add(new UsuarioConfiguration());

        }
    }
}

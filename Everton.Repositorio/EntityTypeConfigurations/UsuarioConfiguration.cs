using Everton.Dominio.Entidade;
using Everton.Dominio.ValueObject;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Everton.Repositorio.EntityTypeConfigurations
{
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            ToTable("Usuario");

            HasKey(x => x.IdUsuario);
            Property(x => x.IdUsuario)
                .HasColumnName("IdUsuario")
                .HasColumnOrder(0)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.NomeUsuario)
                .HasColumnName("NomeUsuario")
                .HasColumnOrder(1)
                .IsOptional();

            Property(x => x.Cpf)
                .HasColumnName("CPF")
                .HasColumnOrder(2)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute("IX_CPF", 1) { IsUnique = true }));

            Property(x => x.Email)
                .HasColumnName("Email")
                .HasColumnOrder(3)
                .IsOptional();

            Property(x => x.Login)
                .HasColumnName("Login")
                .HasColumnOrder(4)
                .HasMaxLength(Usuario.LoginMaxLength)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute("IX_Login", 2) { IsUnique = true }));

            Property(x => x.DataInclusao)
                .IsOptional();
        }
    }
}

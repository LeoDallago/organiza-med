using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganizaMed.Dominio.ModuloAtendimento;

namespace OrganizaMed.Infra.ModuloAtendimento;

public class MapeadorAtendimentoOrn : IEntityTypeConfiguration<Atendimento>
{
    public void Configure(EntityTypeBuilder<Atendimento> builder)
    {
        builder.ToTable("TBAtendimento");

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Tipo)
            .IsRequired();

        builder.Property(x => x.HoraInicio)
            .HasColumnType("time")
            .IsRequired();
        
        builder.Property(x => x.HoraFim)
            .HasColumnType("time")
            .IsRequired();

        builder.HasOne(x => x.Medico)
            .WithMany()
            .HasForeignKey(x => x.MedicoId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Usuario)
            .WithMany()
            .IsRequired()
            .HasForeignKey(x => x.UsuarioId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
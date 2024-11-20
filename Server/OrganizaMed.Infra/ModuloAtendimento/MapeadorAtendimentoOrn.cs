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
            .HasColumnType("date")
            .IsRequired();
        
        builder.Property(x => x.HoraFim)
            .HasColumnType("date")
            .IsRequired();

        builder.HasOne(x => x.Medico)
            .WithMany()
            .HasForeignKey(x => x.MedicoId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}
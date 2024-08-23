using eAppointmentServer.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

internal sealed class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.Property(d => d.FirstName).HasColumnType("varchar(50)");
        builder.Property(d => d.LastName).HasColumnType("varchar(50)");
        builder.Property(p => p.IdentityNumber).HasColumnType("varchar(11)");
        builder.HasIndex(p => p.IdentityNumber).IsUnique();
    }
}
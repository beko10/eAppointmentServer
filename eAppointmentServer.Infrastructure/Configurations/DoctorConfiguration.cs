﻿using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eAppointmentServer.Infrastructure.Configurations;

internal sealed class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.Property(d => d.FirstName).HasColumnType("varchar(50)");
        builder.Property(d => d.LastName).HasColumnType("varchar(50)");
        builder.Property(d => d.Department)
            .HasConversion(x => x.Value, x => DepartmentEnum.FromValue(x))
            .HasColumnName("Department");
    }
}

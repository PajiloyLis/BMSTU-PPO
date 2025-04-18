using Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Context.Configuration;

/// <summary>
/// Company configuration.
/// </summary>
public class CompanyDbConfiguration : IEntityTypeConfiguration<CompanyDb>
{
    public void Configure(EntityTypeBuilder<CompanyDb> builder)
    {
        builder.HasKey(keyExpression => keyExpression.CompanyId);
        builder.Property(keyExpression => keyExpression.CompanyId).HasDefaultValueSql("gen_random_uuid()");

        builder.Property(keyExpression => keyExpression.Title).HasColumnType("text").IsRequired();
        builder.HasIndex(keyExpression => keyExpression.Title).IsUnique();

        builder.Property(keyExpression => keyExpression.RegistrationDate).HasColumnType("date").IsRequired();
        builder.ToTable(t => t.HasCheckConstraint("RegistrationDateCheck", "registration_date <= CURRENT_DATE"));

        builder.Property(keyExpression => keyExpression.PhoneNumber).HasColumnType("varchar(16)").IsRequired();
        builder.HasIndex(keyExpression => keyExpression.PhoneNumber).IsUnique();
        builder.ToTable(t => t.HasCheckConstraint("PhoneNumberCheck", "phone ~ '^\\+[0-9]{1,3}[0-9]{4,14}$'"));

        builder.Property(keyExpression => keyExpression.Email).HasColumnType("varchar(255)").IsRequired();
        builder.HasIndex(keyExpression => keyExpression.Email).IsUnique();
        builder.ToTable(t =>
            t.HasCheckConstraint("EmailCheck", "email ~ '^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}$'"));

        builder.Property(keyExpression => keyExpression.Inn).HasColumnType("varchar(10)").IsRequired();
        builder.HasIndex(keyExpression => keyExpression.Inn).IsUnique();
        builder.ToTable(t => t.HasCheckConstraint("InnCheck", "inn ~ '^[0-9]{10}$'"));

        builder.Property(keyExpression => keyExpression.Kpp).HasColumnType("varchar(9)").IsRequired();
        builder.HasIndex(keyExpression => keyExpression.Kpp).IsUnique();
        builder.ToTable(t => t.HasCheckConstraint("KppCheck", "kpp ~ '^[0-9]{9}$'"));

        builder.Property(keyExpression => keyExpression.Ogrn).HasColumnType("varchar(13)").IsRequired();
        builder.HasIndex(keyExpression => keyExpression.Ogrn).IsUnique();
        builder.ToTable(t => t.HasCheckConstraint("OgrnChek", "ogrn ~ '^[0-9]{13}$'"));

        builder.Property(keyExpression => keyExpression.Address).HasColumnType("text").IsRequired();
    }
}
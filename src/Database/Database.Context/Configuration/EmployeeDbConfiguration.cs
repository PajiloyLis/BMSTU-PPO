using Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Context.Configuration;

public class EmployeeDbConfiguration : IEntityTypeConfiguration<EmployeeDb>
{
    public void Configure(EntityTypeBuilder<EmployeeDb> builder)
    {
        builder.HasKey(keyExpression => keyExpression.Id);
        builder.Property(keyExpression => keyExpression.Id).HasDefaultValueSql("gen_random_uuid()");

        builder.Property(keyExpression => keyExpression.FullName).IsRequired();
        builder.Property(keyExpression => keyExpression.FullName).HasColumnType("text");

        builder.Property(keyExpression => keyExpression.Phone).HasColumnType("varchar(16)").IsRequired();
        builder.ToTable(t => t.HasCheckConstraint("PhoneCheck", "phone ~ '^\\+[0-9]{1,3}[0-9]{4,14}$'"));
        builder.HasIndex(keyExpression => keyExpression.Phone).IsUnique();

        builder.Property(keyExpression => keyExpression.Email).HasColumnType("varchar(255)").IsRequired();
        builder.HasIndex(keExpression => keExpression.Email).IsUnique();
        builder.ToTable(t =>
            t.HasCheckConstraint("EmailCheck", "email ~ '^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}$'"));

        builder.Property(keyExpression => keyExpression.BirthDate).HasColumnType("date").IsRequired();
        builder.ToTable(t => t.HasCheckConstraint("BirthDateCheck", "birth_date < CURRENT_DATE"));

        builder.Property(keyExpression => keyExpression.Photo).HasColumnType("text");
        builder.HasIndex(keyExpression => keyExpression.Photo).IsUnique();
        builder.Property(keyExpression => keyExpression.Photo).HasDefaultValueSql("null");

        builder.Property(keyExpression => keyExpression.Duties).HasColumnType("jsonb").HasDefaultValueSql("null");
    }
}
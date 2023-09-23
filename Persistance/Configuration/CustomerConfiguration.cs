using Domain.Entities.Customers;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configuration;

internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(c => c.Id);

        builder
            .Property(c => c.Id)
            .HasConversion(
            cId => cId.Value,
            value => new CustomerId(value));

        builder
            .Property(e => e.Email)
            .HasConversion(email => email.Value, value => Email.Create(value).Value);

        builder
            .Property(f => f.FirstName)
            .HasConversion(firstName => firstName.Value, value => FirstName.Create(value).Value);

        builder
            .Property(c => c.LastName)
            .HasConversion(
            lastName => lastName.Value, value => LastName.Create(value).Value);

        builder
            .Property(c => c.Password)
            .HasConversion(password => password.Value, value => Password.Create(value).Value);

        builder.HasIndex(c => c.Email).IsUnique();
    }
}

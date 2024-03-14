using FutureProjects.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FutureProjects.Infrastructure.Persistance.Configurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Id)
                .IsRequired(false);

            builder.Property(x => x.Name)
                .HasMaxLength(20)
                .IsRequired();

        }
    }
}

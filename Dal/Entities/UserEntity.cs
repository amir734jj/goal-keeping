using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Dal.Entities;

public class UserEntity : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .Property(x => x.Description)
            .HasDefaultValue(string.Empty);

        builder.Property(x => x.Photo)
            .HasDefaultValue(string.Empty);
    }
}
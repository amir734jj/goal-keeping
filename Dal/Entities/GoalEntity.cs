using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Dal.Entities
{
    public class GoalEntity : IEntityTypeConfiguration<Goal>
    {
        public void Configure(EntityTypeBuilder<Goal> builder)
        {
            builder.HasOne(x => x.UserRef)
                .WithMany(x => x.Goals)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
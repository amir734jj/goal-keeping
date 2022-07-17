using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Dal.Entities
{
    public class GoalItemEntity : IEntityTypeConfiguration<GoalItem>
    {
        public void Configure(EntityTypeBuilder<GoalItem> builder)
        {
            builder.HasOne(x => x.GoalRef)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.GoalRefId);
        }
    }
}
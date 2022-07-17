using EfCoreRepository;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Dal.Profiles
{
    public class GoalItemProfile : EntityProfile<GoalItem>
    {
        public override void Update(GoalItem entity, GoalItem dto)
        {
            entity.Text = dto.Text;
        }

        public override IQueryable<GoalItem> Include<TQueryable>(TQueryable queryable)
        {
            return queryable
                .Include(x => x.GoalRef);
        }
    }
}
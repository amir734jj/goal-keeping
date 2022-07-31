using EfCoreRepository;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Dal.Profiles
{
    public class GoalProfile : EntityProfile<Goal>
    {
        public override void Update(Goal entity, Goal dto)
        {
            entity.AddedDate = dto.AddedDate;
        }

        public override IQueryable<Goal> Include<TQueryable>(TQueryable queryable)
        {
            return queryable
                .Include(x => x.UserRef);
        }
    }
}
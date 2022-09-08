using EfCoreRepository;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Dal.Profiles
{
    public class GoalProfile : EntityProfile<Goal>
    {
        public GoalProfile()
        {
            Map(x => x.AddedDate);
            Map(x => x.Text);
        }

        public override IQueryable<Goal> Include<TQueryable>(TQueryable queryable)
        {
            return queryable
                .Include(x => x.UserRef);
        }
    }
}
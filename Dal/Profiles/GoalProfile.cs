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
            entity.RenewedDate = dto.RenewedDate;
            ModifyList(entity.Items, dto.Items, x => x.Id);
        }

        public override IQueryable<Goal> Include<TQueryable>(TQueryable queryable)
        {
            return queryable
                .Include(x => x.UserRef)
                .Include(x => x.Items);
        }
    }
}
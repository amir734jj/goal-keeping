using EfCoreRepository;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Dal.Profiles
{
    public class UserProfile : EntityProfile<User>
    {
        public UserProfile()
        {
            Map(x => x.Role);
            Map(x => x.Name);
            Map(x => x.Email);
            Map(x => x.Description);
            Map(x => x.LastLoginTime);
            Map(x => x.Photo);
        }

        public override IQueryable<User> Include<TQueryable>(TQueryable queryable)
        {
            return queryable.Include(x => x.Goals);
        }
    }
}
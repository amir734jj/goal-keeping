using EfCoreRepository.Interfaces;
using Logic.Abstracts;
using Logic.Interfaces;
using Models;

namespace Logic.Crud
{
    public class GoalLogic : BasicLogicUserBoundAbstract<Goal>, IGoalLogic
    {
        private readonly IBasicCrud<Goal> _goalDal;

        /// <summary>
        /// Constructor dependency injection
        /// </summary>
        /// <param name="repository"></param>
        public GoalLogic(IEfRepository repository)
        {
            _goalDal = repository.For<Goal>();
        }

        /// <summary>
        /// Returns DAL
        /// </summary>
        /// <returns></returns>
        protected override IBasicCrud<Goal> GetBasicCrudDal()
        {
            return _goalDal;
        }

        public Task<IEnumerable<Goal>> GetAll(User user, DateTimeOffset addedDate)
        {
            return _goalDal.GetAll(x => x.UserRefId == user.Id && x.AddedDate == addedDate);
        }
    }
}
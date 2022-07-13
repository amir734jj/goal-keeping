using EfCoreRepository.Interfaces;
using Logic.Abstracts;
using Logic.Interfaces;
using Models;

namespace Logic.Crud
{
    public class GoalLogic : BasicLogicAbstract<Goal>, IGoalLogic
    {
        private readonly IBasicCrud<Goal> _blogDal;

        /// <summary>
        /// Constructor dependency injection
        /// </summary>
        /// <param name="repository"></param>
        public GoalLogic(IEfRepository repository)
        {
            _blogDal = repository.For<Goal>();
        }

        /// <summary>
        /// Returns DAL
        /// </summary>
        /// <returns></returns>
        protected override IBasicCrud<Goal> GetBasicCrudDal()
        {
            return _blogDal;
        }

        public Task<Goal> Renew(int id)
        {
            throw new NotImplementedException();
        }
    }
}
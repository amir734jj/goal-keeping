using EfCoreRepository.Interfaces;
using Logic.Abstracts;
using Logic.Interfaces;
using Models;
using Models.ViewModels.Api;

namespace Logic.Crud
{
    public class GoalLogic : BasicLogicAbstract<Goal>, IGoalLogic
    {
        private readonly IBasicCrud<Goal> _goalDal;
        private readonly IBasicCrud<GoalItem> _goalItemDal;

        /// <summary>
        /// Constructor dependency injection
        /// </summary>
        /// <param name="repository"></param>
        public GoalLogic(IEfRepository repository)
        {
            _goalDal = repository.For<Goal>();
            _goalItemDal = repository.For<GoalItem>();
        }

        /// <summary>
        /// Returns DAL
        /// </summary>
        /// <returns></returns>
        protected override IBasicCrud<Goal> GetBasicCrudDal()
        {
            return _goalDal;
        }

        public Task<Goal> Renew(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<GoalViewModel?> GetTodayGaol(User user)
        {
            var goal = (await _goalDal.GetAll(x => x.UserRefId == user.Id))
                .ToList()
                .FirstOrDefault(x => x.AddedDate.Date == DateTime.Now.Date);

            if (goal == null)
            {
                return null;
            }

            return new GoalViewModel
            {
                Gaol1 = goal.Items.Skip(0).FirstOrDefault()?.Text,
                Gaol2 = goal.Items.Skip(1).FirstOrDefault()?.Text,
                Gaol3 = goal.Items.Skip(2).FirstOrDefault()?.Text,
            };
        }

        public async Task<GoalViewModel?> SaveTodayGaol(User user, GoalViewModel goalViewModel)
        {
            var goal = await _goalDal.Save(new Goal
            {
                UserRefId = user.Id,
                AddedDate = DateTimeOffset.Now,
                RenewedDate = DateTimeOffset.Now
            });

            if (!string.IsNullOrEmpty(goalViewModel.Gaol1))
            {
                await _goalItemDal.Save(new GoalItem
                {
                    Text = goalViewModel.Gaol1,
                    GoalRefId = goal.Id
                });
            }

            if (!string.IsNullOrEmpty(goalViewModel.Gaol2))
            {
                await _goalItemDal.Save(new GoalItem
                {
                    Text = goalViewModel.Gaol2,
                    GoalRefId = goal.Id
                });
            }

            if (!string.IsNullOrEmpty(goalViewModel.Gaol3))
            {
                await _goalItemDal.Save(new GoalItem
                {
                    Text = goalViewModel.Gaol3,
                    GoalRefId = goal.Id
                });
            }

            return await GetTodayGaol(user);
        }

        public async Task<GoalViewModel?> UpdateTodayGaol(User user, GoalViewModel goalViewModel)
        {
            var goal = (await _goalDal.GetAll(x => x.UserRefId == user.Id))
                .ToList()
                .FirstOrDefault(x => x.AddedDate.Date == DateTime.Now.Date);

            if (goal == null)
            {
                return null;
            }

            var firstGaol = goal.Items.Skip(0).FirstOrDefault();
            var secondGaol = goal.Items.Skip(1).FirstOrDefault();
            var thirdGaol = goal.Items.Skip(2).FirstOrDefault();

            if (!string.IsNullOrEmpty(goalViewModel.Gaol1))
            {
                if (firstGaol != null)
                {
                    await _goalItemDal.Update(firstGaol.Id, x => { x.Text = goalViewModel.Gaol1!; });
                }
                else
                {
                    await _goalItemDal.Save(new GoalItem
                    {
                        Text = goalViewModel.Gaol1,
                        GoalRefId = goal.Id
                    });
                }
            }

            if (!string.IsNullOrEmpty(goalViewModel.Gaol2))
            {
                if (secondGaol != null)
                {
                    await _goalItemDal.Update(secondGaol.Id, x => { x.Text = goalViewModel.Gaol2!; });
                }
                else
                {
                    await _goalItemDal.Save(new GoalItem
                    {
                        Text = goalViewModel.Gaol2,
                        GoalRefId = goal.Id
                    });
                }
            }

            if (!string.IsNullOrEmpty(goalViewModel.Gaol3))
            {
                if (thirdGaol != null)
                {
                    await _goalItemDal.Update(thirdGaol.Id, x => { x.Text = goalViewModel.Gaol3!; });
                }
                else
                {
                    await _goalItemDal.Save(new GoalItem
                    {
                        Text = goalViewModel.Gaol3,
                        GoalRefId = goal.Id
                    });
                }
            }

            return await GetTodayGaol(user);
        }
    }
}
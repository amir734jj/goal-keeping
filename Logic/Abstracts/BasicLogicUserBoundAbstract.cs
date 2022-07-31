using Logic.Interfaces;
using Models;
using Models.Interfaces;

namespace Logic.Abstracts;

public abstract class BasicLogicUserBoundAbstract<T> : BasicLogicAbstract<T>,
    IBasicLogicUserBound<T> where T: class,IEntityUserBound
{
    public Task<IEnumerable<T>> GetAll(User user)
    {
        return GetBasicCrudDal().GetAll(x => x.UserRefId == user.Id);
    }

    public Task<T> Get(User user, int id)
    {
        return GetBasicCrudDal().Get(x => x.UserRefId == user.Id && x.Id == id);
    }

    public Task<T> Save(User user, T instance)
    {
        instance.UserRefId = user.Id;

        return GetBasicCrudDal().Save(instance);
    }

    public Task<T> Delete(User user, int id)
    {
        return GetBasicCrudDal().Delete(x => x.UserRefId == user.Id && x.Id == id);
    }

    public Task<T> Update(User user, int id, T dto)
    {
        dto.UserRefId = user.Id;
        
        return GetBasicCrudDal().Update(x => x.UserRefId == user.Id && x.Id == id, dto);
    }

    public Task<T> Update(User user, int id, Action<T> updater)
    {
        return GetBasicCrudDal().Update(x => x.UserRefId == user.Id && x.Id == id, dto =>
        {
            dto.UserRefId = user.Id;

            updater(dto);
        });
    }
}
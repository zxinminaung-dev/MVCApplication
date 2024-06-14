using MVCApplication.Models.Common;

namespace MVCApplication.DataAccess
{
    public interface IRepository<T> where T : BaseEntity, new()
    {
        List<T> GetAll();
        T Get(int id);
        int CreateOrUpdate(T entity);
        int Delete(T entity);   
    }
}

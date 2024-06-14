using MVCApplication.Models.Common;

namespace MVCApplication.DataAccess
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly DatabaseContext _context;
        public Repository(DatabaseContext context) 
        { 
            _context = context;
        }

        public int CreateOrUpdate(T entity)
        {
            _context.Set<T>().Add(entity);
            if (entity.id > 0)
            {
                _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }else
            {
                _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            _context.SaveChanges();
            int id = (int)entity.GetType().GetProperty("id").GetValue(entity);
            return id;
        }
        public int Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
            int id = (int)entity.GetType().GetProperty("id").GetValue(entity);
            return id;
            //throw new NotImplementedException();
        }

        public T Get(int id)
        {
            return _context.Set<T>().Where(x => x.id == id).FirstOrDefault();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
    }
}

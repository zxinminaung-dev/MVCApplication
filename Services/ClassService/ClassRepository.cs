using MVCApplication.DataAccess;
using MVCApplication.Models;

namespace MVCApplication.Services.ClassService
{
    public class ClassRepository : Repository<Class>, IClassRepository
    {
        public ClassRepository(DatabaseContext context) : base(context)
        {
        }

        public Class GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}

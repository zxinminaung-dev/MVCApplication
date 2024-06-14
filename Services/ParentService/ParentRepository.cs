using MVCApplication.DataAccess;
using MVCApplication.Models;

namespace MVCApplication.Services.ParentService
{
    public class ParentRepository : Repository<Parent>, IParentRepository
    {
        public ParentRepository(DatabaseContext context) 
            : base(context)
        {
        }
    }
}

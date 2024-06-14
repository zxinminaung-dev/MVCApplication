using MVCApplication.DataAccess;
using MVCApplication.Models;

namespace MVCApplication.Services.ClassService
{
    public interface IClassRepository : IRepository<Class>
    {
        Class GetByName(string name);   
    }
}

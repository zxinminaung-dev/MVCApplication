using MVCApplication.DataAccess;
using MVCApplication.Models;

namespace MVCApplication.Services.StudentService
{
    public interface IStudentRepository : IRepository<Student>
    {
    }
}

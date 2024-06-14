using MVCApplication.DataAccess;
using MVCApplication.Models;

namespace MVCApplication.Services.StudentService
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(DatabaseContext context) 
            : base(context)
        {

        }
    }
}

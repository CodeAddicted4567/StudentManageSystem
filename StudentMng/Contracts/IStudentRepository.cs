using StudentMng.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMng.Contracts
{
    public interface IStudentRepository
    {
        Task<List<Student>> AllStudentAsync();
        Task<Student> StudentByIdAsync(int id);
        Task<List<Student>> StudentByNameAsync(string name);
        Task<List<Student>> SortByNameAsync(string sortOrder);
        void CreateStudent(Student student);
        bool RemoveStudents(int id);
        bool EditStudent(Student student);
    }
}

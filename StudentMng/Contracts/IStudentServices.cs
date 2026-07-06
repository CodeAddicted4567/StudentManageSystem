using StudentMng.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMng.Contracts
{
    public interface IStudentServices
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task<List<Student>> SearchByName(string name);
        Task<List<Student>> SortStudent(string sortOrder);
        void AddStudent(Student student);
        Task<bool> ClearStudentsAsync(int id);
        Task<bool> ModifyStudentAsync(int id, Student student);
    }
}

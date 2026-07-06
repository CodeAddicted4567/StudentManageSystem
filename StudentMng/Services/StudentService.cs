using StudentMng.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StudentMng.Contracts;

namespace StudentMng.Services
{
    public class StudentService : IStudentServices
    {
        IStudentRepository student1;
        public StudentService(IStudentRepository _studentDAL) {
            student1 = _studentDAL;
        }
        //Fetching data
        public async Task<List<Student>> GetAllStudentsAsync()
        {
            var all = await student1.AllStudentAsync();
            return all;
        }
        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var studentDetails = await student1.StudentByIdAsync(id);
            return studentDetails;
        }
        public async Task<List<Student>> SearchByName(string name)
        {
            var searchedResult = await student1.StudentByNameAsync(name);
            return searchedResult;
        }
        //Manipulation of data of student
        //Sorting
        public async Task<List<Student>> SortStudent(string sortOrder)
        {
            var sortResult = await student1.SortByNameAsync(sortOrder);
            return sortResult;
        }
        //Insert
        public void AddStudent(Student student)
        {
            var studentData = new Student
            {
                Id = student.Id,
                Name = student.Name,
                Marks = student.Marks,
            };
            if(studentData.Name.GetType() == typeof(string) && studentData.Marks.GetType() == typeof(int))
            {
                student1.CreateStudent(student);
            }
            else
            {
                throw new Exception("Invalid data for Name or Marks");
            }
        }
        //Delete
        public async Task<bool> ClearStudentsAsync(int id)
        {
            var Student = await student1.StudentByIdAsync(id);
            if (Student == null)
            {
                return false;
            }
            return  student1.RemoveStudents(id);
        }
        //Update
        public async Task<bool> ModifyStudentAsync(int id,Student student)
        {
            var Student = await student1.StudentByIdAsync(id);
            if (Student == null)
            {
                return false;
            }
            Student.Name = student.Name;
            Student.Marks = student.Marks;
            
            return student1.EditStudent(Student);
        }
    }
}
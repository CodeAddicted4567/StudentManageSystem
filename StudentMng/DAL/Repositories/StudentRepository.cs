using System;
using StudentMng.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using StudentMng.Contracts;
using StudentMng.DAL.Utils;

namespace StudentMng.DAL.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public DbConnectionFactory factory;
        public StudentRepository(DbConnectionFactory _factory)
        {
            factory = _factory;
        }
        public async Task<List<Student>> AllStudentAsync()
        {
            List<Student> students = new List<Student>();
            using (var con = factory.GetConnect())
            {
                await con.OpenAsync();
                string query = "SELECT Id, Name, Marks FROM Std";//Avoid select * for unnecessary data transfer
                using (var cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader read = await cmd.ExecuteReaderAsync())
                    {
                        while (await read.ReadAsync())
                        {
                            students.Add(new Student
                            {
                                Id = Convert.ToInt32(read["Id"]),
                                Name = read["Name"].ToString(),
                                Marks = Convert.ToInt32(read["Marks"])
                            });
                        }
                    }
                }
                
            }
            return students;
        }
        public async Task<Student> StudentByIdAsync(int id)
        {
            Student student = null;
            using (var con = factory.GetConnect())
            {
                await con.OpenAsync();
                using (var cmd = new SqlCommand("SELECT Id, Name, Marks  FROM Std WHERE Id = @Id", con))
                {
                    //avoid addwithvalue as it can cause issues with type inference, instead use Add with explicit type and value
                    cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = id });
                    using (SqlDataReader read = await cmd.ExecuteReaderAsync())
                    {
                        if (await read.ReadAsync())
                        {
                            student = new Student
                            {
                                Id = Convert.ToInt32(read["Id"]),
                                Name = read["Name"].ToString(),
                                Marks = Convert.ToInt32(read["Marks"])
                            };
                        }
                    }
                }
            }
            return student;
        }
        public async Task<List<Student>> StudentByNameAsync(string name)
        {
            List<Student> students = new List<Student>();
            using (var con = factory.GetConnect())
            {
                await con.OpenAsync();
                string query = "SELECT Id, Name, Marks FROM Std WHERE Name LIKE @Name";//Partial match using
                using(var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 100) { Value = $"%{name}%" });
                    using (SqlDataReader read = await cmd.ExecuteReaderAsync())
                    {
                        while (await read.ReadAsync())
                        {
                            students.Add(new Student
                            {
                                Id = Convert.ToInt32(read["Id"]),
                                Name = read["Name"].ToString(),
                                Marks = Convert.ToInt32(read["Marks"])
                            });
                        }
                    }
                }
            }
            return students;
        }
        //Sorting Student Alphabetically
        public async Task<List<Student>> SortByNameAsync(string sortOrder)
        {
            List<Student> students = new List<Student>();
            using (var con = factory.GetConnect())
            {
                await con.OpenAsync();
                string direction = (sortOrder == "ASC") ? "ASC" : "DESC" ;//prevents SQL injection
                //Neither require sql parameters nor for any dynamic query as they are fixed queries 
                string query = $"SELECT Id, Name, Marks FROM Std ORDER BY Name {direction}";
                using (var cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader read = await cmd.ExecuteReaderAsync())
                    {
                        while (await read.ReadAsync())
                        {
                            students.Add(new Student
                            {
                                Id = Convert.ToInt32(read["Id"]),
                                Name = read["Name"].ToString(),
                                Marks = Convert.ToInt32(read["Marks"])
                            });
                        }
                    }
                }
           }
           return students;
        }
        //Manipulation of Student data
        public void CreateStudent(Student student)
        {
            using (var con = factory.GetConnect())
            {
                con.Open();
                using (var cmd = new SqlCommand("INSERT INTO Std (Name, Marks) VALUES (@Name, @Marks)", con))
                {
                    cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 100) { Value = student.Name });
                    cmd.Parameters.Add(new SqlParameter("@Marks", SqlDbType.Int) { Value = student.Marks });
                    cmd.ExecuteNonQuery();
                }  
            }
        }
        public bool RemoveStudents(int id)
        {
            using (var con = factory.GetConnect())
            {
                con.Open();
                using (var cmd = new SqlCommand("DELETE FROM Std WHERE Id = @Id", con))
                {
                    cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = id });
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public bool EditStudent(Student student)
        {
            using (var con = factory.GetConnect())
            {
                con.Open();
                using (var cmd = new SqlCommand("UPDATE Std SET Name = @Name, Marks = @Marks WHERE Id = @Id", con))
                {
                    cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = student.Id });
                    cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 100) { Value = student.Name });
                    cmd.Parameters.Add(new SqlParameter("@Marks", SqlDbType.Int) { Value = student.Marks });
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
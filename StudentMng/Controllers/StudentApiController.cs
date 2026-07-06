using System.Web.Http;
using System.Threading.Tasks;
using StudentMng.Contracts;

namespace StudentMng.Controllers
{
    public class StudentApiController : ApiController
    {
        public IStudentServices services;
        //DI for services
        public StudentApiController(IStudentServices _service)
        {
            services = _service;
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            var students = await services.GetAllStudentsAsync();
            return Ok(students);
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)//id is for routing
        {
            var student = await services.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetByName(string name)//name is for querying
        {
            var student = await services.SearchByName(name);
            if(student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        //Post does not able to create because there has no body in request on ASP.NET MVC, whether we use form
        //So if we have to create we need such tools like Postman
    }
}

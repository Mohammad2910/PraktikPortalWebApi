using Microsoft.AspNetCore.Mvc;
using PraktikPortalWebApi.EfCore;
using PraktikPortalWebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PraktikPortalWebApi.Controllers
{
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly DbHelper _dbHelper;
        public StudentController(EF_DataContext eF_DataContext)
        {
            _dbHelper = new DbHelper(eF_DataContext);
        }

        // GET: api/students
        [HttpGet]
        [Route("api/students")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<StudentModel> students = _dbHelper.GetStudents();
                if (!students.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(students);
            }
            catch (Exception ex)
            {
                type = ResponseType.Failure;
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }

        }

        // GET api/students/5
        [HttpGet("{id}")]
        [Route("api/students/{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                StudentModel student = _dbHelper.GetStudentById(id);
                if (student == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using PraktikPortalWebApi.EfCore;
using PraktikPortalWebApi.Models;

namespace PraktikPortalWebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class InternshipController : ControllerBase
    {
        private readonly DbHelper _dbHelper;
        public InternshipController(EF_DataContext eF_DataContext)
        {
            _dbHelper = new DbHelper(eF_DataContext);
        }

        // GET: api/internships
        [HttpGet]
        [Route("internships")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<InternshipModel> internships = _dbHelper.GetInternships();
                if (!internships.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(internships);
            }
            catch (Exception ex)
            {
                type = ResponseType.Failure;
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }

        }

        // GET: api/internships/id
        [HttpGet("{id}")]
        [Route("internships/{id}")]
        public IActionResult GetInternshipByUserId(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                UserModel user = _dbHelper.GetUserById(id);
                IEnumerable<InternshipModel> internships = null;
                if (user.type == 1)
                {
                    internships = _dbHelper.GetInternshipByUserIdAndIdType(id, "user_id");
                }
                else if (user.type == 2)
                {
                    internships = _dbHelper.GetInternshipByUserIdAndIdType(id, "DTUSupervisor_id");
                }
                else if (user.type == 3)
                {
                    internships = _dbHelper.GetInternshipByUserIdAndIdType(id, "CompanySupervisor_id");
                }
                System.Diagnostics.Debug.WriteLine(internships);
                // type = ResponseType.NotFound;
                return Ok(internships);
            }
            catch (Exception e)
            {

            }
            return Ok();
        }
    }
}

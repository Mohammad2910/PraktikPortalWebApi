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
    }
}

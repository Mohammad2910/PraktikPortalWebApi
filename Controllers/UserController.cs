using Microsoft.AspNetCore.Mvc;
using PraktikPortalWebApi.EfCore;
using PraktikPortalWebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PraktikPortalWebApi.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DbHelper _dbHelper;
        public UserController(EF_DataContext eF_DataContext)
        {
            _dbHelper = new DbHelper(eF_DataContext); 
        }

        // GET: api/users
        [HttpGet]
        [Route("api/users")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<UserModel> Users = _dbHelper.GetUsers();
                if (!Users.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(Users);
            }
            catch (Exception ex)
            {
                type = ResponseType.Failure;
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }

        }

        // GET api/users/5
        [HttpGet("{id}")]
        [Route("api/users/{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                UserModel user = _dbHelper.GetUserById(id);
                if (user == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // POST api/users/
        [HttpPost]
        [Route("api/users")]
        public IActionResult Save([FromBody] UserModel user)
        {
            try
            {
                _dbHelper.saveUser(user);
                UserModel newUser = _dbHelper.GetUserById(user.id);
                return Ok(newUser);
            } catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        // PUT api/users/
        [HttpPut]
        [Route("api/users")]
        public IActionResult Update(UserModel user)
        {
            try
            {
                _dbHelper.saveUser(user);
                UserModel newUser = _dbHelper.GetUserById(user.id);
                return Ok(newUser);
            } catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}

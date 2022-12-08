using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PraktikPortalWebApi.EfCore;
using PraktikPortalWebApi.Models;

namespace PraktikPortalWebApi.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DbHelper _dbHelper;
        private readonly IJwtTokenManager _jwtTokenManager;
        public LoginController(EF_DataContext eF_DataContext, IJwtTokenManager jwtTokenManager)
        {
            _dbHelper = new DbHelper(eF_DataContext);
            _jwtTokenManager = jwtTokenManager;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/authenticate")]
        public IActionResult Authenticate([FromBody]Credentials credentials)
        {
            var token = _jwtTokenManager.Authenticate(credentials.username, credentials.password);
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            } else
            {
                UserModel user = _dbHelper.GetUserByUsername(credentials.username);
                return Ok(new { token, user});
            }
        }
    }
}

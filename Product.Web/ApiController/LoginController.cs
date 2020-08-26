using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Product.Service.Services.User;
using Product.Service.ViewModels;

namespace Product.Web.ApiController
{
    [Route("api/Login")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : Controller
    {
        public ILoginService loginService;
        public LoginController(ILoginService _loginService)
        {
            loginService = _loginService;
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Login([FromBody]LoginModel user)
        {
            if (user == null)
            {
                return BadRequest("Invalid request");
            }

            if (loginService.IsValidUser(user))
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("KeyForSignInSecret@1234"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:44302",
                    audience: "http://localhost:44302",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString });
            }
            else 
            {
                return Unauthorized();
            }
            
        }
    }
}
using Microsoft.IdentityModel.Tokens;
using Product.Data.Models;
using Product.Data.Repositories.IRepository;
using Product.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Product.Service.Services.User
{
    public class LoginService : ILoginService
    {
        protected IUserRepository userRepository;
        public LoginService(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        public bool IsValidUser(LoginModel user)
        {            
            Users userInDb = userRepository.GetUserByEmail(user.Email);
            return (userInDb != null && userInDb.Password == user.Password);           

        }

        public string LoginUser(LoginModel user)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("KeyForSignInSecret@1234"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                issuer: "http://localhost:44393",
                audience: "http://localhost:44393",
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: signinCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(tokeOptions);
        }
    }
}

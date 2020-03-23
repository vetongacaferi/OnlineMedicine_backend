using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OnlineMedicine_api.Entities;
using OnlineMedicine_api.Helpers;
using OnlineMedicine_api.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMedicine_api.Services
{
    public class UserService : IUserService
    {
        private SignInManager<ApplicationUser> _signManager;
        private UserManager<ApplicationUser> _userManager;   

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings, SignInManager<ApplicationUser> signManager, UserManager<ApplicationUser> userManager)
        {
            _appSettings = appSettings.Value;
            _signManager = signManager;
            _userManager = userManager;
        }

        //public User Authenticate(string username, string password)
        //{
        //    var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);

        //     return null if user not found
        //    if (user == null)
        //        return null;

        //     authentication successful so generate jwt token
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new Claim[]
        //        {
        //            new Claim(ClaimTypes.Name, user.Id.ToString()),
        //            new Claim(ClaimTypes.Role, user.Role)
        //        }),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    user.Token = tokenHandler.WriteToken(token);

        //     remove password before returning
        //    user.Password = null;

        //    return user;
        //}


        public async Task<User> Authenticate(string username, string password)
        {
            User _user = new User();

            var user = await _userManager.FindByNameAsync(username);
            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {   
                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Id.ToString()),
                        new Claim(ClaimTypes.Role, Role.Admin)
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                _user.Token = tokenHandler.WriteToken(token);
                _user.Role = Role.Admin;
                _user.Username = user.UserName;

                // remove password before returning
                _user.Password = null;

                return _user;
            }

            return null;

        }

         
    
    
    }
}

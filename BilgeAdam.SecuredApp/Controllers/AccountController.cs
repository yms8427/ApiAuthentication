using BilgeAdam.SecuredApp.Model;
using BilgeAdam.SecuredApp.Services.Abstractions;
using BilgeAdam.SecuredApp.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BilgeAdam.SecuredApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserService service;
        private readonly string signingKey;

        public AccountController(IUserService service, IOptions<Settings> options)
        {
            this.service = service;
            signingKey = options.Value.AuthenticationKey;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginInputModel model)
        {
            var user = service.Login(model.UserName, model.Password);
            if (user != null)
            {
                var key = Encoding.ASCII.GetBytes(signingKey);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.GivenName, user.FullName)
                    }),
                    Expires = DateTime.Now.AddMinutes(15),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                string jwtToken = tokenHandler.WriteToken(token);
                return Ok(jwtToken);
            }
            return BadRequest("incorrect credentials");
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterInputModel model)
        {
            var dto = new RegisterDto
            {
                UserName = model.UserName,
                Password = model.Password,
                FirstName = model.FirstName,
                LastName = model.LastName,
                BirthDate = model.BirthDate
            };
            if (service.Register(dto))
            {
                return Ok(true);
            }
            return BadRequest(false);
        }
    }
}
using BilgeAdam.SecuredApp.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdam.SecuredApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly string signingKey;
        public AccountController(IOptions<Settings> options)
        {
            signingKey = options.Value.AuthenticationKey;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginInputModel model)
        {
            if (model.UserName == "can" && model.Password == "123")
            {
                var key = Encoding.ASCII.GetBytes(signingKey);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, "1"),
                        new Claim(ClaimTypes.Name, "can")
                    }),
                    Expires = DateTime.Now.AddMinutes(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                string jwtToken = tokenHandler.WriteToken(token);
                return Ok(jwtToken);
            }
            return BadRequest("incorrect credentials");
        }
    }
}

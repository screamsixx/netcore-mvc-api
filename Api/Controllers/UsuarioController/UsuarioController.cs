using Business.Usuario;
using Data.Usuario;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Entity.Jwt;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Entity.Usuario;

namespace Api.Controllers.UsuarioController
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public IConfiguration _configuration;
        public UsuarioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpPost("Login")]
        public ActionResult Login([FromBody] Usuario usr)
        {
            isvalid ob= new isvalid();
            ob = UsuarioBusiness.Login(usr.Email, usr.Password);

            if ( ob.Valid)
            {
                var jwt = _configuration.GetSection("JwtSettings").Get<Jwt>();
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, jwt.Subjet),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("email", usr.Email)

                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
                var signIn = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
                var tokencreado = new JwtSecurityToken(
                    jwt.Issuer,
                    jwt.Audience,
                    claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials:signIn
                    );
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(tokencreado), email=usr.Email, id=ob.UserId });
            }
            else
            {
                return Unauthorized("Credenciales inválidas");
            }
        }
    }
}


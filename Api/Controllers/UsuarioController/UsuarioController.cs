using Business.Usuario;
using Data.Usuario;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
namespace Api.Controllers.UsuarioController
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly string secretkey;

        public UsuarioController(IConfiguration config)
        {
            secretkey = config.GetSection("settings").GetSection("secretkey").ToString();

        }


        [HttpPost("Login")]
        public ActionResult Login(string email, string password)
        {
            var result = UsuarioBusiness.Login(email, password);
            if (result)
            {
                // Aquí generas el token y lo envías como respuesta
                var keyBytes= Encoding.UTF8.GetBytes(secretkey);
                var claims = new ClaimsIdentity();
                 claims.AddClaim( new Claim(ClaimTypes.NameIdentifier, email));
                var tokendescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddDays(90), //Expira en 90 dias
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokendescriptor);
                string tokencreado = tokenHandler.WriteToken(tokenConfig);
                return Ok(new { tokencreado });
            }
            else
            {
                return Unauthorized("Credenciales inválidas");
            }
        }
    }
}


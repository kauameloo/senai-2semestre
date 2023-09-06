using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace senai.inlock.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }

        public UsuarioController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(UsuarioDomain usuario)
        {
            try
            {
                UsuarioDomain usuarioDomain = _UsuarioRepository.Login(usuario.Email, usuario.Senha);

                if (usuarioDomain == null)
                {
                    return NotFound("Usuário não encontrado, email ou senha inválidos");
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioDomain.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuarioDomain.Email),
                    new Claim(ClaimTypes.Role, usuarioDomain.IdTipoUsuario.ToString()),
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-chave-autenticacao-webapi-dev"));

                var creds = new SigningCredentials(key , SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                    (
                        issuer: "senai.inlock.webApi",

                        audience: "senai.inlock.webApi",

                        claims: claims,

                        expires: DateTime.Now.AddMinutes(5),

                        signingCredentials: creds
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}

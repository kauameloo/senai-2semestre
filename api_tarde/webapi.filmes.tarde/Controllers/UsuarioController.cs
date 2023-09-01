using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;
using webapi.filmes.tarde.Repositories;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;

namespace webapi.filmes.tarde.Controllers
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

        [HttpGet]
        public IActionResult Get(UsuarioDomain usuario)
        {
            try
            {
                // Faz chamada para o método de login
                UsuarioDomain usuarioDomain = _UsuarioRepository.Login(usuario.Email, usuario.Senha);

                if (usuarioDomain != null)
                {
                    // Login aprovado, você pode retornar um resultado com informações do usuário
                    return Ok(usuarioDomain);
                }
                else
                {
                    // Login falhou, retorna um status Unauthorized (401)
                    return NotFound("Usuário não encontrado, email ou senha inválidos!");
                }

                //Caso encontre o usuário buscado, prossegue para a criação do Token

                //1 - Definir as informações(Claims) que serão fornecidos no token (PayLoad)
                var claims = new[]
                {
                    //Formato da claim(tipo, valor)
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioDomain.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuarioDomain.Email),
                    new Claim(ClaimTypes.Role, usuarioDomain.Permissao),
                    //existe a possibilidade de criar uma claim personalizada
                    new Claim("Claim Personalizada", "Valor Personalizado")
                };

                //2 - Definir a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev"));

                //3 - Definir as credenciais do token (Header)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //4 - Gerar o token
                var token = new JwtSecurityToken
                    (
                        //emissor do token
                        issuer: "webapi.filmes.tarde",

                        //destinatário
                        audience: "webapi.filmes.tarde",

                        //dados definidos na claim (Payload)
                        claims: claims,

                        //tempo de expiração
                        expires: DateTime.Now.AddMinutes(5),

                        //credenciais do token
                        signingCredentials: creds
                    );

                return Ok(new 
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception erro)
            {
                // Retorna um status code BadRequest (400) e a mensagem de erro
                return BadRequest(erro.Message);
            }
        }
    }
}

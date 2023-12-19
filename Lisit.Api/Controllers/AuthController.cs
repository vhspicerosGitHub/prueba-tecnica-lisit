using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Lisit.Api.ViewModel.Auth;
using Lisit.Common;
using Lisit.Models;
using Lisit.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Lisit.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase {

    private IConfiguration _config;
    private readonly ILogger<AuthController> _logger;
    private readonly IAuthServices _authService;

    public AuthController(IAuthServices authServices, IConfiguration config, ILogger<AuthController> logger) {
        _authService = authServices;
        _config = config;
        _logger = logger;

    }


    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request) {
        try {
            var user = await _authService.Login(request.Email, request.Password); // Lanza una Excepcion en caso no logearse
            if (user == null)
                throw new BusinessException("Password incorrect");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.UtcNow.AddMinutes(240),
              signingCredentials: credentials);

            Sectoken.Payload.AddClaim(new Claim(ClaimTypes.Name, request.Email));
            Sectoken.Payload.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            Sectoken.Payload.AddClaim(new Claim(ClaimTypes.Role, Convert.ToInt16(user.EsAdministrador).ToString()));

            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);
            return new OkObjectResult(new { token });
        } catch (Exception e) {
            _logger.LogError(e, e.Message);
            throw e;
        }
    }

    [HttpPost("Registrarse")]
    public async Task<IActionResult> Registrarse([FromBody] RegistrarRequest request) {
        var fop = await _authService.Registrar(new Usuario {
            Nombre = request.Nombre,
            Email = request.Email,
            Password = request.Password,
            EsAdministrador = request.EsAdministrador,
            ComunaId = request.ComunaId
        });
        return Ok(fop);
    }
}



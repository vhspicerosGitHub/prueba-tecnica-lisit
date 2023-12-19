using Lisit.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Lisit.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Lisit.Api.ViewModel;

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
    public async Task<IActionResult> Post([FromBody] LoginRequest request) {
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

            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);
            return Ok(token);
        } catch (Exception e) {
            _logger.LogError(e, e.Message);
            throw e;
        }
    }
}



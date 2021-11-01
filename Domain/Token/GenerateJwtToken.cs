using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Token
{
  public class GenerateJwtToken
  {
    private readonly IConfiguration _configuration;
    private readonly UserManager<User> _userManager;
    public GenerateJwtToken(UserManager<User> userManager, IConfiguration configuration)
    {
      _userManager = userManager;
      _configuration = configuration;
    }
    public async Task<string> GenerateToken(User user)
    {
      // Now its ime to define the jwt token which will be responsible of creating our tokens
      var jwtTokenHandler = new JwtSecurityTokenHandler();

      // We get our secret from the appsettings
      var key = Encoding.ASCII.GetBytes(_configuration["JwtConfig:SecretKey"]);

      List<Claim> claims = new()
      {
        new Claim("Id", user.Id.ToString()),
        new Claim(ClaimTypes.Role, (await _userManager.GetRolesAsync(user)).FirstOrDefault()),
        new Claim(JwtRegisteredClaimNames.Sub, user.Email),
        new Claim(JwtRegisteredClaimNames.Email, user.Email),
        // the JTI is used for our refresh token which we will be convering in the next video
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
      };

      var token = new JwtSecurityToken(
        issuer: _configuration["JwtConfig:Issuer"],
        audience: _configuration["JwtConfig:Issuer"],
        claims: claims,
        signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature),
        expires: DateTime.Now.AddDays(1)
        );

      var jwtToken = jwtTokenHandler.WriteToken(token);

      return jwtToken;
    }
  }
}

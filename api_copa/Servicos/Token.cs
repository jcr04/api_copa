using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Newtonsoft.Json.Linq;
using System.IO;
using System;
using Microsoft.IdentityModel.Tokens;
using api_copa.Models;

namespace api_copa.Servicos
{
    public class Token
    {
        public static string GerarToken(Administrador adm)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            JToken jsAppSettings = JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "appsettings.json")));
            var key = Encoding.ASCII.GetBytes(jsAppSettings["Secret"].ToString());
            var expirationTime = Convert.ToInt32(jsAppSettings["TempoExpiracao"]);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]{
                        new Claim(ClaimTypes.Name, adm.Nome),
                        new Claim(ClaimTypes.Role, adm.Permissao),
                    }),
                // Expires = DateTime.UtcNow.AddHours(expirationTime),
                Expires = DateTime.UtcNow.AddMinutes(expirationTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

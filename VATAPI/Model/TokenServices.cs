using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VATAPI.Model
{
    public class TokenServices
    {
        private const string SecretKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJBU0lUIFNlcnZpY2VzIEx0ZC4iLCJuYW1lIjoiVkFUX1VTRVIiLCJpYXQiOjE2Mzc2NDk4NDh9.H2kau8v1A2NhPBlnOF3dZoIPh6w8q-Up1dB0Gav6t98";
        public static readonly SymmetricSecurityKey SIGNEDKEY = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
        public static string GenerateJwtToken()
        {
            var credentials = new SigningCredentials(SIGNEDKEY, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(credentials);
            //Token will be expired after 1 Days
            DateTime Expire = DateTime.Now.AddDays(1);
            int ts = (int)(Expire - new DateTime(1970, 1, 1)).TotalSeconds;
           
            var payload = new JwtPayload()
            {
                { "sub","Test subject"},
                { "Name","Hridoy"},
                { "email","hridoy@asit.com.bd"},
                { "exp",ts},
                {"iss","http://erp1.bepza.gov.bd:84"},
                {"aud","http://erp1.bepza.gov.bd:84"}
            };
            var secToken = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();

            string tokenString = handler.WriteToken(secToken);
            return tokenString;
        }
    }
}

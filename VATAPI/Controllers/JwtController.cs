using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VATAPI.Model;
using VATAPI.Model.ViewModel;
using VATAPI.MSModels;
using Microsoft.EntityFrameworkCore;


namespace VATAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtController : ControllerBase
    {
        private readonly SQLDbContext _context;
        private IConfiguration _config;

        public JwtController(SQLDbContext context, IConfiguration configuration)
        {
            _context = context;
            _config = configuration;
        }

        [HttpPost]
        public IActionResult LoginToken([FromBody] JwtTokenAuth model)
        {
            SqlConnection sqlConnection = new SqlConnection(_config.GetConnectionString("HMSApiDBConnection"));

            if (ModelState.IsValid)
            {
                string LOG_ID = model.UserId.Trim().ToUpper(); //this.UserName.Text.Trim().ToUpper();
                string LOG_PASS = model.Password.Trim();
                string TerminalID = Environment.MachineName.ToString().Trim().ToUpper();
                string TerminalMAC = ApiProcessAccess.GetMacAddress();// AspProcessAccess.GetMacAddress();

                string encodedPw = model.Password;//ASITUtility.EncodePassword(UserSignInName + UserSignInPass);

                var user = _context.Userinfs.Where(x=>x.LOG_PASS == encodedPw && x.LOG_ID == model.UserId).ToList();
                //   ApiProcessAccess.GetSignedInUserList(sqlConnection, UserSignInName, encodedPw, TerminalID, "", "");

                if (user.Count == 0)
                    return BadRequest("User Not Found");
                try
                {
                    var empInfos = user.Where(e => e.LOG_ID == model.UserId.ToUpper()).Select(x => new VatEntityManpower.SignInInfo
                    {
                        LOG_ID = x.LOG_ID,
                        comcod = x.Comcod,
                        hccode = x.Hccode,
                        hcname = x.EMP_NAME
                    }).SingleOrDefault();

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ApiConstant.key));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var claims = new List<Claim>();

                    claims.Add(new Claim(JwtRegisteredClaimNames.Sub, model.UserId));
                    claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                    claims.Add(new Claim(JwtRegisteredClaimNames.UniqueName, empInfos.LOG_ID));

                    var token = new JwtSecurityToken(
                           ApiConstant.Issuer,
                           ApiConstant.Audience,
                           claims,
                           //expires: DateTime.UtcNow.AddMinutes(30),
                           expires: DateTime.UtcNow.AddHours(2),
                           signingCredentials: creds

                        );

                    var result = new LoggedUserModel
                    {
                        SignInfos = empInfos,
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                        Expiration = token.ValidTo,
                        hccode = empInfos.hccode,
                        terminalID = empInfos.terminalID,
                        LOG_ID = empInfos.LOG_ID,
                        hcname = empInfos.hcname,
                        sessionID = empInfos.sessionID
                    };
                    return Created("", result);

                }
                catch (Exception ex)
                {

                    throw;
                }



            }

            return BadRequest();
        }

    }
}

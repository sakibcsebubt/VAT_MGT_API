using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VATAPI.Model
{
    public class ApiConstant
    {
        public const string Issuer = "ASIT_VATUSER";
        public const string Audience = "VATUser";
        public const string key = "28216481291932476";

        public const string AuthSchemes = "Identity.Application" + "," + JwtBearerDefaults.AuthenticationScheme;
    }
}

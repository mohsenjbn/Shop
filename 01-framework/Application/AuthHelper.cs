using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Security.Claims;

namespace _01_framework.Application
{
    public class AuthHelper : IAuthHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public List<int> GetCurrentPermissions()
        {
            if(!IsAuthenticated())
                return new List<int>();

            var Permissions=_contextAccessor.HttpContext.User.Claims.FirstOrDefault(p=>p.Type=="Permissions")?.Value;
            return JsonConvert.DeserializeObject<List<int>>(Permissions);


        }

        public string GetCurrentRoleId()
        {
            if (IsAuthenticated())
                return _contextAccessor.HttpContext.User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.Role)?.Value;

            return "";
        }

        public AuthviewModel GetCurrentUserInfo()
        {
            var result = new AuthviewModel();

            if(IsAuthenticated())
            {
                var User = _contextAccessor.HttpContext.User.Claims.ToList();
                result.UserName = User.FirstOrDefault(p => p.Type == "UserName")?.Value;
                result.Name = User.FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier)?.Value;
                result.Id = long.Parse(User.FirstOrDefault(p => p.Type == "AccountId")?.Value);
                result.RoleId =long.Parse( User.FirstOrDefault(p => p.Type == ClaimTypes.Role)?.Value);
                result.Role = User.FirstOrDefault(p => p.Type == "Role")?.Value;
                
            } 
            
            return result;
        }

        public bool IsAuthenticated()
        {
            return _contextAccessor.HttpContext.User.Identity.IsAuthenticated;
           //var claims= _contextAccessor.HttpContext.User.Claims.ToList();

           // return claims.Count > 0;
        }

        public void Singin(AuthviewModel model)
        {   var Permissions=JsonConvert.SerializeObject(model.Promissions);
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, model.Name),
                new Claim("PhoneNumber", model.PhoneNumber),
                new Claim("UserName", model.UserName),
                new Claim("AccountId", model.Id.ToString()),
                new Claim(ClaimTypes.Role,model.RoleId.ToString()),
                new Claim("Role",model.Role),
                new Claim("Permissions",Permissions)

            };

            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties()
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1)
            };

            _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimIdentity),
                authProperties);


        }

        public void Singout()
        {
            _contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}

using _01_framework.Application;
using _01_framework.Infrastracture;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;

namespace ServiceHost
{
    public class SecurityPageFilter : IPageFilter
    {
        private readonly IAuthHelper _authHelper;

        public SecurityPageFilter(IAuthHelper authHelper)
        {
            _authHelper = authHelper;
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {



            var needPermissions = (NeedPermission)context.HandlerMethod?.MethodInfo.GetCustomAttribute
               (typeof(NeedPermission))!;

            if (needPermissions == null)
                return;

            var userPermissions = _authHelper.GetCurrentPermissions();
            if (userPermissions != null && userPermissions.All(x => x != needPermissions.Code))
                context.HttpContext.Response.Redirect("/Account");



        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
        }
    }
}

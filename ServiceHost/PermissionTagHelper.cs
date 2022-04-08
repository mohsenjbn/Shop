using _01_framework.Application;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ServiceHost
{
    [HtmlTargetElement(Attributes ="Permission")]
    public class PermissionTagHelper : TagHelper
    {
        private readonly IAuthHelper _authHelper;
        public int Permission { get; set; }
        public PermissionTagHelper(IAuthHelper authHelper)
        {
            _authHelper = authHelper;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!_authHelper.IsAuthenticated())
            {
                output.SuppressOutput();
                return;
            }
            var Permissions = _authHelper.GetCurrentPermissions();

            if (Permissions == null)
                return;

            if (!Permissions.Contains(Permission))
            {
                output.SuppressOutput();
                return;

            }


            base.Process(context, output);
        }
    }
}

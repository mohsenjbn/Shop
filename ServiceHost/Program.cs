using _0_Framework.Application;
using _01_framework.Application;
using _01_framework.Application.PasswordHashing.PasswordHashingService;
using AccountManagement.Configuration;
using BlogManagement.Configuration;
using CommentManagement.infrastracture.Configuration;
using DiscountManegmant.Infrastracture.Configoration;
using InventoryManagement.Infrastracture.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using ServiceHost;
using ShopManagement.Configuration;
using System.Text.Encodings.Web;
using System.Text.Unicode;

var builder = WebApplication.CreateBuilder(args);
var ConnectionString = builder.Configuration.GetConnectionString("Shop");
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHttpContextAccessor();
ShopManagementBootstrapper.Configure(builder.Services, ConnectionString);
DiscountManagementBootStrapper.configore(builder.Services, ConnectionString);
InventoryManagementBootstrapper.Configure(builder.Services, ConnectionString);
BlogManagementBootStrapper.Configure(builder.Services, ConnectionString);
CommentManagementBootStrapper.Configure(builder.Services, ConnectionString);
AccountManagementBootstrapper.Configure(builder.Services, ConnectionString);

builder.Services.AddTransient<IFileUploder, FileUploder>();
builder.Services.AddTransient<IAuthHelper, AuthHelper>();

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.Lax;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
    {
        o.LoginPath = new PathString("/Account");
        o.LogoutPath = new PathString("/Account");
        o.AccessDeniedPath = new PathString("/AccessDenied");
    });

//builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IPasswordHashingService, _01_framework.Application.PasswordHashingService>();

builder.Services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Arabic));
var app = builder.Build();



if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseAuthentication();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();
app.UseRouting();


app.UseAuthorization();

app.MapRazorPages();

app.Run();

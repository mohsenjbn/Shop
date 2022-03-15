using _0_Framework.Application;
using _01_framework.Application;
using _01_framework.Application.PasswordHashing.PasswordHashingService;
using AccountManagement.Configuration;
using BlogManagement.Configuration;
using CommentManagement.infrastracture.Configuration;
using DiscountManegmant.Infrastracture.Configoration;
using InventoryManagement.Infrastracture.Configuration;
using ServiceHost;
using ShopManagement.Configuration;
using System.Text.Encodings.Web;
using System.Text.Unicode;

var builder = WebApplication.CreateBuilder(args);
var ConnectionString = builder.Configuration.GetConnectionString("Shop");
// Add services to the container.
builder.Services.AddRazorPages();

ShopManagementBootstrapper.Configure(builder.Services, ConnectionString);
DiscountManagementBootStrapper.configore(builder.Services, ConnectionString);
InventoryManagementBootstrapper.Configure(builder.Services, ConnectionString);
BlogManagementBootStrapper.Configure(builder.Services, ConnectionString);
CommentManagementBootStrapper.Configure(builder.Services, ConnectionString);
AccountManagementBootstrapper.Configure(builder.Services, ConnectionString);

builder.Services.AddTransient<IFileUploder, FileUploder>();
//builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IPasswordHashingService, _01_framework.Application.PasswordHashingService>();

builder.Services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Arabic));
var app = builder.Build();



if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthorization();

app.MapRazorPages();

app.Run();

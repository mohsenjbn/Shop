using _01_framework.Application;
using BlogManagement.Configuration;
using DiscountManegmant.Infrastracture.Configoration;
using InventoryManagement.Infrastracture.Configuration;
using ServiceHost;
using ShopManagement.Configuration;

var builder = WebApplication.CreateBuilder(args);
var ConnectionString = builder.Configuration.GetConnectionString("Shop");
// Add services to the container.
builder.Services.AddRazorPages();

ShopManagementBootstrapper.Configure(builder.Services, ConnectionString);
DiscountManagementBootStrapper.configore(builder.Services, ConnectionString);
InventoryManagementBootstrapper.Configure(builder.Services, ConnectionString);
BlogManagementBootStrapper.Configure(builder.Services, ConnectionString);
builder.Services.AddTransient<IFileUploder, FileUploder>();
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

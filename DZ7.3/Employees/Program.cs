using Employees.Models;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// dbContext
string connString = builder.Configuration.GetConnectionString("employees");

builder.Services.AddDbContext<employeesContext>(options =>
  options.UseMySql(connString, Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.22-mariadb")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Configure the application for OAuth based flow
PublicClientId = "self";
OAuthOptions = new OAuthAuthorizationServerOptions
{
    TokenEndpointPath = new PathString("/Token"),
    Provider = new AppOAuthProvider(PublicClientId),
    AuthorizeEndpointPath = new PathString("/Account/ExternalLogin"),
    AccessTokenExpireTimeSpan = TimeSpan.FromHours(4),
    AllowInsecureHttp = true //Don't do this in production ONLY FOR DEVELOPING: ALLOW INSECURE HTTP!
};

// Enable the application to use bearer tokens to authenticate users
app.UseOAuthBearerTokens(OAuthOptions);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

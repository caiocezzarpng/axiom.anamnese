using Axiom.Anamnese.Web.Service.IService;
using Axiom.Anamnese.Web.Service;
using Axiom.Anamnese.Web.Utils;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<IPersonService, PersonService>();

StaticDetails.PersonAPIBase = builder.Configuration["ServiceUrls:PersonAPI"];

builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<ITokenProvider, TokenProvider>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.ExpireTimeSpan = TimeSpan.FromHours(10);
            options.LoginPath = "/Auth/Login";
            options.AccessDeniedPath = "/Auth/AcessDenied";
        });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
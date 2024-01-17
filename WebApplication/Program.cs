
using BusinessCore.Abstract;
using BusinessCore.Concrete;
using Data.Abstract;
using Data.Concrete;
using Data.Db;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache(); // veya baþka bir önbellek mekanizmasý ekleyebilirsiniz
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Oturum süresini isteðe baðlý olarak ayarlayýn
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
    {
        option.LoginPath = "/Account/Login";
        option.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        
    }
    );
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("admin", policy =>
    {
        // Sadece "Admin" rolüne sahip kullanýcýlar bu politikayý geçebilir
        policy.RequireRole("admin");
    });
    options.AddPolicy("user", policy =>
    {
        // Sadece "Admin" rolüne sahip kullanýcýlar bu politikayý geçebilir
        policy.RequireRole("user");
    });
});
// Theses
builder.Services.AddScoped<IThesisDal, EfThesisDal>();
builder.Services.AddScoped<IThesisService, ThesisManager>();
// University
builder.Services.AddScoped<IUniversityDal, EfUniversityDal>();
builder.Services.AddScoped<IUniversityService, UniversityManager>();

// Institutes
builder.Services.AddScoped<IInstituteDal, EfInstituteDal>();
builder.Services.AddScoped<IInstituteService, InstituteManager>();
// Supervisors

builder.Services.AddScoped<ISupervisorDal, EfSupervisorDal>();
builder.Services.AddScoped<ISupervisorService, SupervisorManager>();


// Authors
builder.Services.AddScoped<IAuthorDal, EfAuthorDal>();
builder.Services.AddScoped<IAuthorService, AuthorManager>();

// Admin Accounts
builder.Services.AddScoped<IAccountDal, EfAccountDal>();
builder.Services.AddScoped<IAccountService, AccountManager>();
// User Accounts
// 
//builder.Services.AddDistributedMemoryCache(); // Add a distributed cache for sessions
//builder.Services.AddSession(options =>
//{
//    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout as needed
//    options.Cookie.HttpOnly = true;
//    options.Cookie.IsEssential = true;
//});
// Assuming 'user' is an instance of your user model
//builder.Services.AddAuthentication()
//    .AddCookie(options =>
//    {
//        options.LoginPath = "/Account/Login"; // Set login path
//        options.AccessDeniedPath = "/Account/AccessDenied"; // Set access denied path
//        options.LogoutPath = "/Account/Logout"; // Set logout path
//        options.Cookie.HttpOnly = true;
//        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Set expiration time as needed
//        options.SlidingExpiration = true;
//    });

//builder.Services.AddIdentity<IdentityUser, IdentityRole>()
//    .AddEntityFrameworkStores<ThesesContext>()
//    .AddDefaultTokenProviders();


//builder.Services.Configure<IdentityOptions>(options =>
//{
//    options.SignIn.RequireConfirmedAccount = false;
//    options.SignIn.RequireConfirmedEmail = false;
//    options.SignIn.RequireConfirmedPhoneNumber = false;

//    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
//    options.Lockout.MaxFailedAccessAttempts = 5;
//    options.Lockout.AllowedForNewUsers = true;

//    options.User.RequireUniqueEmail = true;

//    options.Password.RequireDigit = true;
//    options.Password.RequireLowercase = true;
//    options.Password.RequireUppercase = true;
//    options.Password.RequireNonAlphanumeric = true;
//    options.Password.RequiredLength = 5;
//});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//object addEntityFrameworkStores = builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddRoleValidator<ThesesContext>();


var app = builder.Build();
//var roleManager = app.Services.GetRequiredService<RoleManager<IdentityRole>>();

//// Check if roles exist, and create them if not
//var roles = new[] { "Admin", "User" };
//foreach (var role in roles)
//{
//    if (!roleManager.RoleExistsAsync(role).Result)
//    {
//        roleManager.CreateAsync(new IdentityRole(role)).Wait();
//    }
//}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Theses}/{action=Index}/{id?}");
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Theses}/{action=Index}/{id?}");

app.Run();

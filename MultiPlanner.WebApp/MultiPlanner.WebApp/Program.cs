using Microsoft.EntityFrameworkCore;
using MultiPlanner.WebApp.DAL;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<MultiPlannerContext>(options =>
    options.UseSqlServer(connectionString)); ;

builder.Services.AddDefaultIdentity<IdentityUser>(options => 
    options.SignIn.RequireConfirmedAccount = false)
        .AddEntityFrameworkStores<MultiPlannerContext>();

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication();

builder.Services.AddScoped<ITaskRepository, TaskRepository>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddSession();

builder.Services.AddRazorPages();

builder.Services.AddDbContext<MultiPlannerContext>(options => {
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:DefaultConnection"]);
});

builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.MapFallbackToPage("/home/{*catchall}", "/Home/Index");

app.Run();

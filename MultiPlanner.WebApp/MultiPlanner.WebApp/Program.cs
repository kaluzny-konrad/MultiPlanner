using Microsoft.EntityFrameworkCore;
using MultiPlanner.WebApp.Repositories;
using MultiPlanner.WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LocalApiDbContext>(options => {
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:DefaultConnection"]);
});

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddScoped<ITodoTaskRepository, TodoTaskRepository>();
builder.Services.AddScoped<ITodoTaskStatusRepository, TodoTaskStatusRepository>();

builder.Services.AddScoped<ITodoTaskService, TodoTaskService>();
builder.Services.AddScoped<ITodoTaskStatusService, TodoTaskStatusService>();
builder.Services.AddScoped<ITodoTaskListService, TodoTaskListService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

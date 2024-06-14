using Microsoft.EntityFrameworkCore;
using MVCApplication.DataAccess;
using MVCApplication.Models;
using MVCApplication.Services.ClassService;
using MVCApplication.Services.ParentService;
using MVCApplication.Services.StudentService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
string? connString = builder.Configuration.GetConnectionString("DefaultConnection");
//configure database
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseLazyLoadingProxies().UseSqlServer(connString)
);
builder.Services.AddHttpContextAccessor();
builder.Services.AddMvc();

builder.Services.AddScoped<IParentRepository, ParentRepository>();
builder.Services.AddScoped<IClassRepository, ClassRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

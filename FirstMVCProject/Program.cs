using FirstMVCProject.Models.Entity;
using FirstMVCProject.Repository.CompanyRepo;
using FirstMVCProject.Repository.EmploRep;
using FirstMVCProject.Repository.EmployeeRepInterFace;
using FirstMVCProject.Services.CompanyRegService;
using FirstMVCProject.Services.Employees;
using FirstMVCProject.Services.EmployeeService;
using FirstMVCProject.Services.EmployeeServiceInterface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


var dbConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddSqlServer<ApplicationDbContext>(dbConnection);

//Repository

builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

builder.Services.AddScoped<IEducationInfoRepository, EducationInfoRepository>();

builder.Services.AddScoped<INextOfKinRepository, NextOfKinRepository>();

builder.Services.AddScoped<IHealthStatusRepo, HealthStatusRepo>();

//Service
builder.Services.AddScoped<ICompanyService, CompanyService>();

builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddScoped<IEducationHistoryService, EducationHistoryService>();

builder.Services.AddScoped<INextOfKinService, NextOfKinService>();

builder.Services.AddScoped<IHealthStatus, HealthStatusService>();



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

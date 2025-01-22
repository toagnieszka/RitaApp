using RitaApp.DTOs.Validation;
using Microsoft.EntityFrameworkCore;
using RitaApp.Data;
using RitaApp.Middleware;
using RitaApp.Repositories;
using RitaApp.Services;
using FluentValidation;
using NLog.Web;
using Microsoft.AspNetCore.Authentication;
using RitaApp.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(LogLevel.Trace);
builder.Host.UseNLog();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RitaAppDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("RitaAppConnectionString"));
});

builder.Services.AddValidatorsFromAssemblyContaining<CreateCategoryDtoValidator>();

builder.Services.AddAuthentication()
				.AddBearerToken(IdentityConstants.BearerScheme);

builder.Services.AddIdentityCore<IdentityUser>()
				.AddEntityFrameworkStores<RitaAppDbContext>()
				.AddApiEndpoints();

builder.Services.AddAuthorizationBuilder();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IMagazineService, MagazineService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductCardService, ProductCardService>();
builder.Services.AddScoped<IUnitService, UnitService>();
//builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ExceptionHandlingMiddleware>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapIdentityApi<IdentityUser>();
app.MapGet("/test", (ClaimsPrincipal user) => $"Hello {user.Identity!.Name}").RequireAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();

using Business.Abstracts;
using Business.Concretes;
using Business.MapperProfile;
using Core.Cloudinary;
using Core.Security.Encyption;
using Core.Security.Jwt;
using DataAccess.Abstracts.Repositories;
using DataAccess.Concretes.EfRepositories;
using DataAccess.Data;
using Entities.Concretes;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(options =>
{
    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency Injections For Address
builder.Services.AddScoped<IAddressService, AddressManager>();
builder.Services.AddScoped<IAddressRepository, EfAddressRepository>();

//Dependency Injections For Ad
builder.Services.AddScoped<IAdService, AdManager>();
builder.Services.AddScoped<IAdRepository, EfAdRepository>();

//Dependency Injections For Category
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryRepository, EfCategoryRepository>();

//Dependency Injections For City
builder.Services.AddScoped<ICityService, CityManager>();
builder.Services.AddScoped<ICityRepository, EfCityRepository>();

//Dependency Injections For District
builder.Services.AddScoped<IDistrictService, DistrictManager>();
builder.Services.AddScoped<IDistrictRepository, EfDistrictRepository>();

//Dependency Injections For User
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IUserRepository, EfUserRepository>();

//Dependency Injections For OperationClaim
builder.Services.AddScoped<IOperationClaimService, OperationClaimManager>();
builder.Services.AddScoped<IOperationClaimRepository, EfOperationClaimRepository>();

//Dependency Injections For UserOperationClaim
builder.Services.AddScoped<IUserOperationClaimService, UserOperationClaimManager>();
builder.Services.AddScoped<IUserOperationClaimRepository, EfUserOperationClaimRepository>();

//Dependency Injections For Photo
builder.Services.AddScoped<IPhotoService, PhotoManager>();
builder.Services.AddScoped<IPhotoRepository, EfPhotoRepository>();

//Dependency Injections For Auth
builder.Services.AddScoped<IAuthService, AuthManager>();

//Dependency Injections For Token
builder.Services.AddScoped<ITokenHelper, JwtHelper>();

//CloudinarySettings
builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));

var connectionString = builder.Configuration.GetConnectionString("DB");
builder.Services.AddDbContext<HouseSallerDbContext>(opt => opt.UseSqlServer(connectionString).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", builder => builder.WithOrigins("http://localhost:4200"));
});

var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = tokenOptions.Issuer,
        ValidAudience = tokenOptions.Audience,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
    };
});

builder.Services.AddAutoMapper(typeof(MapProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader());

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

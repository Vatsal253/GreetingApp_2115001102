using NLog.Web;
using NLog;
using NLog.Config;
using BusinessLayer.Interface;
using BusinessLayer.Services;
using RepositoryLayer.Interface;
using RepositoryLayer.Services;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using Middleware.ExceptionMiddleware;
using BusinessLayer.Service;
using RepositoryLayer.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using HelloGreetingApplication.Helper;



var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SqlConnection");//used for connection to database
builder.Services.AddDbContext<GreetingContext>(options => options.UseSqlServer(connectionString));
var ConnectionString = builder.Configuration.GetConnectionString("SqlConnection");//used for connection to database
builder.Services.AddDbContext<UserContext>(options => options.UseSqlServer(ConnectionString));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IGreetingBL, GreetingBL>();
builder.Services.AddScoped<IGreetingRL, GreetingRL>();
builder.Services.AddScoped<IUserBL, UserBL>();
builder.Services.AddScoped<IUserRL, UserRL>();
builder.Services.AddScoped<JwtTokenHelper>();
builder.Services.AddScoped<EmailService>();


//logger using NLog
var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
LogManager.Configuration = new XmlLoggingConfiguration("C:\\Users\\Vatsal Jain\\source\\repos\\HelloGreetingApplication\\nlog.config");
var jwtSettings = builder.Configuration.GetSection("Jwt");
// jwt implementation
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]))

        };

    });

logger.Debug("init main");

builder.Logging.ClearProviders();
builder.Host.UseNLog();
var app = builder.Build();

//logger dependency injection

//Add swagger to container

app.UseSwagger();
app.UseSwaggerUI();
app.UseRequestLoggerMiddleware();
app.ConfigureExceptionMiddleware();




// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
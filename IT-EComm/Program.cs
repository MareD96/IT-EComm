using IT_EComm.DataAccess;
using IT_EComm.Helpers;
using IT_EComm.Models;
using IT_EComm.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(
    option => option.UseSqlServer(builder.Configuration.GetConnectionString("ITDb")));

//Adding services for Microsoft Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddControllers(option =>
{
    option.CacheProfiles.Add("CachingFor30Sec", new Microsoft.AspNetCore.Mvc.CacheProfile
    {
        Duration = 30
    });
}).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();

//Added services for caching
builder.Services.AddResponseCaching();

//Adding AutoMapper
builder.Services.AddAutoMapper(typeof(MapperConfiguration));

//Adding api versioning
builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    options.ReportApiVersions = true;
});
builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});
//Adding local repositories
builder.Services.AddScoped<ILaptopRepository, LaptopRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ILaptopImagesRepository, LaptopImagesRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer Scheme \r\n\r\n" +
        "Enter 'Bearer' [space] an then your token is the text input bellow \r\n\r\n" +
        "Example: \" Bearer 12345abcdef\"",
        Name = "Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Scheme = "Bearer"
    });


    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
        new OpenApiSecurityScheme
        {
            Reference= new OpenApiReference
            {
                Type=ReferenceType.SecurityScheme,
                Id="Bearer"
            },
            Scheme="oauth2",
            Name="Bearer",
            In=ParameterLocation.Header
        },
        new List<string>()
        }
    });

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version="v1.0",
        Title="IT-EComm",
        Description="v1.0 added api endpoints for creating laptops,images and users",
        Contact= new OpenApiContact
        {
            Name="Send Email to the owner of the API if you want to use it",
            Email="marko.dimitrov96@gmail.com"
        }


    });
    //TODO: Update V2 add Desktop, and Phones maybe, improve the user information
    options.SwaggerDoc("v2", new OpenApiInfo
    {
        Version = "v2.0",
        Title = "IT-EComm",
        Description = "Not yet done",
        Contact = new OpenApiContact
        {
            Name = "Email",
            Email = "marko.dimitrov96@gmail.com"
        }


    });


});

var key = builder.Configuration.GetValue<string>("APISetting:Secret");
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(
    x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });


builder.Services.AddTransient<ILogger>(s => s.GetService<ILogger<Program>>());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

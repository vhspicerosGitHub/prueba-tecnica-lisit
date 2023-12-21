using System.Reflection;
using System.Text;
using Lisit.Api.Filters;
using Lisit.Repositories.Interfaces;
using Lisit.Repositories.Interfaces.Localizacion;
using Lisit.Repositories.Interfaces.Reportes;
using Lisit.Repositories.SqlLiteRepositories;
using Lisit.Repositories.SqlLiteRepositories.Localizacion;
using Lisit.Repositories.SqlLiteRepositories.Reportes;
using Lisit.Services;
using Lisit.Services.Interfaces;
using Lisit.Services.Interfaces.Localizacion;
using Lisit.Services.Interfaces.Reportes;
using Lisit.Services.Localizacion;
using Lisit.Services.Reportes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;

try {
    var builder = WebApplication.CreateBuilder(args);

    //builder.Host.UseSerilog();  // Add SeriLog
    builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
    loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration));

    builder.Services.AddControllers();// Add services to the container.

    //Jwt configuration starts here
    var jwtIssuer = builder.Configuration.GetSection("Jwt:Issuer").Get<string>();
    var jwtKey = builder.Configuration.GetSection("Jwt:Key").Get<string>();

    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
     .AddJwtBearer(options => {
         options.TokenValidationParameters = new TokenValidationParameters {
             ValidateIssuer = true,
             ValidateAudience = true,
             ValidateLifetime = true,
             ValidateIssuerSigningKey = true,
             ValidIssuer = jwtIssuer,
             ValidAudience = jwtIssuer,
             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
         };
     });
    //Jwt configuration ends here



    Log.Information("Starting web application");

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    //builder.Services.AddSwaggerGen();

    builder.Services.AddSwaggerGen(c => {
        c.SwaggerDoc("v1", new OpenApiInfo {
            Title = "API",
            Description = "",
            Contact = new OpenApiContact {
                Name = "Víctor Hugo Saavedra",
                Email = "vhspiceros@gmail.com",
                Url = new Uri("https://github.com/vhspicerosGitHub")
            },
            License = new OpenApiLicense {
                Name = "MIT License",
                Url = new Uri("https://opensource.org/licenses/MIT")
            }
        });

        // generate the XML docs that'll drive the swagger docs
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath);
    });

    //  Repositories
    builder.Services.AddScoped<IPaisRepository, PaisRepository>();
    builder.Services.AddScoped<IComunaRepository, ComunaRepository>();
    builder.Services.AddScoped<IRegionRepository, RegionRepository>();
    builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
    builder.Services.AddScoped<IAyudaSocialRepository, AyudaSocialRepository>();
    builder.Services.AddScoped<IAyudaSocialAsignacionRepository, AyudaSocialAsignacionRepository>();
    builder.Services.AddScoped<IReportesRepository, ReportesRepository>();
    builder.Services.AddScoped<ILogNegocioRepository, LogNegocioRepository>();


    //  Services
    builder.Services.AddScoped<IPaisServices, PaisServices>();
    builder.Services.AddScoped<IRegionServices, RegionServices>();
    builder.Services.AddScoped<IComunaServices, ComunaServices>();
    builder.Services.AddScoped<IAuthServices, AuthServices>();
    builder.Services.AddScoped<IAyudaSocialServices, AyudaSocialServices>();
    builder.Services.AddScoped<IAyudaSocialAsignacionServices, AyudaSocialAsignacionServices>();
    builder.Services.AddScoped<IReportesServices, ReportesServices>();
    builder.Services.AddScoped<ILogNegocioServices, LogNegocioServices>();

    // Filtros para Autotizacion
    builder.Services.AddScoped<AdministradorAuthorization>();
    builder.Services.AddScoped<UsuarioAuthorization>();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment()) {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
} catch (Exception ex) {
    Log.Fatal(ex, "Application terminated unexpectedly");
} finally {
    Log.CloseAndFlush();
}

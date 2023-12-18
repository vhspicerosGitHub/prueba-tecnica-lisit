using Serilog;
using Lisit.Repositories.Interfaces.Base;
using Lisit.Repositories.SqlLiteRepositories;
using Lisit.Services;
using Lisit.Model;
using Lisit.Services.Interfaces.Base;
using Lisit.Services.Interfaces;

try
{
    var builder = WebApplication.CreateBuilder(args);

    //builder.Host.UseSerilog();  // Add SeriLog
    builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
    loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration));

    builder.Services.AddControllers();// Add services to the container.

    Log.Information("Starting web application");

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    //  Repositories
    builder.Services.AddTransient<IPaisRepository, PaisRepository>();
    builder.Services.AddTransient<IComunaRepository, ComunaRepository>();
    builder.Services.AddTransient<IRegionRepository, RegionRepository>();


    //  services
    builder.Services.AddTransient<IPaisServices, PaisServices>();
    builder.Services.AddTransient<IRegionServices, RegionServices>();
    builder.Services.AddTransient<IComunaServices, ComunaServices>();

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
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}

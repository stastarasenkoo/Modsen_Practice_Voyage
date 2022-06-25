using Serilog;
using Voyage.Common.Settings;
using Voyage.Dependencies;
using Voyage.WebAPI.Options;

Log.Logger = new LoggerConfiguration().CreateBootstrapLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, services, configuration) => configuration
    .ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddDataAccess(options => options.BindConfiguration((nameof(DatabaseConfigs))))
    .AddBusinessLogic();

builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

var app = builder.Build();

app.UseSerilogRequestLogging();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

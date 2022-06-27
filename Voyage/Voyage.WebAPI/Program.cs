using IdentityServer4.AccessTokenValidation;
using Serilog;
using Voyage.Business.Helpers;
using Voyage.Common.Settings;
using Voyage.Dependencies;
using Voyage.WebAPI.Options;

Log.Logger = new LoggerConfiguration().CreateBootstrapLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Host.UseSerilog((context, services, configuration) => configuration
    .ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
      .AddIdentityServerAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme, options =>
      {
          options.Authority = "https://localhost:5084";
          options.ApiName = "Voyage";
          options.RequireHttpsMetadata = false;
      });

builder.Services
    .AddDataAccess(options => options.BindConfiguration((nameof(DatabaseConfigs))))
    .AddBusinessLogic();

var databaseConfigs = builder.Configuration
    .GetSection(nameof(DatabaseConfigs))
    .Get<DatabaseConfigs>();

builder.Services.AddIdentityService(databaseConfigs);

builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

var app = builder.Build();

app.UseSerilogRequestLogging();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.OAuthClientId("swagger");

        options.OAuthClientSecret("eb300de4-add9-42f4-a3ac-abd3c60f1919");
    });
}

app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();

app.UseIdentityServer();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

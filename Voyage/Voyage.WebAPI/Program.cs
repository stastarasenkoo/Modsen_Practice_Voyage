using IdentityServer4.AccessTokenValidation;
using Voyage.Business.Helpers;
using Voyage.Common.Settings;
using Voyage.DataAccess.Helpers;
using Voyage.Dependencies;
using Voyage.WebAPI.Options;

var builder = WebApplication.CreateBuilder(args);

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

var databaseConfigs = builder.Configuration.GetSection(nameof(DatabaseConfigs)).Get<DatabaseConfigs>();

builder.Services.AddIdentityService(databaseConfigs);

builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
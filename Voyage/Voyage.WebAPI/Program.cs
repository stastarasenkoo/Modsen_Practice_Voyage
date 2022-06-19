using IdentityServer4.AccessTokenValidation;
using Microsoft.OpenApi.Models;
using Voyage.Common.Settings;
using Voyage.Dependencies;
using Voyage.WebAPI.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});

builder.Services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
           .AddIdentityServerAuthentication(options =>
           {
               options.Authority = "https://localhost:5084";
           });


builder.Services.AddIdentityServer()
    .AddInMemoryClients(ConfigureIdentity.Clients)
    .AddInMemoryApiScopes(ConfigureIdentity.ApiScopes)
    .AddDeveloperSigningCredential();

builder.Services
    .AddDataAccess(options => options.BindConfiguration((nameof(DatabaseConfigs))))
    .AddBusinessLogic();

builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

using ApiTest.DbConnectors;
using ApiTest.Repositories.Implements;
using ApiTest.Repositories.Interfaces;
using ApiTest.Services.Implements;
using ApiTest.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var tokenResponseHeader = builder.Configuration.GetSection("tokens").GetValue<string>("token_response_header");
var salt = builder.Configuration.GetSection("tokens").GetValue<string>("salt");
var key = Encoding.ASCII.GetBytes(salt);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
    {
        x.Events = new JwtBearerEvents
        {
            OnTokenValidated = context =>
            {
                return Task.CompletedTask;
            }
        };
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero,
        };
    });

builder.Services.AddHttpClient("other_server", httpClient =>
{
    httpClient.BaseAddress = new Uri(builder.Configuration.GetConnectionString("other_server"));
});

builder.Services.AddSingleton<MongoDbConnector>()
                .AddSingleton<UserRepository, MongoUserRepository>()
                .AddSingleton<AuthService, JwtAuthService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowCredentials()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(o => true)
                    .WithExposedHeaders(tokenResponseHeader));

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

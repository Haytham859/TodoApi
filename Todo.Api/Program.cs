using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Todo.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey=new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:Secret").Value)
                        ),
                    ValidIssuer = builder.Configuration.GetSection("Jwt:Issuer").Value,
                    ValidAudience = builder.Configuration.GetSection("Jwt:Audience").Value,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ClockSkew = TimeSpan.Zero,
                };
            });
        builder.Services.AddDependencies(builder.Configuration);
        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            
            app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.MapControllers();
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();

     
        app.Run();
    }
}
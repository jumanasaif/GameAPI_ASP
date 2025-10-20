using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApp1_GameStore.Data;
using WebApp1_GameStore.DTOs;
using WebApp1_GameStore.Entities;

namespace WebApp1_GameStore.Endpoints;

public static class AuthEndpoints
{
    public static RouteGroupBuilder MapAuthEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("auth");

        group.MapPost("/register", async (RegisterDto registerDto, GameStoreContext db) =>
        {

            if (await db.Users.AnyAsync(user => user.UserName == registerDto.UserName))
            {
                return Results.Conflict("Username already exists ");
            }

            var hasher = new PasswordHasher<User>();
            var user = new User
            {
                UserName = registerDto.UserName,
                Role = "User"
            };

            user.PasswordHash = hasher.HashPassword(user, registerDto.Password);

            db.Users.Add(user);
            await db.SaveChangesAsync();

            return Results.Created($"/auth/{user.Id}", new
            {
                user.Id,
                user.UserName,
                user.Role
            });
        });

        group.MapPost("/login", async (RegisterDto loginDto, GameStoreContext db, IConfiguration config) =>
        {
            var user = await db.Users.SingleOrDefaultAsync(user => user.UserName == loginDto.UserName);
            if (user == null)
                return Results.Unauthorized();

            var hasher = new PasswordHasher<User>();
            var result = hasher.VerifyHashedPassword(user, user.PasswordHash, loginDto.Password);

            if (result == PasswordVerificationResult.Failed)
                return Results.Unauthorized();

            var jwtSettings = config.GetSection("Jwt");
            var keyString = jwtSettings["Key"] ?? throw new InvalidOperationException("JWT 'Key' is not configured.");
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(keyString));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var claims = new[]
            {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Role, user.Role)
                    };

            var expireMinutesStr = jwtSettings["ExpireMinutes"] ?? throw new InvalidOperationException("JWT 'ExpireMinutes' is not configured.");
            if (!double.TryParse(expireMinutesStr, out var expireMinutes))
                throw new InvalidOperationException("JWT 'ExpireMinutes' is not a valid number.");

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expireMinutes),
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Results.Ok(new
            {
                user.Id,
                user.UserName,
                user.Role,
                Token = tokenString
            });
        });




        return group;
    }
}

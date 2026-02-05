using AssetTracker.Api.Middlewares;
using AssetTracker.Application.Interfaces.Repositories;
using AssetTracker.Application.Interfaces.Services;
using AssetTracker.Application.Services;
using AssetTracker.Infrastructure.Data;
using AssetTracker.Infrastructure.Repositories;
using AssetTracker.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

    builder.Services.AddAuthentication("Basic")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("Basic", null);

    builder.Services.AddTransient<GlobalExceptionMiddleware>();


    builder.Services.AddAuthorization(options =>
    {
        options.FallbackPolicy = new AuthorizationPolicyBuilder()
            .AddAuthenticationSchemes("Basic")
            .RequireAuthenticatedUser()
            .Build();
    });

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));



    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IUserRepositories, UserRepository>();

    builder.Services.AddScoped<IAuthService, AuthService>();
    builder.Services.AddScoped<IPasswordHasherService, PasswordHasherService>();



    builder.Services.AddScoped<IDepartmentService, DepartmentService>();
    builder.Services.AddScoped<IDepartmentRepositories, DepartmentRepository>();

    builder.Services.AddScoped<IEmployeeService, EmployeeService>();
    builder.Services.AddScoped<IEmployeeRepositories, EmployeeRepository>();

    builder.Services.AddScoped<IAssetService, AssetService>();
    builder.Services.AddScoped<IAssetRepositories, AssetRepository>();

    //builder.Services.AddOpenApi();



    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        //app.MapOpenApi();
        //app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseHttpsRedirection();

    app.UseMiddleware<GlobalExceptionMiddleware>();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    await DbInitializer.SeedAsync(app.Services);


    app.Run();

}catch (System.Reflection.ReflectionTypeLoadException ex)
{
    foreach (var e in ex.LoaderExceptions)
        Console.WriteLine(e?.ToString());
    throw;
}
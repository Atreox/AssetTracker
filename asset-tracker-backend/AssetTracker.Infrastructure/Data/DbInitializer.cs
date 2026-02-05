using AssetTracker.Application.Interfaces.Services;
using AssetTracker.Domain.Entities;
using AssetTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AssetTracker.Infrastructure.Data;

public static class DbInitializer
{
    public static async Task SeedAsync(IServiceProvider services)
    {
        using var scope = services.CreateScope();

        var ctx = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var hasher = scope.ServiceProvider.GetRequiredService<IPasswordHasherService>();

        await ctx.Database.MigrateAsync();

        if (await ctx.Departments.AnyAsync())
            return;

        // -----------------
        // Departments (2)
        // -----------------
        var d1 = new Department { DeptName = "IT", Location = "HQ" };
        var d2 = new Department { DeptName = "HR", Location = "HQ" };

        ctx.Departments.AddRange(d1, d2);
        await ctx.SaveChangesAsync();

        // -----------------
        // Employees (3)
        // -----------------
        var e1 = new Employee
        {
            FullName = "Alice Yılmaz",
            Email = "alice@test.com",
            DepartmentId = d1.Id
        };

        var e2 = new Employee
        {
            FullName = "Bob Demir",
            Email = "bob@test.com",
            DepartmentId = d1.Id
        };

        var e3 = new Employee
        {
            FullName = "Cem Kaya",
            Email = "cem@test.com",
            DepartmentId = d2.Id
        };

        ctx.Employees.AddRange(e1, e2, e3);
        await ctx.SaveChangesAsync();

        // -----------------
        // Assets (4)
        // -----------------
        var a1 = new Asset
        {
            AssetName = "ThinkPad X13",
            SerialNumber = "SN-TP-001",
            AssetType = "Laptop",
            PurchaseDate = DateTime.UtcNow.AddMonths(-6),
            EmployeeId = e1.Id 
        };

        var a2 = new Asset
        {
            AssetName = "Dell Latitude",
            SerialNumber = "SN-DELL-002",
            AssetType = "Laptop",
            PurchaseDate = DateTime.UtcNow.AddMonths(-4),
            EmployeeId = e2.Id 
        };

        var a3 = new Asset
        {
            AssetName = "LG UltraWide",
            SerialNumber = "SN-LG-003",
            AssetType = "Monitor",
            PurchaseDate = DateTime.UtcNow.AddMonths(-2),
            EmployeeId = null 
        };

        var a4 = new Asset
        {
            AssetName = "HP Dock",
            SerialNumber = "SN-HP-004",
            AssetType = "Dock",
            PurchaseDate = DateTime.UtcNow.AddMonths(-1),
            EmployeeId = null 
        };

        ctx.Assets.AddRange(a1, a2, a3, a4);

        // -----------------
        // User (1)
        // -----------------
        var user = new User
        {
            Username = "admin",
            Password = hasher.Hash("123456")
        };

        ctx.Users.Add(user);

        await ctx.SaveChangesAsync();
    }
}

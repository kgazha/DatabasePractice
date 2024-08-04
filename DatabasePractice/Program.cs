// See https://aka.ms/new-console-template for more information

using DatabasePractice;
using DatabasePractice.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

await using var db = new ApplicationDbContext();

var newEmployees = GenerateRandomEmployees(5_000_000);
await db.Employees.AddRangeAsync(newEmployees);
await db.SaveChangesAsync();


List<Employee> GenerateRandomEmployees(int count)
{
    var employees = new List<Employee>();

    var random = new Random();
    var now = DateTime.UtcNow;

    for (int i = 0; i < count; i++)
    {
        var gender = random.Next(0, 2) != 0;

        var name = gender
            ? StaticData.MaleNames[random.Next(0, StaticData.MaleNames.Length)]
            : StaticData.FemaleNames[random.Next(0, StaticData.FemaleNames.Length)];
        var surname = StaticData.Surnames[random.Next(0, StaticData.Surnames.Length)];
        employees.Add(new Employee
        {
            Name = $"{name} {surname}",
            Gender = gender,
            Salary = random.NextInt64(7, 35) * 10_000,
            Age = random.Next(18, 99),
            CreatedAt = now
        });
    }

    return employees;
}
// See https://aka.ms/new-console-template for more information
using EMSPro.Data;
using EMSPro.Models.Model;

Console.WriteLine("Hello, World!");

var factory = new EMSProContextFactory();
using var context = factory.CreateDbContext();

Console.WriteLine("Seeding employee");
var employee = new Employee
{
    Name = "Dheeraj",
    ContactInfo = "9860344637",
    Position = "Sr. Software Engineer",
    Salary = 250000
};
context.Employees.Add(employee);
await context.SaveChangesAsync();
Console.WriteLine("Dheeraj seeded :)");
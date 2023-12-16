using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DB_project.BLL.Entities;
using DB_project.DAL;

namespace DB_project.BLL.Services;

public static class EmployeeService
{
    public static List<Employee> GetEmployees()
    {
        using var context = new ApplicationDbContext();
        return context.Employees.Include(e => e.Teacher).ToList();
    }
    
    public static Employee GetEmployeeByName(string name)
    {
        using var context = new ApplicationDbContext();
        return context.Employees.First(s => s.Name == name);
    }

    public static void CreateEmployee(Employee employee)
    {
        employee.Id = Guid.NewGuid();
        employee.SchoolId = employee.School.Id;
        employee.School = null;
        
        using var context = new ApplicationDbContext();
        using var tr = context.Database.BeginTransaction();
        context.Employees.Add(employee);
        context.SaveChanges();
        tr.Commit();
    }
    
    public static async Task DeleteEmployee(Guid id)
    {
        using (var context = new ApplicationDbContext())
        {
            using (var tr = context.Database.BeginTransaction())
            {
                context.Employees.Remove(context.Employees.First(_ => _.Id == id));
                await context.SaveChangesAsync();
                tr.Commit();
            }
        }
    }
}
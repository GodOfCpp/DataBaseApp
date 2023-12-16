using System.Collections.Generic;
using System.Linq;
using DB_project.BLL.Views;
using DB_project.DAL;

namespace DB_project.BLL.Services;

public class ViewService
{
    public static List<TeacherInfoView> GetTeacherInfo()
    {
        using var context = new ApplicationDbContext();
        return (from e in context.Employees
            join t in context.Teachers on e.Id equals t.EmployeeId
            select new TeacherInfoView
            {
                Name = e.Name,
                PhoneNumber = e.PhoneNumber,
                Salary = e.Salary.ToString(),
                Position = e.Position,
                Email = e.Email,
                Qualification = t.Qualification,
                Seniority = t.Seniority
            }).ToList();
    }
}
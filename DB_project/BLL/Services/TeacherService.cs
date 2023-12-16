using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DB_project.BLL.Entities;
using DB_project.DAL;

namespace DB_project.BLL.Services;

public static class TeacherService
{
    public static List<Teacher> GetTeachers()
    {
        using var context = new ApplicationDbContext();
        return context.Teachers.Include(t => t.Classes).Include(t => t.Employee).ToList();
    }
    
    public static void CreateTeacher(Teacher teacher)
    {
        teacher.Id = Guid.NewGuid();
        teacher.EmployeeId = teacher.Employee.Id;
        teacher.Employee = null;
        
        using var context = new ApplicationDbContext();
        using var tr = context.Database.BeginTransaction();
        context.Teachers.Add(teacher);
        context.SaveChanges();
        tr.Commit();
    }

    public static Teacher GetTeacherByName(string name)
    {
        using var context = new ApplicationDbContext();
        return context.Teachers.Include(t => t.Employee).ToList().First(t => t.Employee.Name == name);
    }
    
    public static async Task DeleteTeacher(Guid id)
    {
        using (var context = new ApplicationDbContext())
        {
            using (var tr = context.Database.BeginTransaction())
            {
                context.Teachers.Remove(context.Teachers.First(_ => _.Id == id));
                await context.SaveChangesAsync();
                tr.Commit();
            }
        }
    }
}
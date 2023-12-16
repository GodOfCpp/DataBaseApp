using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DB_project.BLL.Entities;
using DB_project.DAL;

namespace DB_project.BLL.Services;

public static class StudentService
{
    public static List<Student> GetStudents()
    {
        using var context = new ApplicationDbContext();
        return context.Students.Include(s => s.Class).ToList();
    }
    
    public static void CreateStudent(Student student)
    {
        student.Id = Guid.NewGuid();
        student.ClassId = student.Class.Id;
        student.Class = null;

        using var context = new ApplicationDbContext();
        using var tr = context.Database.BeginTransaction();
        context.Students.Add(student);
        context.SaveChanges();
        tr.Commit();
    }
    
    public static Student GetStudentByName(string name)
    {
        using var context = new ApplicationDbContext();
        return context.Students.First(s => s.Name == name);
    }
    
    public static async Task DeleteStudent(Guid id)
    {
        using (var context = new ApplicationDbContext())
        {
            using (var tr = context.Database.BeginTransaction())
            {
                context.Students.Remove(context.Students.First(_ => _.Id == id));
                await context.SaveChangesAsync();
                tr.Commit();
            }
        }
    }
}
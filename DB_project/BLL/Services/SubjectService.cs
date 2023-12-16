using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DB_project.BLL.Entities;
using DB_project.DAL;

namespace DB_project.BLL.Services;

public static class SubjectService
{
    public static List<Subject> GetSubjects()
    {
        using var context = new ApplicationDbContext();
        return context.Subjects.ToList();
    }
    
    public static void CreateSubject(Subject subject)
    {
        subject.Id = Guid.NewGuid();

        using var context = new ApplicationDbContext();
        using var tr = context.Database.BeginTransaction();
        context.Subjects.Add(subject);
        context.SaveChanges();
        tr.Commit();
    }
    
    public static Subject GetSubjectByName(string name)
    {
        using var context = new ApplicationDbContext();
        return context.Subjects.First(s => s.Name == name);
    }
    
    public static async Task DeleteSubject(Guid id)
    {
        using (var context = new ApplicationDbContext())
        {
            using (var tr = context.Database.BeginTransaction())
            {
                context.Subjects.Remove(context.Subjects.First(_ => _.Id == id));
                await context.SaveChangesAsync();
                tr.Commit();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using DB_project.BLL.Entities;
using DB_project.DAL;

namespace DB_project.BLL.Services;

public static class SchoolService 
{
    public static List<School> GetSchools()
    {
        using var context = new ApplicationDbContext();
        return context.Schools.ToList();
    }
    
    public static async Task CreateSchool(School school)
    {
        using (var context = new ApplicationDbContext())
        {
            using (var tr = context.Database.BeginTransaction())
            {
                school.Id = Guid.NewGuid();

                context.Schools.Add(school);
                await context.SaveChangesAsync();
                tr.Commit();
            }
        }
    }
    
    public static async Task UpdateClass(School school)
    {
        using (var context = new ApplicationDbContext())
        {
            using (var tr = context.Database.BeginTransaction())
            {
                context.Schools.AddOrUpdate(school);
                await context.SaveChangesAsync();
                tr.Commit();
            }
        }
    }

    public static School GetSchoolByName(string name)
    {
        using var context = new ApplicationDbContext();
        return context.Schools.Single(_ => _.Name == name);
    }
    
    public static async Task DeleteSchool(Guid id)
    {
        using (var context = new ApplicationDbContext())
        {
            using (var tr = context.Database.BeginTransaction())
            {
                context.Schools.Remove(context.Schools.First(_ => _.Id == id));
                await context.SaveChangesAsync();
                tr.Commit();
            }
        }
    }
}
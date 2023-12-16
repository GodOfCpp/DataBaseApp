using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using DB_project.BLL.Entities;
using DB_project.BLL.Views;
using DB_project.DAL;

namespace DB_project.BLL.Services;

public static class ClassService
{
    public static List<Class> GetClasses()
    {
        using var context = new ApplicationDbContext();
        return context.Classes.ToList();
    }

    public static Class GetClassByName(string name)
    {
        using var context = new ApplicationDbContext();
        return context.Classes.First(s => name.Contains(s.Letter)/* && name.Contains(s.Number)*/);
    }
    
    public static async Task CreateClass(Class _class)
    {
        using (var context = new ApplicationDbContext())
        {
            using (var tr = context.Database.BeginTransaction())
            {
                _class.Id = Guid.NewGuid();
                _class.ClassTeacherId = _class.ClassTeacher.Id;
                _class.ClassTeacher = null;
                
                context.Classes.Add(_class);
                await context.SaveChangesAsync();
                tr.Commit();
            }
        }
    }
    
    public static async Task UpdateClass(Class _class)
    {
        using (var context = new ApplicationDbContext())
        {
            using (var tr = context.Database.BeginTransaction())
            {
                //

               // context.Classes.Attach(_class);
                context.Classes.AddOrUpdate(_class);
                await context.SaveChangesAsync();
                tr.Commit();
            }
        }
    }

    public static async Task DeleteClass(Guid id)
    {
        using (var context = new ApplicationDbContext())
        {
            using (var tr = context.Database.BeginTransaction())
            {
                context.Classes.Remove(context.Classes.First(_ => _.Id == id));
                await context.SaveChangesAsync();
                tr.Commit();
            }
        }
    }
}
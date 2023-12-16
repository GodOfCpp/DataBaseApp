
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DB_project.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DB_project.DAL.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    } 
}
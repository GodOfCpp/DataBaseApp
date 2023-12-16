namespace DB_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.classes",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        number = c.String(),
                        letter = c.String(),
                        specialization = c.String(),
                        class_teacher_id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "public.teachers",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        seniority = c.String(),
                        qualification = c.String(),
                        Employee = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("public.employees", t => t.id)
                .ForeignKey("public.classes", t => t.id)
                .Index(t => t.id);
            
            CreateTable(
                "public.employees",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        position = c.String(),
                        name = c.String(),
                        school_id = c.Guid(nullable: false),
                        phone_number = c.String(),
                        salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        email = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("public.schools", t => t.school_id, cascadeDelete: true)
                .Index(t => t.school_id);
            
            CreateTable(
                "public.schools",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        name = c.String(),
                        address = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "public.subjects",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        name = c.String(),
                        is_obligatory = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "public.students",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        class_id = c.Guid(nullable: false),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("public.classes", t => t.class_id, cascadeDelete: true)
                .Index(t => t.class_id);
            
            CreateTable(
                "public.teachers_classes",
                c => new
                    {
                        teacher_id = c.Guid(nullable: false),
                        class_id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.teacher_id, t.class_id })
                .ForeignKey("public.teachers", t => t.teacher_id, cascadeDelete: true)
                .ForeignKey("public.classes", t => t.class_id, cascadeDelete: true)
                .Index(t => t.teacher_id)
                .Index(t => t.class_id);
            
            CreateTable(
                "public.students_subjects",
                c => new
                    {
                        student_id = c.Guid(nullable: false),
                        subject_id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.student_id, t.subject_id })
                .ForeignKey("public.students", t => t.student_id, cascadeDelete: true)
                .ForeignKey("public.subjects", t => t.subject_id, cascadeDelete: true)
                .Index(t => t.student_id)
                .Index(t => t.subject_id);
            
            CreateTable(
                "public.teachers_subjects",
                c => new
                    {
                        teacher_id = c.Guid(nullable: false),
                        subject_id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.teacher_id, t.subject_id })
                .ForeignKey("public.teachers", t => t.teacher_id, cascadeDelete: true)
                .ForeignKey("public.subjects", t => t.subject_id, cascadeDelete: true)
                .Index(t => t.teacher_id)
                .Index(t => t.subject_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("public.students", "class_id", "public.classes");
            DropForeignKey("public.teachers", "id", "public.classes");
            DropForeignKey("public.teachers_subjects", "subject_id", "public.subjects");
            DropForeignKey("public.teachers_subjects", "teacher_id", "public.teachers");
            DropForeignKey("public.students_subjects", "subject_id", "public.subjects");
            DropForeignKey("public.students_subjects", "student_id", "public.students");
            DropForeignKey("public.teachers", "id", "public.employees");
            DropForeignKey("public.employees", "school_id", "public.schools");
            DropForeignKey("public.teachers_classes", "class_id", "public.classes");
            DropForeignKey("public.teachers_classes", "teacher_id", "public.teachers");
            DropIndex("public.teachers_subjects", new[] { "subject_id" });
            DropIndex("public.teachers_subjects", new[] { "teacher_id" });
            DropIndex("public.students_subjects", new[] { "subject_id" });
            DropIndex("public.students_subjects", new[] { "student_id" });
            DropIndex("public.teachers_classes", new[] { "class_id" });
            DropIndex("public.teachers_classes", new[] { "teacher_id" });
            DropIndex("public.students", new[] { "class_id" });
            DropIndex("public.employees", new[] { "school_id" });
            DropIndex("public.teachers", new[] { "id" });
            DropTable("public.teachers_subjects");
            DropTable("public.students_subjects");
            DropTable("public.teachers_classes");
            DropTable("public.students");
            DropTable("public.subjects");
            DropTable("public.schools");
            DropTable("public.employees");
            DropTable("public.teachers");
            DropTable("public.classes");
        }
    }
}

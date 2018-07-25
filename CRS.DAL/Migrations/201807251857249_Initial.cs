namespace CRS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseCode = c.String(),
                        CourseName = c.String(),
                        CourseCredits = c.Double(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        ProgramId = c.Int(nullable: false, identity: true),
                        ProgramName = c.String(),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProgramId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.ProgramCourseAssociations",
                c => new
                    {
                        ProgramCourseAssociationId = c.Int(nullable: false, identity: true),
                        ProgramId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProgramCourseAssociationId)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .ForeignKey("dbo.Programs", t => t.ProgramId)
                .Index(t => t.ProgramId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        CGPA = c.Double(nullable: false),
                        ProgramId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Programs", t => t.ProgramId, cascadeDelete: true)
                .Index(t => t.ProgramId);
            
            CreateTable(
                "dbo.StudentCourseAssociations",
                c => new
                    {
                        StudentCourseAssociationId = c.Int(nullable: false, identity: true),
                        Marks = c.Double(nullable: false),
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentCourseAssociationId)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Prerequisites",
                c => new
                    {
                        PrerequisiteId = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        CoursePrerequisiteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PrerequisiteId)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .ForeignKey("dbo.Courses", t => t.CoursePrerequisiteId)
                .Index(t => t.CourseId)
                .Index(t => t.CoursePrerequisiteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prerequisites", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Prerequisites", "CoursePrerequisiteId", "dbo.Courses");
            DropForeignKey("dbo.Prerequisites", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.StudentCourseAssociations", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentCourseAssociations", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Students", "ProgramId", "dbo.Programs");
            DropForeignKey("dbo.ProgramCourseAssociations", "ProgramId", "dbo.Programs");
            DropForeignKey("dbo.ProgramCourseAssociations", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Programs", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Prerequisites", new[] { "Course_Id" });
            DropIndex("dbo.Prerequisites", new[] { "CoursePrerequisiteId" });
            DropIndex("dbo.Prerequisites", new[] { "CourseId" });
            DropIndex("dbo.StudentCourseAssociations", new[] { "CourseId" });
            DropIndex("dbo.StudentCourseAssociations", new[] { "StudentId" });
            DropIndex("dbo.Students", new[] { "ProgramId" });
            DropIndex("dbo.ProgramCourseAssociations", new[] { "CourseId" });
            DropIndex("dbo.ProgramCourseAssociations", new[] { "ProgramId" });
            DropIndex("dbo.Programs", new[] { "DepartmentId" });
            DropIndex("dbo.Courses", new[] { "DepartmentId" });
            DropTable("dbo.Prerequisites");
            DropTable("dbo.StudentCourseAssociations");
            DropTable("dbo.Students");
            DropTable("dbo.ProgramCourseAssociations");
            DropTable("dbo.Programs");
            DropTable("dbo.Departments");
            DropTable("dbo.Courses");
            DropTable("dbo.Admins");
        }
    }
}

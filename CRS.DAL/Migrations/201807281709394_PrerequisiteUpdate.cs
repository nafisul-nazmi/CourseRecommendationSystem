namespace CRS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrerequisiteUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Prerequisites", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Prerequisites", "CoursePrerequisiteId", "dbo.Courses");
            DropIndex("dbo.Prerequisites", new[] { "CourseId" });
            DropIndex("dbo.Prerequisites", new[] { "CoursePrerequisiteId" });
            DropIndex("dbo.Prerequisites", new[] { "Course_Id" });
            AddColumn("dbo.Courses", "Course_Id", c => c.Int());
            CreateIndex("dbo.Courses", "Course_Id");
            DropTable("dbo.Prerequisites");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Prerequisites",
                c => new
                    {
                        PrerequisiteId = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        CoursePrerequisiteId = c.Int(nullable: false),
                        Course_Id = c.Int(),
                    })
                .PrimaryKey(t => t.PrerequisiteId);
            
            DropIndex("dbo.Courses", new[] { "Course_Id" });
            DropColumn("dbo.Courses", "Course_Id");
            CreateIndex("dbo.Prerequisites", "Course_Id");
            CreateIndex("dbo.Prerequisites", "CoursePrerequisiteId");
            CreateIndex("dbo.Prerequisites", "CourseId");
            AddForeignKey("dbo.Prerequisites", "CoursePrerequisiteId", "dbo.Courses", "CourseId", cascadeDelete: true);
            AddForeignKey("dbo.Prerequisites", "CourseId", "dbo.Courses", "CourseId", cascadeDelete: true);
        }
    }
}

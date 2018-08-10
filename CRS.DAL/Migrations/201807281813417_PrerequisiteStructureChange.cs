namespace CRS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrerequisiteStructureChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "UnlocksId", "dbo.Courses");
            DropIndex("dbo.Courses", new[] { "UnlocksId" });
            CreateTable(
                "dbo.Prerequisites",
                c => new
                    {
                        PrerequisiteId = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(),
                        CoursePrerequisiteId = c.Int(),
                    })
                .PrimaryKey(t => t.PrerequisiteId)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .ForeignKey("dbo.Courses", t => t.CoursePrerequisiteId)
                .Index(t => t.CourseId)
                .Index(t => t.CoursePrerequisiteId);
            
            DropColumn("dbo.Courses", "UnlocksId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "UnlocksId", c => c.Int());
            DropForeignKey("dbo.Prerequisites", "CoursePrerequisiteId", "dbo.Courses");
            DropForeignKey("dbo.Prerequisites", "CourseId", "dbo.Courses");
            DropIndex("dbo.Prerequisites", new[] { "CoursePrerequisiteId" });
            DropIndex("dbo.Prerequisites", new[] { "CourseId" });
            DropTable("dbo.Prerequisites");
            CreateIndex("dbo.Courses", "UnlocksId");
            AddForeignKey("dbo.Courses", "UnlocksId", "dbo.Courses", "CourseId");
        }
    }
}

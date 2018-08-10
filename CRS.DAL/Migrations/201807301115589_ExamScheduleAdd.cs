namespace CRS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExamScheduleAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExamSchedules",
                c => new
                    {
                        ExamScheduleId = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        Day = c.Int(nullable: false),
                        Slot = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExamScheduleId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExamSchedules", "CourseId", "dbo.Courses");
            DropIndex("dbo.ExamSchedules", new[] { "CourseId" });
            DropTable("dbo.ExamSchedules");
        }
    }
}

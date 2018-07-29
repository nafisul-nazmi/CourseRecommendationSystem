namespace CRS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CoursePrereqFieldUpdate : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Courses", name: "Course_Id", newName: "UnlocksId");
            RenameIndex(table: "dbo.Courses", name: "IX_Course_Id", newName: "IX_UnlocksId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Courses", name: "IX_UnlocksId", newName: "IX_Course_Id");
            RenameColumn(table: "dbo.Courses", name: "UnlocksId", newName: "Course_Id");
        }
    }
}

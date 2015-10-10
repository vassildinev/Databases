namespace StudentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HomeworksAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Homework",
                c => new
                    {
                        HomeworkId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        DateSent = c.DateTime(nullable: false),
                        Course_Name = c.String(maxLength: 128),
                        Student_StudentId = c.Int(),
                    })
                .PrimaryKey(t => t.HomeworkId)
                .ForeignKey("dbo.Courses", t => t.Course_Name)
                .ForeignKey("dbo.Students", t => t.Student_StudentId)
                .Index(t => t.Course_Name)
                .Index(t => t.Student_StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Homework", "Student_StudentId", "dbo.Students");
            DropForeignKey("dbo.Homework", "Course_Name", "dbo.Courses");
            DropIndex("dbo.Homework", new[] { "Student_StudentId" });
            DropIndex("dbo.Homework", new[] { "Course_Name" });
            DropTable("dbo.Homework");
        }
    }
}

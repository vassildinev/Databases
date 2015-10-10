namespace StudentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                        Materials = c.String(),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Number = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        Student_StudentId = c.Int(nullable: false),
                        Course_Name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Student_StudentId, t.Course_Name })
                .ForeignKey("dbo.Students", t => t.Student_StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_Name, cascadeDelete: true)
                .Index(t => t.Student_StudentId)
                .Index(t => t.Course_Name);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentCourses", "Course_Name", "dbo.Courses");
            DropForeignKey("dbo.StudentCourses", "Student_StudentId", "dbo.Students");
            DropIndex("dbo.StudentCourses", new[] { "Course_Name" });
            DropIndex("dbo.StudentCourses", new[] { "Student_StudentId" });
            DropTable("dbo.StudentCourses");
            DropTable("dbo.Students");
            DropTable("dbo.Courses");
        }
    }
}

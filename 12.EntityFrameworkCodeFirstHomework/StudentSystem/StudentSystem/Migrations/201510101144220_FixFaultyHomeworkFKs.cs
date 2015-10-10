namespace StudentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixFaultyHomeworkFKs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Homework", "Student_StudentId", "dbo.Students");
            DropIndex("dbo.Homework", new[] { "Student_StudentId" });
            RenameColumn(table: "dbo.Homework", name: "Student_StudentId", newName: "StudentId");
            AddColumn("dbo.Homework", "CourseId", c => c.String());
            AlterColumn("dbo.Homework", "StudentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Homework", "StudentId");
            AddForeignKey("dbo.Homework", "StudentId", "dbo.Students", "StudentId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Homework", "StudentId", "dbo.Students");
            DropIndex("dbo.Homework", new[] { "StudentId" });
            AlterColumn("dbo.Homework", "StudentId", c => c.Int());
            DropColumn("dbo.Homework", "CourseId");
            RenameColumn(table: "dbo.Homework", name: "StudentId", newName: "Student_StudentId");
            CreateIndex("dbo.Homework", "Student_StudentId");
            AddForeignKey("dbo.Homework", "Student_StudentId", "dbo.Students", "StudentId");
        }
    }
}

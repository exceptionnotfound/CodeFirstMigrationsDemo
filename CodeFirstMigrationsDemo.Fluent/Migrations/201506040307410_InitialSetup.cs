namespace CodeFirstMigrationsDemo.Fluent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        TeacherID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Teachers", t => t.TeacherID, cascadeDelete: true)
                .Index(t => t.TeacherID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.StudentAddresses",
                c => new
                    {
                        StudentID = c.Int(nullable: false),
                        StreetAddress = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        PostalCode = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StudentID)
                .ForeignKey("dbo.Students", t => t.StudentID)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        StudentID = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentID, t.CourseID })
                .ForeignKey("dbo.Courses", t => t.StudentID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.CourseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "TeacherID", "dbo.Teachers");
            DropForeignKey("dbo.StudentCourses", "CourseID", "dbo.Students");
            DropForeignKey("dbo.StudentCourses", "StudentID", "dbo.Courses");
            DropForeignKey("dbo.StudentAddresses", "StudentID", "dbo.Students");
            DropIndex("dbo.StudentCourses", new[] { "CourseID" });
            DropIndex("dbo.StudentCourses", new[] { "StudentID" });
            DropIndex("dbo.StudentAddresses", new[] { "StudentID" });
            DropIndex("dbo.Courses", new[] { "TeacherID" });
            DropTable("dbo.StudentCourses");
            DropTable("dbo.Teachers");
            DropTable("dbo.StudentAddresses");
            DropTable("dbo.Students");
            DropTable("dbo.Courses");
        }
    }
}

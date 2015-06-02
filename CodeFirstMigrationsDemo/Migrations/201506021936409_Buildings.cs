namespace CodeFirstMigrationsDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Buildings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buildings",
                c => new
                    {
                        BuildingID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BuildingID);
            
            AddColumn("dbo.Courses", "BuildingID", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "BuildingID");
            AddForeignKey("dbo.Courses", "BuildingID", "dbo.Buildings", "BuildingID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "BuildingID", "dbo.Buildings");
            DropIndex("dbo.Courses", new[] { "BuildingID" });
            DropColumn("dbo.Courses", "BuildingID");
            DropTable("dbo.Buildings");
        }
    }
}

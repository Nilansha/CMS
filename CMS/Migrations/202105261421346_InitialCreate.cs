namespace CMS.Migrations
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
                        Course_Id = c.Int(nullable: false, identity: true),
                        Course_Name = c.String(),
                        Course_Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Course_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Courses");
        }
    }
}

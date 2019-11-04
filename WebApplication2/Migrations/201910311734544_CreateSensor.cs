namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateSensor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sensors",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        temperature = c.Single(nullable: false),
                        humid = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sensors");
        }
    }
}

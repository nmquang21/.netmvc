namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateSensor1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sensors", "createAt", c => c.Long(nullable: false));
            AddColumn("dbo.Sensors", "updatedAt", c => c.Long(nullable: false));
            AddColumn("dbo.Sensors", "deletedAt", c => c.Long(nullable: false));
            AddColumn("dbo.Sensors", "status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sensors", "status");
            DropColumn("dbo.Sensors", "deletedAt");
            DropColumn("dbo.Sensors", "updatedAt");
            DropColumn("dbo.Sensors", "createAt");
        }
    }
}

namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMemberTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "createAt", c => c.Long(nullable: false));
            AddColumn("dbo.Members", "updatedAt", c => c.Long(nullable: false));
            AddColumn("dbo.Members", "deletedAt", c => c.Long(nullable: false));
            AddColumn("dbo.Members", "status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "status");
            DropColumn("dbo.Members", "deletedAt");
            DropColumn("dbo.Members", "updatedAt");
            DropColumn("dbo.Members", "createAt");
        }
    }
}

namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        name = c.String(unicode: false),
                        description = c.String(unicode: false),
                        singer = c.String(unicode: false),
                        author = c.String(unicode: false),
                        thumbnail = c.String(unicode: false),
                        link = c.String(unicode: false),
                        createAt = c.Long(nullable: false),
                        updatedAt = c.Long(nullable: false),
                        deletedAt = c.Long(nullable: false),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Songs");
        }
    }
}

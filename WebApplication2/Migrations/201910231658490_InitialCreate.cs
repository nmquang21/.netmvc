namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        firstName = c.String(unicode: false),
                        lastName = c.String(unicode: false),
                        avatar = c.String(unicode: false),
                        phone = c.String(unicode: false),
                        address = c.String(unicode: false),
                        introduction = c.String(unicode: false),
                        gender = c.String(unicode: false),
                        birthday = c.String(unicode: false),
                        email = c.String(unicode: false),
                        password = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Members");
        }
    }
}

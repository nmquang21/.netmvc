namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        FullName = c.String(unicode: true),
                        Email = c.String(nullable: false, unicode: false),
                        Phone = c.String(unicode: true),
                        Password = c.String(maxLength: 9, storeType: "nvarchar"),
                        ConfirmPassword = c.String(maxLength: 9, storeType: "nvarchar"),
                        Age = c.String(unicode: true),
                    })
                .PrimaryKey(t => t.id);
            
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
                        createAt = c.Long(nullable: false),
                        updatedAt = c.Long(nullable: false),
                        deletedAt = c.Long(nullable: false),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Sensors",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        temperature = c.Single(nullable: false),
                        humid = c.Single(nullable: false),
                        createAt = c.Long(nullable: false),
                        updatedAt = c.Long(nullable: false),
                        deletedAt = c.Long(nullable: false),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
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
            DropTable("dbo.Sensors");
            DropTable("dbo.Members");
            DropTable("dbo.Customers");
        }
    }
}

namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ACs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Temperature = c.Int(nullable: false),
                        AirFlow = c.Int(nullable: false),
                        Name = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EHeaters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EShutters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        level = c.Int(nullable: false),
                        Name = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Fridges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Temperature = c.Int(nullable: false),
                        Name = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lamps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        DeviceId = c.Int(nullable: false, identity: true),
                        DeviceName = c.String(),
                        Date = c.DateTime(nullable: false),
                        Action = c.String(),
                    })
                .PrimaryKey(t => t.DeviceId);
            
            CreateTable(
                "dbo.TVs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Volume = c.Int(nullable: false),
                        Channel = c.Int(nullable: false),
                        Name = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TVs");
            DropTable("dbo.Logs");
            DropTable("dbo.Lamps");
            DropTable("dbo.Fridges");
            DropTable("dbo.EShutters");
            DropTable("dbo.EHeaters");
            DropTable("dbo.ACs");
        }
    }
}

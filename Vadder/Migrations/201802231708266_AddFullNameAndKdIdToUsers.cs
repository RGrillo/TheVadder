namespace Vadder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFullNameAndKdIdToUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "kuFirstName", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.AspNetUsers", "kuLastName", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.AspNetUsers", "KdId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "KdId");
            DropColumn("dbo.AspNetUsers", "kuLastName");
            DropColumn("dbo.AspNetUsers", "kuFirstName");
        }
    }
}

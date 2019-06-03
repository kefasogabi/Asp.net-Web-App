namespace WebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addremoveToCustomer : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "ReleaseDate");
            DropColumn("dbo.Movies", "DateAdded");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}

namespace WebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes(Id, Name, SignUpFee, DiscountRate, DurationInMonths ) VALUES(1, 'Pay As You Go', 0, 0, 0)");
            Sql("INSERT INTO MembershipTypes(Id, Name, SignUpFee, DiscountRate, DurationInMonths ) VALUES(2, 'Monthly', 30, 10, 1)");
            Sql("INSERT INTO MembershipTypes(Id, Name, SignUpFee, DiscountRate, DurationInMonths ) VALUES(3, 'quaterlly', 90, 15, 3)");
            Sql("INSERT INTO MembershipTypes(Id, Name, SignUpFee, DiscountRate, DurationInMonths ) VALUES(4, 'Annual', 300, 20, 12)");

            Sql("INSERT INTO Genres(Id, Name) VALUES(1, 'Family')");
            Sql("INSERT INTO Genres(Id, Name) VALUES(2, 'Action')");
            Sql("INSERT INTO Genres(Id, Name) VALUES(3, 'Comedy')");
            Sql("INSERT INTO Genres(Id, Name) VALUES(4, 'Romance')");
        }
        
        public override void Down()
        {
        }
    }
}

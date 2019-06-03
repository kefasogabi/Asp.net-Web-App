namespace WebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0cd62794-5c87-4711-a005-ac7d717dec9f', N'Admin@gmail.com', 0, N'APlO0ao0xskRcp9veu3FCSBa1y5nmHHGbyPMH6QQYmPMd/MGQoxrb3HcWDhGOl6qWQ==', N'76de1d67-a31d-4b98-9f26-98635dddca05', NULL, 0, 0, NULL, 1, 0, N'Admin@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'202e89f7-ec01-4114-b2f4-800f8ebf030a', N'guest@gmail.com', 0, N'AKCxrX6JkYP7W1tvIOlE82EDlAb67yyzgwcfTU4OFVrwFbizGoQrt1hk/bG9rrr9JQ==', N'd8b8e047-f4eb-4cc5-8874-e0e0be21eb00', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd41606ad-464b-41db-a179-721094867548', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0cd62794-5c87-4711-a005-ac7d717dec9f', N'd41606ad-464b-41db-a179-721094867548')



");
        }
        
        public override void Down()
        {
        }
    }
}

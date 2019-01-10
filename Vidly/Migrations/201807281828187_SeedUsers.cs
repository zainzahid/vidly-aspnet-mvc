namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7985a5ff-b067-4817-b8df-7c712c3a4275', N'user1@vidly.com', 0, N'ADYhC5afY4J5DkOL3IYKw24nUHdv3t1wg08Xp0U+TLzwPW5dnii/YLoFZ7MhJeRigQ==', N'4d560996-807d-4408-a4dc-e9cccc52cc91', NULL, 0, 0, NULL, 1, 0, N'user1@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8adff695-aaf0-4dbf-8efc-5e05a96fc885', N'admin@vidly.com', 0, N'AI7a+O/1rs08d/+BhIPsqkLjMU3QTqpR7ack6jJxKA8mt4DeR4QTZ7N93JkDMOxjSw==', N'11a2d6bc-6b4c-4cec-8dbe-7282fab5c9dc', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'90f1daf8-6889-4d5f-b723-21278ed64d46', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8adff695-aaf0-4dbf-8efc-5e05a96fc885', N'90f1daf8-6889-4d5f-b723-21278ed64d46')
        ");
        }
        
        public override void Down()
        {
        }
    }
}

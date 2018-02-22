namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3cda6e51-3930-4da3-85f2-8b733fbc1506', N'Admin@vidly.com', 0, N'ACvuSXtDdIW2VTYcPDSKJQG+fCAof/sUys4+evHveRipLw5b2e0p/QHqgLdSK8jFFw==', N'3046709c-3a46-4ad1-8e00-198a13941063', NULL, 0, 0, NULL, 1, 0, N'Admin@vidly.com')

INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'fc8151c2-c558-460e-a3e1-56db42cd692a', N'emeksense@gmail.com', 0, N'AKisW9VLQxXb4v2BhFFHbyg/PeuVXHCNnLB03P4Xf8ngmecfb5sX0CHvHEyXPGbBGw==', N'1844c3cb-1be7-4e35-ae75-f66d6e77a02a', NULL, 0, 0, NULL, 1, 0, N'emeksense@gmail.com')

INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7fa37a8c-48df-496f-99ab-9073d7783740', N'CanManageMovies')

INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3cda6e51-3930-4da3-85f2-8b733fbc1506', N'7fa37a8c-48df-496f-99ab-9073d7783740')


");
        }

        public override void Down()
        {
        }
    }
}

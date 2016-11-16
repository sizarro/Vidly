namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3a725978-2440-456d-8af8-8059cb1b7ffb', N'admin@vidly.com', 0, N'AIi+luFFADs2dbD2NiuQYFf50NoV1FkEHvfX+mEzenOZpmI+WuJMI10e13HQudTN8Q==', N'95caf345-f252-498d-a7a2-b1caab320483', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7b3c705d-399a-455c-bb1a-e99879b23f9d', N'guest@vidly.com', 0, N'AJtQmsI2MUDqlsZ43XypbcnsqoacifE3l3gGa8yc5M/xpUuSrXrP2nWtWVxnEvH7mg==', N'305f64eb-bd39-4d74-a7bf-5df09cd9ef7a', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'186084fc-f050-4fc9-906d-310484cc9338', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3a725978-2440-456d-8af8-8059cb1b7ffb', N'186084fc-f050-4fc9-906d-310484cc9338')
");
        }
        
        public override void Down()
        {
        }
    }
}

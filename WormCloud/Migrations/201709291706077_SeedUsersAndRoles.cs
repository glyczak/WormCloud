namespace WormCloud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsersAndRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Name]) VALUES (N'3c0740ea-abb8-47c3-809f-f16187be6b5e', N'gaba@gaba.space', 0, N'ALxg+V9fjot/6h2Jau+UF0dghX0+GGIhZJBFaW/MTYvsiRD6cSUb/a1m8yIgvV/kDA==', N'57aecef1-c0a4-463b-bf91-66842f793a24', NULL, 0, 0, NULL, 1, 0, N'gaba@gaba.space', N'Administrator')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'efa35cb6-5884-484c-b1e6-8ee363d90105', N'CanManageSamples')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'375ff12d-ff1d-42dd-bad9-dc576fe7f3ce', N'CanManageStrains')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3c0740ea-abb8-47c3-809f-f16187be6b5e', N'375ff12d-ff1d-42dd-bad9-dc576fe7f3ce')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3c0740ea-abb8-47c3-809f-f16187be6b5e', N'efa35cb6-5884-484c-b1e6-8ee363d90105')
");
        }
        
        public override void Down()
        {
        }
    }
}

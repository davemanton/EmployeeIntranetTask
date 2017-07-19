/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

USE [KpmgSecurity]
GO
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'1', NULL, N'employee', N'EMPLOYEE')
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'2', NULL, N'publisher', N'PUBLISHER')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'9cb7c0a7-258c-4d2f-98b4-d56bf65da649', 0, N'e198e3ef-22bd-4b98-bdd7-808dda9875f5', N'morgan.freeman@test.com', 0, 1, NULL, N'MORGAN.FREEMAN@TEST.COM', N'MORGAN.FREEMAN@TEST.COM', N'AQAAAAEAACcQAAAAEHVJxiXpetIy/vfNGARDkpC1Pl7aKd30aZT1Hm4Gy7Bi/Dxn90rlt/movJBWjIqH7A==', NULL, 0, N'caa95fa4-7cf3-4a9b-a790-d9d264a9e139', 0, N'morgan.freeman@test.com')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'b3454102-bee1-4925-8938-b93fbbd04a59', 0, N'a75abffb-9cd2-4c49-a569-7aed584452d3', N'dave@mrmanton.com', 0, 1, NULL, N'DAVE@MRMANTON.COM', N'DAVE@MRMANTON.COM', N'AQAAAAEAACcQAAAAEGd293WAdOLmAv0WTnHBdadq/STL73ZddU4wI8UuM1RQZS9bDjIv2n73llpSKBmRFw==', NULL, 0, N'c715ac8c-1678-4a31-8dd9-b358788fe8a8', 0, N'dave@mrmanton.com')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'f1f517d5-b12c-4d18-8012-b232a310abdb', 0, N'ef328e7d-ac9d-4422-9dfa-11ff607b2c82', N'user1@test.com', 0, 1, NULL, N'USER1@TEST.COM', N'USER1@TEST.COM', N'AQAAAAEAACcQAAAAENAIUSsS9HrZfZQEZtTfhE/M0yVzHmVma1N3BMZ74hr5wfQCX6P2Ui5QI/rF8dcz4g==', NULL, 0, N'67d7f9c4-d427-4b09-8373-e20df346eac9', 0, N'user1@test.com')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9cb7c0a7-258c-4d2f-98b4-d56bf65da649', N'1')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9cb7c0a7-258c-4d2f-98b4-d56bf65da649', N'2')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b3454102-bee1-4925-8938-b93fbbd04a59', N'1')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b3454102-bee1-4925-8938-b93fbbd04a59', N'2')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f1f517d5-b12c-4d18-8012-b232a310abdb', N'1')


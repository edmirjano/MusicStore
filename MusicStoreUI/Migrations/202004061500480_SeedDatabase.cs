
namespace MusicStoreUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedDatabase : DbMigration
    {
        public override void Up()
        {
            //creating admin user
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'71c46050-d162-46f1-81a2-9ead8e64035a', N'admin@admin.com', 0, N'AFQxxleAf+F53truc6x0Usn+eknY7PGA9NrYASlYXCZLEfsDsm61iT6ALx7ErUfbSQ==', N'4185a52f-432d-44cb-8c67-c4a19a28b918', NULL, 0, 0, NULL, 1, 0, N'admin@admin.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'cb09730c-81e8-4f60-b38c-63b9e4333141', N'admin@gmail.com', 0, N'AOkv+i7wl7Zv0axrncm7YyE/5qitLWrzeit7mSpKDwCL6xEiQytjrY6jbh5JcRM1zQ==', N'4d875929-d58d-4473-9386-c6637fd29dbe', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')


                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'8c1cd01f-ed3c-49bb-a4b4-359dd8210545', N'Admin')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'71c46050-d162-46f1-81a2-9ead8e64035a', N'8c1cd01f-ed3c-49bb-a4b4-359dd8210545')

            ");
            //creating authors
            Sql("set identity_insert Authors on;");
            Sql("Insert into Authors(AuthorId, Name, Age) values (1,'Mc Kresha',22) set identity_insert Authors on;");
            Sql("Insert into Authors(AuthorId, Name, Age) values (2,'Jovanotti', 33) set identity_insert Authors on;");
            Sql("Insert into Authors(AuthorId, Name, Age) values (3,'Al Bano', 44) set identity_insert Authors on;");
            Sql("Insert into Authors(AuthorId, Name, Age) values (4,'Adriano Celentano', 13) set identity_insert Authors on;");
            Sql("Insert into Authors(AuthorId, Name, Age) values (5,'Alban Skenderaj', 53) set identity_insert Authors off;");

            //creating categories
            Sql("set identity_insert Categories on;");
            Sql("Insert into Categories(CategorId,Name,Description) values (1, 'Hip Hop', 'Lorem Ipsum') set identity_insert Categories on;");
            Sql("Insert into Categories(CategorId,Name,Description) values (2, 'Country', 'Lorem Ipsum') set identity_insert Categories on;");
            Sql("Insert into Categories(CategorId,Name,Description) values (3, 'Pop', 'Lorem Ipsum') set identity_insert Categories on;");
            Sql("Insert into Categories(CategorId,Name,Description) values (4, 'Rock', 'Lorem Ipsum') set identity_insert Categories on;");
            Sql("Insert into Categories(CategorId,Name,Description) values (5, 'Folk', 'Lorem Ipsum') set identity_insert Categories off;");
            //creating albums
            Sql("set identity_insert Albums off;");
            Sql("Insert into Albums(Name,AuthorId,Year,Price,NrOfSongs,ImagePath,CategoryId,OnSale) values ('Enciklopedi', 1,2019,2200,20,'~/Content/Images/1.jpg',1,1) set identity_insert Albums off;");
            Sql("Insert into Albums(Name,AuthorId,Year,Price,NrOfSongs,ImagePath,CategoryId,OnSale) values ('Triste Domenica', 2,1960,3856,1,'~/Content/Images/2.jpg',2,0)  set identity_insert Albums off;");
            Sql("Insert into Albums(Name,AuthorId,Year,Price,NrOfSongs,ImagePath,CategoryId,OnSale) values ('Back In Black', 3,1990,1323,23,'~/Content/Images/3.jpg',3,0)  set identity_insert Albums off;");
            Sql("Insert into Albums(Name,AuthorId,Year,Price,NrOfSongs,ImagePath,CategoryId,OnSale) values ('Reputation',4,2020,4734,27,'~/Content/Images/4.jpg',3,0)  set identity_insert Albums off;");
            Sql("Insert into Albums(Name,AuthorId,Year,Price,NrOfSongs,ImagePath,CategoryId,OnSale) values ('Deluxe', 3,2020,3456,24,'~/Content/Images/5.jpg',2,1)  set identity_insert Albums off;");
            Sql("Insert into Albums(Name,AuthorId,Year,Price,NrOfSongs,ImagePath,CategoryId,OnSale) values ('Chiaro Di Luna',2,2000,1112,15,'~/Content/Images/6.jpg',1,1)  set identity_insert Albums off;");
            Sql("Insert into Albums(Name,AuthorId,Year,Price,NrOfSongs,ImagePath,CategoryId,OnSale) values ('Sinatra', 1,2019,7823,15,'~/Content/Images/7.jpg',4,0) set identity_insert Albums off;");
            Sql("Insert into Albums(Name,AuthorId,Year,Price,NrOfSongs,ImagePath,CategoryId,OnSale) values ('You Want It Darker', 2,1980,936,5,'~/Content/Images/8.jpg',1,0)  set identity_insert Albums off;");

        }

        public override void Down()
        {
        }
    }
}

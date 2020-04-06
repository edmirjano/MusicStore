namespace MusicStoreUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                {
                    AlbumId = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    Year = c.Int(nullable: false),
                    Price = c.Int(nullable: false),
                    NrOfSongs = c.Int(),
                    ImagePath = c.String(),
                    OnSale = c.Boolean(),
                    AuthorId = c.Int(nullable: false),
                    CategoryId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.AlbumId)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.CategoryId);

            CreateTable(
                "dbo.Authors",
                c => new
                {
                    AuthorId = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    Age = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.AuthorId);

            CreateTable(
                "dbo.Categories",
                c => new
                {
                    CategorId = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    Description = c.String(),
                })
                .PrimaryKey(t => t.CategorId);

            CreateTable(
                "dbo.OrderAlbums",
                c => new
                {
                    OrderAlbumId = c.Int(nullable: false, identity: true),
                    AlbumId = c.Int(nullable: false),
                    OrderId = c.Int(nullable: false),
                    Quantity = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.OrderAlbumId)
                .ForeignKey("dbo.Albums", t => t.AlbumId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.AlbumId)
                .Index(t => t.OrderId);

            CreateTable(
                "dbo.Orders",
                c => new
                {
                    OrderId = c.Int(nullable: false, identity: true),
                    TotalAmaunt = c.Int(nullable: false),
                    ShippingId = c.Int(nullable: false),
                    HasACoupon = c.Boolean(),
                    Completed = c.Boolean(),
                })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.ShippingDetails", t => t.ShippingId, cascadeDelete: true)
                .Index(t => t.ShippingId);

            CreateTable(
                "dbo.ShippingDetails",
                c => new
                {
                    ShippingId = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    Adress = c.String(nullable: false),
                    Email = c.String(nullable: false),
                    Tel = c.String(nullable: false, maxLength: 12),
                    CouponCode = c.String(),
                })
                .PrimaryKey(t => t.ShippingId);

            CreateTable(
                "dbo.AspNetRoles",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Name = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");

            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                {
                    UserId = c.String(nullable: false, maxLength: 128),
                    RoleId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

            CreateTable(
                "dbo.AspNetUsers",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Email = c.String(maxLength: 256),
                    EmailConfirmed = c.Boolean(nullable: false),
                    PasswordHash = c.String(),
                    SecurityStamp = c.String(),
                    PhoneNumber = c.String(),
                    PhoneNumberConfirmed = c.Boolean(nullable: false),
                    TwoFactorEnabled = c.Boolean(nullable: false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(nullable: false),
                    AccessFailedCount = c.Int(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");

            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.String(nullable: false, maxLength: 128),
                    ClaimType = c.String(),
                    ClaimValue = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                {
                    LoginProvider = c.String(nullable: false, maxLength: 128),
                    ProviderKey = c.String(nullable: false, maxLength: 128),
                    UserId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.OrderAlbums", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "ShippingId", "dbo.ShippingDetails");
            DropForeignKey("dbo.OrderAlbums", "AlbumId", "dbo.Albums");
            DropForeignKey("dbo.Albums", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Albums", "AuthorId", "dbo.Authors");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Orders", new[] { "ShippingId" });
            DropIndex("dbo.OrderAlbums", new[] { "OrderId" });
            DropIndex("dbo.OrderAlbums", new[] { "AlbumId" });
            DropIndex("dbo.Albums", new[] { "CategoryId" });
            DropIndex("dbo.Albums", new[] { "AuthorId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ShippingDetails");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderAlbums");
            DropTable("dbo.Categories");
            DropTable("dbo.Authors");
            DropTable("dbo.Albums");
        }
    }
}

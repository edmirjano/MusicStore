namespace MusicStoreUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class nullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Albums", "OnSale", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Orders", "HasACoupon", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Orders", "Completed", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            AlterColumn("dbo.Orders", "Completed", c => c.Boolean());
            AlterColumn("dbo.Orders", "HasACoupon", c => c.Boolean());
            AlterColumn("dbo.Albums", "OnSale", c => c.Boolean());
        }
    }
}

namespace MovieApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedPropsFromMovie : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "YearReleased");
            DropColumn("dbo.Movies", "Tagline");
            DropColumn("dbo.Movies", "Rating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Rating", c => c.Double());
            AddColumn("dbo.Movies", "Tagline", c => c.String());
            AddColumn("dbo.Movies", "YearReleased", c => c.Int());
        }
    }
}

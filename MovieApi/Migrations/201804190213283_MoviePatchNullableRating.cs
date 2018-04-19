namespace MovieApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoviePatchNullableRating : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Rating", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Rating", c => c.Double(nullable: false));
        }
    }
}

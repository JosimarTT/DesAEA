namespace Lab11_Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "CreatedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "CreatedDate", c => c.DateTime(nullable: false));
        }
    }
}

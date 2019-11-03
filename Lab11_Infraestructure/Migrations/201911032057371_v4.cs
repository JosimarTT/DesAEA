namespace Lab11_Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "UpdatedDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Students", "ModifiedDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "ModifiedDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Students", "UpdatedDate");
        }
    }
}

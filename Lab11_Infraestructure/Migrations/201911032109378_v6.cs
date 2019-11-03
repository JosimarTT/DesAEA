namespace Lab11_Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "UpdatedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "UpdatedDate", c => c.DateTime(nullable: false));
        }
    }
}

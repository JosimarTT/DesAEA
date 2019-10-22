namespace Lab10.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Activo", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "Activo");
        }
    }
}

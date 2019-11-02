namespace Lab11_Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "studentCode", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "studentLastName", c => c.String());
            AddColumn("dbo.Students", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Students", "ModifiedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "ModifiedDate");
            DropColumn("dbo.Students", "CreatedDate");
            DropColumn("dbo.Students", "studentLastName");
            DropColumn("dbo.Students", "studentCode");
        }
    }
}

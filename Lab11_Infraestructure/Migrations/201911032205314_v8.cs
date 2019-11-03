namespace Lab11_Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v8 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Students");
            AlterColumn("dbo.Students", "studentID", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Students", "UpdatedDate", c => c.DateTime(nullable: false));
            AddPrimaryKey("dbo.Students", "studentID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Students");
            AlterColumn("dbo.Students", "UpdatedDate", c => c.DateTime());
            AlterColumn("dbo.Students", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.Students", "studentID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Students", "studentID");
        }
    }
}

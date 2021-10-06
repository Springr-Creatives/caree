namespace Caree.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                u => new
                {
                    UserId = u.Int(nullable: false, identity: true),
                    UserName = u.String(),
                    Password = u.String(),
                })
                .PrimaryKey(t => t.UserId);
        }

        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}

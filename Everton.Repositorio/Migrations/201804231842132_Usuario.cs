namespace Everton.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Usuario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        IdUsuario = c.Int(nullable: false, identity: true),
                        NomeUsuario = c.String(maxLength: 50, unicode: false),
                        CPF = c.Long(nullable: false),
                        Email = c.String(maxLength: 50, unicode: false),
                        Login = c.String(nullable: false, maxLength: 30, unicode: false),
                        DataInclusao = c.DateTime(),
                    })
                .PrimaryKey(t => t.IdUsuario)
                .Index(t => t.CPF, unique: true)
                .Index(t => t.Login, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Usuario", new[] { "Login" });
            DropIndex("dbo.Usuario", new[] { "CPF" });
            DropTable("dbo.Usuario");
        }
    }
}

namespace CodingCraftHOMod1Ex2Scaffolding.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GrupoCategoria",
                c => new
                    {
                        GrupoCategoriaId = c.Long(nullable: false, identity: true),
                        NomeGrupoCategoria = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.GrupoCategoriaId);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        ProdutoId = c.Long(nullable: false, identity: true),
                        GrupoCategoriaId = c.Long(nullable: false),
                        GrupoProdutoId = c.Long(nullable: false),
                        Nome = c.String(nullable: false),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EstiloGola = c.String(nullable: false),
                        Tamanho = c.String(nullable: false),
                        Cor = c.String(nullable: false),
                        Estoque = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProdutoId)
                .ForeignKey("dbo.GrupoCategoria", t => t.GrupoCategoriaId, cascadeDelete: true)
                .ForeignKey("dbo.GrupoProduto", t => t.GrupoProdutoId, cascadeDelete: true)
                .Index(t => t.GrupoCategoriaId)
                .Index(t => t.GrupoProdutoId);
            
            CreateTable(
                "dbo.GrupoProduto",
                c => new
                    {
                        GrupoProdutoId = c.Long(nullable: false, identity: true),
                        NomeGrupoProduto = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.GrupoProdutoId);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        TagId = c.Long(nullable: false, identity: true),
                        TagNome = c.String(nullable: false),
                        ProdutoId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.TagId);
            
            CreateTable(
                "dbo.Venda",
                c => new
                    {
                        VendaId = c.Long(nullable: false, identity: true),
                        UsuarioId = c.Long(nullable: false),
                        Quantidade = c.Int(nullable: false),
                        DtCompra = c.DateTime(nullable: false),
                        ProdutoId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.VendaId)
                .ForeignKey("dbo.Produto", t => t.ProdutoId, cascadeDelete: true)
                .Index(t => t.ProdutoId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.TagProdutoes",
                c => new
                    {
                        Tag_TagId = c.Long(nullable: false),
                        Produto_ProdutoId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_TagId, t.Produto_ProdutoId })
                .ForeignKey("dbo.Tag", t => t.Tag_TagId, cascadeDelete: true)
                .ForeignKey("dbo.Produto", t => t.Produto_ProdutoId, cascadeDelete: true)
                .Index(t => t.Tag_TagId)
                .Index(t => t.Produto_ProdutoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Venda", "ProdutoId", "dbo.Produto");
            DropForeignKey("dbo.TagProdutoes", "Produto_ProdutoId", "dbo.Produto");
            DropForeignKey("dbo.TagProdutoes", "Tag_TagId", "dbo.Tag");
            DropForeignKey("dbo.Produto", "GrupoProdutoId", "dbo.GrupoProduto");
            DropForeignKey("dbo.Produto", "GrupoCategoriaId", "dbo.GrupoCategoria");
            DropIndex("dbo.TagProdutoes", new[] { "Produto_ProdutoId" });
            DropIndex("dbo.TagProdutoes", new[] { "Tag_TagId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Venda", new[] { "ProdutoId" });
            DropIndex("dbo.Produto", new[] { "GrupoProdutoId" });
            DropIndex("dbo.Produto", new[] { "GrupoCategoriaId" });
            DropTable("dbo.TagProdutoes");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Venda");
            DropTable("dbo.Tag");
            DropTable("dbo.GrupoProduto");
            DropTable("dbo.Produto");
            DropTable("dbo.GrupoCategoria");
        }
    }
}

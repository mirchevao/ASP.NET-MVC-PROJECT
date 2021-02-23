namespace CookBookProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelsdone : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BakedGoods",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        recipeTypeId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Ingredients = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Rating = c.Single(nullable: false),
                        ImgURL = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.RecipeTypes", t => t.recipeTypeId, cascadeDelete: true)
                .Index(t => t.recipeTypeId);
            
            CreateTable(
                "dbo.EasyDinners",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        recipeTypeId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Ingredients = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Rating = c.Single(nullable: false),
                        ImgURL = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.RecipeTypes", t => t.recipeTypeId, cascadeDelete: true)
                .Index(t => t.recipeTypeId);
            
            CreateTable(
                "dbo.HealthyEatings",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        recipeTypeId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Ingredients = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Rating = c.Single(nullable: false),
                        ImgURL = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.RecipeTypes", t => t.recipeTypeId, cascadeDelete: true)
                .Index(t => t.recipeTypeId);
            
            CreateTable(
                "dbo.Ketoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        recipeTypeId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Ingredients = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Rating = c.Single(nullable: false),
                        ImgURL = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.RecipeTypes", t => t.recipeTypeId, cascadeDelete: true)
                .Index(t => t.recipeTypeId);
            
            CreateTable(
                "dbo.LowCarbMeals",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        recipeTypeId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Ingredients = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Rating = c.Single(nullable: false),
                        ImgURL = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.RecipeTypes", t => t.recipeTypeId, cascadeDelete: true)
                .Index(t => t.recipeTypeId);
            
            CreateTable(
                "dbo.OnePotRecipes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        recipeTypeId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Ingredients = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Rating = c.Single(nullable: false),
                        ImgURL = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.RecipeTypes", t => t.recipeTypeId, cascadeDelete: true)
                .Index(t => t.recipeTypeId);
            
            CreateTable(
                "dbo.Vegetarians",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        recipeTypeId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Ingredients = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Rating = c.Single(nullable: false),
                        ImgURL = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.RecipeTypes", t => t.recipeTypeId, cascadeDelete: true)
                .Index(t => t.recipeTypeId);
            
            CreateTable(
                "dbo.WeekendMealPreps",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        recipeTypeId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Ingredients = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Rating = c.Single(nullable: false),
                        ImgURL = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.RecipeTypes", t => t.recipeTypeId, cascadeDelete: true)
                .Index(t => t.recipeTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WeekendMealPreps", "recipeTypeId", "dbo.RecipeTypes");
            DropForeignKey("dbo.Vegetarians", "recipeTypeId", "dbo.RecipeTypes");
            DropForeignKey("dbo.OnePotRecipes", "recipeTypeId", "dbo.RecipeTypes");
            DropForeignKey("dbo.LowCarbMeals", "recipeTypeId", "dbo.RecipeTypes");
            DropForeignKey("dbo.Ketoes", "recipeTypeId", "dbo.RecipeTypes");
            DropForeignKey("dbo.HealthyEatings", "recipeTypeId", "dbo.RecipeTypes");
            DropForeignKey("dbo.EasyDinners", "recipeTypeId", "dbo.RecipeTypes");
            DropForeignKey("dbo.BakedGoods", "recipeTypeId", "dbo.RecipeTypes");
            DropIndex("dbo.WeekendMealPreps", new[] { "recipeTypeId" });
            DropIndex("dbo.Vegetarians", new[] { "recipeTypeId" });
            DropIndex("dbo.OnePotRecipes", new[] { "recipeTypeId" });
            DropIndex("dbo.LowCarbMeals", new[] { "recipeTypeId" });
            DropIndex("dbo.Ketoes", new[] { "recipeTypeId" });
            DropIndex("dbo.HealthyEatings", new[] { "recipeTypeId" });
            DropIndex("dbo.EasyDinners", new[] { "recipeTypeId" });
            DropIndex("dbo.BakedGoods", new[] { "recipeTypeId" });
            DropTable("dbo.WeekendMealPreps");
            DropTable("dbo.Vegetarians");
            DropTable("dbo.OnePotRecipes");
            DropTable("dbo.LowCarbMeals");
            DropTable("dbo.Ketoes");
            DropTable("dbo.HealthyEatings");
            DropTable("dbo.EasyDinners");
            DropTable("dbo.BakedGoods");
        }
    }
}

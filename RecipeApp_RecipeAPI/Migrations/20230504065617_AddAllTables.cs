using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeApp_RecipeAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddAllTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img_small = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img_large = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Youtube_url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Diets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img_small = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img_large = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img_small = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img_large = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Locale_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Locales_Locale_id",
                        column: x => x.Locale_id,
                        principalTable: "Locales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CookTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Locale_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CookTimes_Locales_Locale_id",
                        column: x => x.Locale_id,
                        principalTable: "Locales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img_small = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img_large = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Locale_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_Locales_Locale_id",
                        column: x => x.Locale_id,
                        principalTable: "Locales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Introduction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calories = table.Column<int>(type: "int", nullable: false),
                    Servings = table.Column<int>(type: "int", nullable: false),
                    Allergens = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Allergens_decription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cook_id = table.Column<int>(type: "int", nullable: false),
                    Locale_id = table.Column<int>(type: "int", nullable: false),
                    Cooking_time = table.Column<int>(type: "int", nullable: false),
                    Youtube_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_Cooks_Cook_id",
                        column: x => x.Cook_id,
                        principalTable: "Cooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recipes_Locales_Locale_id",
                        column: x => x.Locale_id,
                        principalTable: "Locales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Locale_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeTypes_Locales_Locale_id",
                        column: x => x.Locale_id,
                        principalTable: "Locales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone_no = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role_id = table.Column<int>(type: "int", nullable: false),
                    Locale_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Locales_Locale_id",
                        column: x => x.Locale_id,
                        principalTable: "Locales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Recipe_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ingredient_id = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Quantity_unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Locale_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Ingredients_Ingredient_id",
                        column: x => x.Ingredient_id,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Locales_Locale_id",
                        column: x => x.Locale_id,
                        principalTable: "Locales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Recipes_Recipe_id",
                        column: x => x.Recipe_id,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RecipeInstructions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Recipe_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Step_no = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img_small = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img_large = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Locale_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeInstructions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeInstructions_Locales_Locale_id",
                        column: x => x.Locale_id,
                        principalTable: "Locales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeInstructions_Recipes_Recipe_id",
                        column: x => x.Recipe_id,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CookFollowers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cook_id = table.Column<int>(type: "int", nullable: false),
                    User_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookFollowers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CookFollowers_Cooks_Cook_id",
                        column: x => x.Cook_id,
                        principalTable: "Cooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CookFollowers_Users_User_id",
                        column: x => x.User_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeReactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Recepie_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    User_id = table.Column<int>(type: "int", nullable: false),
                    Reaction_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeReactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeReactions_Reactions_Reaction_id",
                        column: x => x.Reaction_id,
                        principalTable: "Reactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeReactions_Recipes_Recepie_id",
                        column: x => x.Recepie_id,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeReactions_Users_User_id",
                        column: x => x.User_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RecipeReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    User_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeReviews_Users_User_id",
                        column: x => x.User_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Locale_id",
                table: "Categories",
                column: "Locale_id");

            migrationBuilder.CreateIndex(
                name: "IX_CookFollowers_Cook_id",
                table: "CookFollowers",
                column: "Cook_id");

            migrationBuilder.CreateIndex(
                name: "IX_CookFollowers_User_id",
                table: "CookFollowers",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_CookTimes_Locale_id",
                table: "CookTimes",
                column: "Locale_id");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_Locale_id",
                table: "Ingredients",
                column: "Locale_id");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_Ingredient_id",
                table: "RecipeIngredients",
                column: "Ingredient_id");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_Locale_id",
                table: "RecipeIngredients",
                column: "Locale_id");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_Recipe_id",
                table: "RecipeIngredients",
                column: "Recipe_id");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeInstructions_Locale_id",
                table: "RecipeInstructions",
                column: "Locale_id");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeInstructions_Recipe_id",
                table: "RecipeInstructions",
                column: "Recipe_id");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeReactions_Reaction_id",
                table: "RecipeReactions",
                column: "Reaction_id");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeReactions_Recepie_id",
                table: "RecipeReactions",
                column: "Recepie_id");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeReactions_User_id",
                table: "RecipeReactions",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeReviews_User_id",
                table: "RecipeReviews",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_Cook_id",
                table: "Recipes",
                column: "Cook_id");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_Locale_id",
                table: "Recipes",
                column: "Locale_id");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeTypes_Locale_id",
                table: "RecipeTypes",
                column: "Locale_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Locale_id",
                table: "Users",
                column: "Locale_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "CookFollowers");

            migrationBuilder.DropTable(
                name: "CookTimes");

            migrationBuilder.DropTable(
                name: "Diets");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "RecipeIngredients");

            migrationBuilder.DropTable(
                name: "RecipeInstructions");

            migrationBuilder.DropTable(
                name: "RecipeReactions");

            migrationBuilder.DropTable(
                name: "RecipeReviews");

            migrationBuilder.DropTable(
                name: "RecipeTypes");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Reactions");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cooks");

            migrationBuilder.DropTable(
                name: "Locales");
        }
    }
}

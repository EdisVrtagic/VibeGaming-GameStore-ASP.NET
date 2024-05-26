using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VibeGamingWeb.Migrations
{
    public partial class VMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    IdGame = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameName = table.Column<string>(type: "varchar(100)", nullable: false),
                    GamePrice = table.Column<float>(type: "real", nullable: false),
                    GameImgPath = table.Column<string>(type: "varchar(200)", nullable: false),
                    GamePlatform = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.IdGame);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(50)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    IdCart = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartEmail = table.Column<string>(type: "varchar(100)", nullable: false),
                    CartImgPath = table.Column<string>(type: "varchar(200)", nullable: false),
                    CartGameName = table.Column<string>(type: "varchar(100)", nullable: false),
                    CartGameQty = table.Column<int>(type: "int", nullable: false),
                    CartGamePrice = table.Column<float>(type: "real", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdGame = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.IdCart);
                    table.ForeignKey(
                        name: "FK_Carts_Games_IdGame",
                        column: x => x.IdGame,
                        principalTable: "Games",
                        principalColumn: "IdGame",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Carts_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    IdOrd = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdFirstName = table.Column<string>(type: "varchar(100)", nullable: false),
                    OrdLastName = table.Column<string>(type: "varchar(100)", nullable: false),
                    OrdAddress = table.Column<string>(type: "varchar(100)", nullable: false),
                    OrdPhoneNum = table.Column<string>(type: "varchar(20)", nullable: false),
                    OrdImgPath = table.Column<string>(type: "varchar(200)", nullable: false),
                    OrdGameName = table.Column<string>(type: "varchar(100)", nullable: false),
                    OrdGameQty = table.Column<int>(type: "int", nullable: false),
                    OrdGamePrice = table.Column<float>(type: "real", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdGame = table.Column<int>(type: "int", nullable: false),
                    OrdTotalNum = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.IdOrd);
                    table.ForeignKey(
                        name: "FK_Orders_Games_IdGame",
                        column: x => x.IdGame,
                        principalTable: "Games",
                        principalColumn: "IdGame",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Buys",
                columns: table => new
                {
                    IdBuy = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyWallImgPath = table.Column<string>(type: "varchar(200)", nullable: false),
                    BuyName = table.Column<string>(type: "varchar(100)", nullable: false),
                    BuyPlatImgPath = table.Column<string>(type: "varchar(200)", nullable: false),
                    BuyGameEdition = table.Column<string>(type: "varchar(100)", nullable: false),
                    BuyStockGame = table.Column<string>(type: "varchar(100)", nullable: false),
                    BuyAgeRestrict = table.Column<string>(type: "varchar(100)", nullable: false),
                    BuyPrice = table.Column<float>(type: "real", nullable: false),
                    IdGame = table.Column<int>(type: "int", nullable: false),
                    IdSpec = table.Column<int>(type: "int", nullable: true),
                    IdUser = table.Column<int>(type: "int", nullable: true),
                    IdCart = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buys", x => x.IdBuy);
                    table.ForeignKey(
                        name: "FK_Buys_Carts_IdCart",
                        column: x => x.IdCart,
                        principalTable: "Carts",
                        principalColumn: "IdCart");
                    table.ForeignKey(
                        name: "FK_Buys_Games_IdGame",
                        column: x => x.IdGame,
                        principalTable: "Games",
                        principalColumn: "IdGame",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Buys_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser");
                });

            migrationBuilder.CreateTable(
                name: "Cates",
                columns: table => new
                {
                    IdCate = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CateOfOn = table.Column<string>(type: "varchar(100)", nullable: false),
                    CateDigKey = table.Column<string>(type: "varchar(100)", nullable: false),
                    CateGameSupp = table.Column<string>(type: "varchar(100)", nullable: false),
                    CatePlayer = table.Column<string>(type: "varchar(100)", nullable: false),
                    CateDev = table.Column<string>(type: "varchar(100)", nullable: false),
                    CateRevNum = table.Column<string>(type: "varchar(100)", nullable: false),
                    IdGame = table.Column<int>(type: "int", nullable: false),
                    IdBuy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cates", x => x.IdCate);
                    table.ForeignKey(
                        name: "FK_Cates_Buys_IdBuy",
                        column: x => x.IdBuy,
                        principalTable: "Buys",
                        principalColumn: "IdBuy");
                    table.ForeignKey(
                        name: "FK_Cates_Games_IdGame",
                        column: x => x.IdGame,
                        principalTable: "Games",
                        principalColumn: "IdGame",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tips",
                columns: table => new
                {
                    IdTip = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipGame1 = table.Column<string>(type: "varchar(100)", nullable: false),
                    TipGame2 = table.Column<string>(type: "varchar(100)", nullable: false),
                    TipGame3 = table.Column<string>(type: "varchar(100)", nullable: false),
                    TipGame4 = table.Column<string>(type: "varchar(100)", nullable: false),
                    TipBannPath = table.Column<string>(type: "varchar(200)", nullable: false),
                    TipAboutGame = table.Column<string>(type: "varchar(100)", nullable: false),
                    TipTextGame = table.Column<string>(type: "varchar(500)", nullable: false),
                    IdGame = table.Column<int>(type: "int", nullable: false),
                    IdCate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tips", x => x.IdTip);
                    table.ForeignKey(
                        name: "FK_Tips_Cates_IdCate",
                        column: x => x.IdCate,
                        principalTable: "Cates",
                        principalColumn: "IdCate");
                    table.ForeignKey(
                        name: "FK_Tips_Games_IdGame",
                        column: x => x.IdGame,
                        principalTable: "Games",
                        principalColumn: "IdGame",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Galls",
                columns: table => new
                {
                    IdGall = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GallImgPath = table.Column<string>(type: "varchar(200)", nullable: false),
                    GallImgTitle = table.Column<string>(type: "varchar(100)", nullable: false),
                    GallImgDesc = table.Column<string>(type: "varchar(500)", nullable: false),
                    IdGame = table.Column<int>(type: "int", nullable: false),
                    IdTip = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galls", x => x.IdGall);
                    table.ForeignKey(
                        name: "FK_Galls_Games_IdGame",
                        column: x => x.IdGame,
                        principalTable: "Games",
                        principalColumn: "IdGame",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Galls_Tips_IdTip",
                        column: x => x.IdTip,
                        principalTable: "Tips",
                        principalColumn: "IdTip");
                });

            migrationBuilder.CreateTable(
                name: "Trailers",
                columns: table => new
                {
                    IdTra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TraImgPath = table.Column<string>(type: "varchar(200)", nullable: false),
                    TraLink = table.Column<string>(type: "varchar(200)", nullable: false),
                    IdGame = table.Column<int>(type: "int", nullable: false),
                    IdGall = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trailers", x => x.IdTra);
                    table.ForeignKey(
                        name: "FK_Trailers_Galls_IdGall",
                        column: x => x.IdGall,
                        principalTable: "Galls",
                        principalColumn: "IdGall");
                    table.ForeignKey(
                        name: "FK_Trailers_Games_IdGame",
                        column: x => x.IdGame,
                        principalTable: "Games",
                        principalColumn: "IdGame",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Specs",
                columns: table => new
                {
                    IdSpec = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecOSMin = table.Column<string>(type: "varchar(200)", nullable: true),
                    SpecProcMin = table.Column<string>(type: "varchar(200)", nullable: true),
                    SpecMemMin = table.Column<string>(type: "varchar(200)", nullable: true),
                    SpecGrapMin = table.Column<string>(type: "varchar(200)", nullable: true),
                    SpecStorMin = table.Column<string>(type: "varchar(200)", nullable: true),
                    SpecOSMax = table.Column<string>(type: "varchar(200)", nullable: true),
                    SpecProcMax = table.Column<string>(type: "varchar(200)", nullable: true),
                    SpecMemMax = table.Column<string>(type: "varchar(200)", nullable: true),
                    SpecGrapMax = table.Column<string>(type: "varchar(200)", nullable: true),
                    SpecStorMax = table.Column<string>(type: "varchar(200)", nullable: true),
                    IdGame = table.Column<int>(type: "int", nullable: false),
                    IdTra = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specs", x => x.IdSpec);
                    table.ForeignKey(
                        name: "FK_Specs_Games_IdGame",
                        column: x => x.IdGame,
                        principalTable: "Games",
                        principalColumn: "IdGame",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Specs_Trailers_IdTra",
                        column: x => x.IdTra,
                        principalTable: "Trailers",
                        principalColumn: "IdTra");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buys_IdCart",
                table: "Buys",
                column: "IdCart");

            migrationBuilder.CreateIndex(
                name: "IX_Buys_IdGame",
                table: "Buys",
                column: "IdGame");

            migrationBuilder.CreateIndex(
                name: "IX_Buys_IdSpec",
                table: "Buys",
                column: "IdSpec");

            migrationBuilder.CreateIndex(
                name: "IX_Buys_IdUser",
                table: "Buys",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_IdGame",
                table: "Carts",
                column: "IdGame");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_IdUser",
                table: "Carts",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Cates_IdBuy",
                table: "Cates",
                column: "IdBuy");

            migrationBuilder.CreateIndex(
                name: "IX_Cates_IdGame",
                table: "Cates",
                column: "IdGame");

            migrationBuilder.CreateIndex(
                name: "IX_Galls_IdGame",
                table: "Galls",
                column: "IdGame");

            migrationBuilder.CreateIndex(
                name: "IX_Galls_IdTip",
                table: "Galls",
                column: "IdTip");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IdGame",
                table: "Orders",
                column: "IdGame");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IdUser",
                table: "Orders",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Specs_IdGame",
                table: "Specs",
                column: "IdGame");

            migrationBuilder.CreateIndex(
                name: "IX_Specs_IdTra",
                table: "Specs",
                column: "IdTra");

            migrationBuilder.CreateIndex(
                name: "IX_Tips_IdCate",
                table: "Tips",
                column: "IdCate");

            migrationBuilder.CreateIndex(
                name: "IX_Tips_IdGame",
                table: "Tips",
                column: "IdGame");

            migrationBuilder.CreateIndex(
                name: "IX_Trailers_IdGall",
                table: "Trailers",
                column: "IdGall");

            migrationBuilder.CreateIndex(
                name: "IX_Trailers_IdGame",
                table: "Trailers",
                column: "IdGame");

            migrationBuilder.AddForeignKey(
                name: "FK_Buys_Specs_IdSpec",
                table: "Buys",
                column: "IdSpec",
                principalTable: "Specs",
                principalColumn: "IdSpec");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buys_Carts_IdCart",
                table: "Buys");

            migrationBuilder.DropForeignKey(
                name: "FK_Buys_Games_IdGame",
                table: "Buys");

            migrationBuilder.DropForeignKey(
                name: "FK_Cates_Games_IdGame",
                table: "Cates");

            migrationBuilder.DropForeignKey(
                name: "FK_Galls_Games_IdGame",
                table: "Galls");

            migrationBuilder.DropForeignKey(
                name: "FK_Specs_Games_IdGame",
                table: "Specs");

            migrationBuilder.DropForeignKey(
                name: "FK_Tips_Games_IdGame",
                table: "Tips");

            migrationBuilder.DropForeignKey(
                name: "FK_Trailers_Games_IdGame",
                table: "Trailers");

            migrationBuilder.DropForeignKey(
                name: "FK_Buys_Specs_IdSpec",
                table: "Buys");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Specs");

            migrationBuilder.DropTable(
                name: "Trailers");

            migrationBuilder.DropTable(
                name: "Galls");

            migrationBuilder.DropTable(
                name: "Tips");

            migrationBuilder.DropTable(
                name: "Cates");

            migrationBuilder.DropTable(
                name: "Buys");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

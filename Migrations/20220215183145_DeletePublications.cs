using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Migrations
{
    public partial class DeletePublications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Publications");

            migrationBuilder.AddColumn<int>(
                name: "DateId",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_DateId",
                table: "Articles",
                column: "DateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Dates_DateId",
                table: "Articles",
                column: "DateId",
                principalTable: "Dates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Dates_DateId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_DateId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "DateId",
                table: "Articles");

            migrationBuilder.CreateTable(
                name: "Publications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    DateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publications_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Publications_Dates_DateId",
                        column: x => x.DateId,
                        principalTable: "Dates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Publications_ArticleId",
                table: "Publications",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_DateId",
                table: "Publications",
                column: "DateId");
        }
    }
}

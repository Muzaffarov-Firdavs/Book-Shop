using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShop.Migrations
{
    public partial class thirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_Authors_AuthorId",
                table: "Discounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_Books_Bookid",
                table: "Discounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_Publishers_PublisherId",
                table: "Discounts");

            migrationBuilder.RenameColumn(
                name: "Bookid",
                table: "Discounts",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Discounts_Bookid",
                table: "Discounts",
                newName: "IX_Discounts_BookId");

            migrationBuilder.AlterColumn<long>(
                name: "PublisherId",
                table: "Discounts",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "BookId",
                table: "Discounts",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "AuthorId",
                table: "Discounts",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_Authors_AuthorId",
                table: "Discounts",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_Books_BookId",
                table: "Discounts",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_Publishers_PublisherId",
                table: "Discounts",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_Authors_AuthorId",
                table: "Discounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_Books_BookId",
                table: "Discounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_Publishers_PublisherId",
                table: "Discounts");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Discounts",
                newName: "Bookid");

            migrationBuilder.RenameIndex(
                name: "IX_Discounts_BookId",
                table: "Discounts",
                newName: "IX_Discounts_Bookid");

            migrationBuilder.AlterColumn<long>(
                name: "PublisherId",
                table: "Discounts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Bookid",
                table: "Discounts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AuthorId",
                table: "Discounts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_Authors_AuthorId",
                table: "Discounts",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_Books_Bookid",
                table: "Discounts",
                column: "Bookid",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_Publishers_PublisherId",
                table: "Discounts",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

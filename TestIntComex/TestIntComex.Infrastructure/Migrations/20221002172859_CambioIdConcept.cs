using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestIntComex.Infrastructure.Migrations
{
    public partial class CambioIdConcept : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TbContact",
                table: "TbContact");

            migrationBuilder.AlterColumn<string>(
                name: "strClientCode",
                table: "TbContact",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TbContact",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TbContact",
                table: "TbContact",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TbContact",
                table: "TbContact");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TbContact");

            migrationBuilder.AlterColumn<string>(
                name: "strClientCode",
                table: "TbContact",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TbContact",
                table: "TbContact",
                column: "strClientCode");
        }
    }
}

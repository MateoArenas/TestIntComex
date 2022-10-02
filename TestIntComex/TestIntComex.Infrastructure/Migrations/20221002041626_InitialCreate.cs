using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestIntComex.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbContactType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbContactType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbContact",
                columns: table => new
                {
                    strClientCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    strUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    strName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    strPosition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    strPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    strEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    strCellphone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdContactType = table.Column<int>(type: "int", nullable: false),
                    boolAutorizeWebStore = table.Column<bool>(type: "bit", nullable: false),
                    boolAutorizeOrders = table.Column<bool>(type: "bit", nullable: false),
                    boolSendInformation = table.Column<bool>(type: "bit", nullable: false),
                    strPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbContact", x => x.strClientCode);
                    table.ForeignKey(
                        name: "FK_TbContact_TbContactType_IdContactType",
                        column: x => x.IdContactType,
                        principalTable: "TbContactType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbContact_IdContactType",
                table: "TbContact",
                column: "IdContactType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbContact");

            migrationBuilder.DropTable(
                name: "TbContactType");
        }
    }
}

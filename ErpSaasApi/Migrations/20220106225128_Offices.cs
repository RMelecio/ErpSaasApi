using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ErpSaasApi.Migrations
{
    public partial class Offices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "businessName",
                table: "Companies",
                newName: "BusinessName");

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Addrees = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Offices",
                columns: new[] { "Id", "Addrees", "Address2", "City", "Country", "Name", "State", "Status", "Type", "ZipCode" },
                values: new object[] { 1L, "Direccion 1", "Direccion 2", "Guadalajara", "Mexico", "Oficina Matriz", "Jalisco", 1, "Matriz", "44750" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Offices");

            migrationBuilder.RenameColumn(
                name: "BusinessName",
                table: "Companies",
                newName: "businessName");
        }
    }
}

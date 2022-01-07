using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ErpSaasApi.Migrations
{
    public partial class CompaniesSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Addrees", "Address2", "BusinessId", "BusinnesClasification", "City", "Country", "State", "ZipCode", "businessName" },
                values: new object[] { 1L, "Direccion 1", "Direccion 2", "DEMO890224455", "601 - General de Impuestos", "Guadalajara", "Mexico", "Jalisco", "44720", "Empresa Demo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}

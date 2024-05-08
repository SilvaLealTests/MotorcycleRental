using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorcycleRental.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class change_cnh_and_cnpj_to_unique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Bikers_CNH",
                table: "Bikers",
                column: "CNH",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bikers_CNPJ",
                table: "Bikers",
                column: "CNPJ",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bikers_CNH",
                table: "Bikers");

            migrationBuilder.DropIndex(
                name: "IX_Bikers_CNPJ",
                table: "Bikers");
        }
    }
}

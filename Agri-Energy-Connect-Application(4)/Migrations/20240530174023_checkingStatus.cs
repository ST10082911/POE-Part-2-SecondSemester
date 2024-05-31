using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agri_Energy_Connect_Application_4_.Migrations
{
    /// <inheritdoc />
    public partial class checkingStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "ApplicationUser");

            // Update existing users to have the correct discriminator
            migrationBuilder.Sql("UPDATE AspNetUsers SET Discriminator = 'ApplicationUser' WHERE Discriminator IS NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}

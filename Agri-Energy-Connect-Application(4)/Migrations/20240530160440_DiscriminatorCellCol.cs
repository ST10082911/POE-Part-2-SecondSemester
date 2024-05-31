using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agri_Energy_Connect_Application_4_.Migrations
{
    /// <inheritdoc />
    public partial class DiscriminatorCellCol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Add Discriminator column to AspNetUsers table
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            // Add CellNo column to AspNetUsers table
            migrationBuilder.AddColumn<string>(
                name: "CellNo",
                table: "AspNetUsers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop the Discriminator column from AspNetUsers table
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            // Drop the CellNo column from AspNetUsers table
            migrationBuilder.DropColumn(
                name: "CellNo",
                table: "AspNetUsers");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PR_ERP_WebAPI.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldInOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Orders",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Orders");
        }
    }
}

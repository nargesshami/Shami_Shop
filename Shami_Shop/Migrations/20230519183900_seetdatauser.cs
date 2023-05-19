using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shami_Shop.Migrations
{
    /// <inheritdoc />
    public partial class seetdatauser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "IsAdmin", "MobilePhone", "Password" },
                values: new object[] { 1, true, "09372246289", "2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);
        }
    }
}

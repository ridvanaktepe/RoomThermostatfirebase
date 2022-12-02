using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace firebase.Migrations
{
    /// <inheritdoc />
    public partial class migrationOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "room",
                columns: table => new
                {
                    index = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SetTemp = table.Column<int>(name: "Set_Temp", type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Temp = table.Column<int>(type: "int", nullable: false),
                    Voltage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_room", x => x.index);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "room");
        }
    }
}

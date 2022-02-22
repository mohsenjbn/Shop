using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopManagement.Infrastracture.EfCore.Migrations
{
    public partial class AddSlides : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Slides",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Picture = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    PictureAlt = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PictureTitle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Heading = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Btntext = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slides", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Slides");
        }
    }
}

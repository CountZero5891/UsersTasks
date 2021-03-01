using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace UsersTasks.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Objectives",
                columns: table => new
                {
                    ObjectiveId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DirectorId = table.Column<int>(type: "integer", nullable: false),
                    ExecutorId = table.Column<int>(type: "integer", nullable: false),
                    StatusObjective = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objectives", x => x.ObjectiveId);
                    table.ForeignKey(
                        name: "FK_Objectives_Users_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Objectives_Users_ExecutorId",
                        column: x => x.ExecutorId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedTime", "Name", "Status", "Surname", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tom", 1, "Cruise", new DateTime(2020, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2019, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alice", 1, "Cooper", new DateTime(2020, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2019, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "James", 1, "Woods", new DateTime(2020, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2019, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Isaac", 1, "Clarke", new DateTime(2020, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2019, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "James", 1, "Deen", new DateTime(2020, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Objectives",
                columns: new[] { "ObjectiveId", "CreatedTime", "Description", "DirectorId", "ExecutorId", "Name", "StatusObjective", "UpdatedTime" },
                values: new object[,]
                {
                    { 13, new DateTime(2019, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Task13", 2, 1, "Task13", 0, new DateTime(2022, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2019, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Task10", 5, 4, "Task10", 1, new DateTime(2021, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2019, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Task9", 5, 4, "Task9", 0, new DateTime(2021, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2019, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Task8", 5, 4, "Task8", 0, new DateTime(2020, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2019, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Task7", 5, 4, "Task7", 0, new DateTime(2021, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, new DateTime(2019, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Task24", 1, 3, "Task24", 1, new DateTime(2021, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, new DateTime(2019, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Task23", 1, 3, "Task23", 1, new DateTime(2021, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, new DateTime(2019, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Task22", 1, 3, "Task22", 0, new DateTime(2021, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, new DateTime(2019, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Task21", 1, 3, "Task21", 1, new DateTime(2021, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, new DateTime(2019, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Task20", 1, 3, "Task20", 0, new DateTime(2021, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2019, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Task6", 3, 2, "Task6", 1, new DateTime(2021, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2019, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Task5", 3, 2, "Task5", 1, new DateTime(2020, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2019, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Task4", 3, 2, "Task4", 0, new DateTime(2020, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2019, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Task3", 3, 2, "Task3", 1, new DateTime(2020, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2019, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Task2", 3, 2, "Task2", 0, new DateTime(2020, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, new DateTime(2019, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Task1", 3, 2, "Task1", 1, new DateTime(2020, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, new DateTime(2019, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Task19", 2, 1, "Task19", 0, new DateTime(2022, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, new DateTime(2019, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Task18", 2, 1, "Task18", 1, new DateTime(2022, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, new DateTime(2019, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Task17", 2, 1, "Task17", 0, new DateTime(2022, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, new DateTime(2019, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Task16", 2, 1, "Task16", 1, new DateTime(2020, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, new DateTime(2019, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Task15", 2, 1, "Task15", 0, new DateTime(2021, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, new DateTime(2019, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Task14", 2, 1, "Task14", 1, new DateTime(2021, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new DateTime(2019, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Task11", 5, 4, "Task11", 1, new DateTime(2022, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, new DateTime(2019, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Task12", 5, 4, "Task12", 0, new DateTime(2020, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Objectives_DirectorId",
                table: "Objectives",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Objectives_ExecutorId",
                table: "Objectives",
                column: "ExecutorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Objectives");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

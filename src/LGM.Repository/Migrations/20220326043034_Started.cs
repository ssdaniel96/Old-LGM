using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LGM.Repository.Migrations
{
    public partial class Started : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "book");

            migrationBuilder.EnsureSchema(
                name: "group");

            migrationBuilder.EnsureSchema(
                name: "people");

            migrationBuilder.EnsureSchema(
                name: "reading");

            migrationBuilder.CreateTable(
                name: "Groups",
                schema: "group",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupIdentity_SourceId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupIdentity_SourceTypeId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Progressions",
                schema: "reading",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chapter = table.Column<int>(type: "int", nullable: false),
                    PageNumber = table.Column<int>(type: "int", nullable: false),
                    Paragraph = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Progressions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SourceTypes",
                schema: "group",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SourceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                schema: "book",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    TotalPages = table.Column<int>(type: "int", nullable: false),
                    TotalChapters = table.Column<int>(type: "int", nullable: false),
                    Uri = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Groups_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "group",
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                schema: "people",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_Groups_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "group",
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReadingPlans",
                schema: "reading",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    ProgressionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadingPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReadingPlans_Books_BookId",
                        column: x => x.BookId,
                        principalSchema: "book",
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReadingPlans_Groups_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "group",
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReadingPlans_Progressions_ProgressionId",
                        column: x => x.ProgressionId,
                        principalSchema: "reading",
                        principalTable: "Progressions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reminders",
                schema: "reading",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KickOffMemberId = table.Column<int>(type: "int", nullable: false),
                    ResponsibleMemberId = table.Column<int>(type: "int", nullable: false),
                    PrayerMemberId = table.Column<int>(type: "int", nullable: false),
                    Chapter = table.Column<int>(type: "int", nullable: false),
                    PageNumber = table.Column<int>(type: "int", nullable: false),
                    Paragraph = table.Column<int>(type: "int", nullable: false),
                    ReadingPlanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reminders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reminders_Members_KickOffMemberId",
                        column: x => x.KickOffMemberId,
                        principalSchema: "people",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reminders_Members_PrayerMemberId",
                        column: x => x.PrayerMemberId,
                        principalSchema: "people",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reminders_Members_ResponsibleMemberId",
                        column: x => x.ResponsibleMemberId,
                        principalSchema: "people",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reminders_ReadingPlans_ReadingPlanId",
                        column: x => x.ReadingPlanId,
                        principalSchema: "reading",
                        principalTable: "ReadingPlans",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_GroupId",
                schema: "book",
                table: "Books",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_GroupId",
                schema: "people",
                table: "Members",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ReadingPlans_BookId",
                schema: "reading",
                table: "ReadingPlans",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_ReadingPlans_GroupId",
                schema: "reading",
                table: "ReadingPlans",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ReadingPlans_ProgressionId",
                schema: "reading",
                table: "ReadingPlans",
                column: "ProgressionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reminders_KickOffMemberId",
                schema: "reading",
                table: "Reminders",
                column: "KickOffMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Reminders_PrayerMemberId",
                schema: "reading",
                table: "Reminders",
                column: "PrayerMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Reminders_ReadingPlanId",
                schema: "reading",
                table: "Reminders",
                column: "ReadingPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Reminders_ResponsibleMemberId",
                schema: "reading",
                table: "Reminders",
                column: "ResponsibleMemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reminders",
                schema: "reading");

            migrationBuilder.DropTable(
                name: "SourceTypes",
                schema: "group");

            migrationBuilder.DropTable(
                name: "Members",
                schema: "people");

            migrationBuilder.DropTable(
                name: "ReadingPlans",
                schema: "reading");

            migrationBuilder.DropTable(
                name: "Books",
                schema: "book");

            migrationBuilder.DropTable(
                name: "Progressions",
                schema: "reading");

            migrationBuilder.DropTable(
                name: "Groups",
                schema: "group");
        }
    }
}

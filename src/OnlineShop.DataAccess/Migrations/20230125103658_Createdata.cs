using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace OnlineShop.DataAccess.Migrations
{
	public partial class Createdata : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Categorys",
				columns: table => new
				{
					Id = table.Column<long>(type: "bigint", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					CategoryName = table.Column<string>(type: "text", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Categorys", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Users",
				columns: table => new
				{
					Id = table.Column<long>(type: "bigint", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					FullName = table.Column<string>(type: "text", nullable: false),
					PhoneNumber = table.Column<string>(type: "text", nullable: false),
					Email = table.Column<string>(type: "text", nullable: false),
					IsEmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
					PasswordHash = table.Column<string>(type: "text", nullable: false),
					Salt = table.Column<string>(type: "text", nullable: false),
					ImagePath = table.Column<string>(type: "text", nullable: false),
					Role = table.Column<int>(type: "integer", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Users", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Announcements",
				columns: table => new
				{
					Id = table.Column<long>(type: "bigint", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					Title = table.Column<string>(type: "text", nullable: false),
					CategoryId = table.Column<long>(type: "bigint", nullable: false),
					ImagePath = table.Column<string>(type: "text", nullable: false),
					Description = table.Column<string>(type: "text", nullable: false),
					Price = table.Column<double>(type: "double precision", nullable: false),
					PhoneNumber = table.Column<string>(type: "text", nullable: false),
					UserId = table.Column<long>(type: "bigint", nullable: false),
					CreateAt = table.Column<string>(type: "text", nullable: false),
					LiceCount = table.Column<long>(type: "bigint", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Announcements", x => x.Id);
					table.ForeignKey(
						name: "FK_Announcements_Categorys_CategoryId",
						column: x => x.CategoryId,
						principalTable: "Categorys",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Announcements_Users_UserId",
						column: x => x.UserId,
						principalTable: "Users",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "SavedAds",
				columns: table => new
				{
					Id = table.Column<long>(type: "bigint", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					AnnouncementId = table.Column<long>(type: "bigint", nullable: false),
					UserId = table.Column<long>(type: "bigint", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_SavedAds", x => x.Id);
					table.ForeignKey(
						name: "FK_SavedAds_Announcements_AnnouncementId",
						column: x => x.AnnouncementId,
						principalTable: "Announcements",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_SavedAds_Users_UserId",
						column: x => x.UserId,
						principalTable: "Users",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Announcements_CategoryId",
				table: "Announcements",
				column: "CategoryId");

			migrationBuilder.CreateIndex(
				name: "IX_Announcements_UserId",
				table: "Announcements",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_SavedAds_AnnouncementId",
				table: "SavedAds",
				column: "AnnouncementId");

			migrationBuilder.CreateIndex(
				name: "IX_SavedAds_UserId",
				table: "SavedAds",
				column: "UserId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "SavedAds");

			migrationBuilder.DropTable(
				name: "Announcements");

			migrationBuilder.DropTable(
				name: "Categorys");

			migrationBuilder.DropTable(
				name: "Users");
		}
	}
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DirectStorageApproach.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NotificationStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TechnicalObjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Category = table.Column<char>(type: "character(1)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Weight = table.Column<decimal>(type: "numeric", nullable: true),
                    WeightUnit = table.Column<string>(type: "text", nullable: true),
                    AcquisitionPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    AcquisitionCurrency = table.Column<string>(type: "text", nullable: true),
                    AcquisitionDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ManufacturerName = table.Column<string>(type: "text", nullable: true),
                    ManufacturerCountry = table.Column<string>(type: "text", nullable: true),
                    ManufacturerModel = table.Column<string>(type: "text", nullable: true),
                    ManufacturerPartNumber = table.Column<string>(type: "text", nullable: true),
                    ManufacturerSerialNumber = table.Column<string>(type: "text", nullable: true),
                    ManufacturedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsEquipmentInstallAllowed = table.Column<bool>(type: "boolean", nullable: true),
                    IsSingleEquipmentInstalled = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechnicalObjects_TechnicalObjects_ParentId",
                        column: x => x.ParentId,
                        principalTable: "TechnicalObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Number = table.Column<long>(type: "bigint", nullable: false),
                    DetectedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CompletedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    Executor = table.Column<Guid>(type: "uuid", nullable: true),
                    TechnicalObjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    BreakdownStart = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    BreakdownFinish = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    BreakdownDuration = table.Column<TimeSpan>(type: "interval", nullable: true),
                    Version = table.Column<long>(type: "bigint", nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_NotificationStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "NotificationStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notifications_TechnicalObjects_TechnicalObjectId",
                        column: x => x.TechnicalObjectId,
                        principalTable: "TechnicalObjects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NotificationComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    NotificationId = table.Column<Guid>(type: "uuid", nullable: true),
                    FromStatusId = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ToStatusId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationComments_NotificationStatuses_FromStatusId",
                        column: x => x.FromStatusId,
                        principalTable: "NotificationStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotificationComments_NotificationStatuses_ToStatusId",
                        column: x => x.ToStatusId,
                        principalTable: "NotificationStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotificationComments_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotificationTechnicalObjectLinks",
                columns: table => new
                {
                    TechnicalObjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    NotificationId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationTechnicalObjectLinks", x => new { x.TechnicalObjectId, x.NotificationId });
                    table.ForeignKey(
                        name: "FK_NotificationTechnicalObjectLinks_Notifications_Notification~",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "NotificationStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "New" },
                    { 2, "Declined" },
                    { 3, "InProgress" },
                    { 4, "ActionRequired" },
                    { 5, "Resubmitted" },
                    { 6, "Done" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotificationComments_FromStatusId",
                table: "NotificationComments",
                column: "FromStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationComments_NotificationId",
                table: "NotificationComments",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationComments_ToStatusId",
                table: "NotificationComments",
                column: "ToStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_StatusId",
                table: "Notifications",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_TechnicalObjectId",
                table: "Notifications",
                column: "TechnicalObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationTechnicalObjectLinks_NotificationId",
                table: "NotificationTechnicalObjectLinks",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalObjects_ParentId",
                table: "TechnicalObjects",
                column: "ParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotificationComments");

            migrationBuilder.DropTable(
                name: "NotificationTechnicalObjectLinks");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "NotificationStatuses");

            migrationBuilder.DropTable(
                name: "TechnicalObjects");
        }
    }
}

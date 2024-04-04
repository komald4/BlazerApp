using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContactListApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Street = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    State = table.Column<string>(type: "TEXT", nullable: false),
                    ZipCode = table.Column<string>(type: "TEXT", nullable: false),
                    ContactId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("08a33b78-e7eb-4f6f-a09d-b1ba70626cb8"), "", "" },
                    { new Guid("14b72dd1-4d36-48f7-b56f-c23fcf67cce2"), "Mónica", "Gallego" },
                    { new Guid("22e1af59-2da0-4a0c-a82e-5e4d3e0cb0db"), "", "" },
                    { new Guid("62349bd2-0f28-4898-af96-cb4bc20b9d4b"), "", "" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "ContactId", "State", "Street", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("1dc38c3e-2d62-4a22-9894-8d5f59e8639c"), "Bilbao", new Guid("14b72dd1-4d36-48f7-b56f-c23fcf67cce2"), "Islas Baleares", "Calle de Tetuán", "34518" },
                    { new Guid("31d0cee4-b746-4dd2-8e4d-e04da8ad9f89"), "Henry", new Guid("62349bd2-0f28-4898-af96-cb4bc20b9d4b"), "James", "Calle de Tetuán", "34518" },
                    { new Guid("7d82402f-7562-48d7-9a61-783b14d09f3b"), "Bilbao", new Guid("08a33b78-e7eb-4f6f-a09d-b1ba70626cb8"), "Islas Baleares", "Calle de Tetuán", "34518" },
                    { new Guid("a17037b5-01f4-4f0c-9294-413488277e92"), "Bilbao", new Guid("08a33b78-e7eb-4f6f-a09d-b1ba70626cb8"), "Islas Baleares", "Calle de Tetuán", "34518" },
                    { new Guid("d2c0499f-5734-42cc-8d6c-1872c0654bf9"), "Bilbao", new Guid("22e1af59-2da0-4a0c-a82e-5e4d3e0cb0db"), "Islas Baleares", "Calle de Tetuán", "34518" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ContactId",
                table: "Addresses",
                column: "ContactId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}

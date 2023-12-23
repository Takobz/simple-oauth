using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace auth_server.Migrations
{
    /// <inheritdoc />
    public partial class ClientWithMoreProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ClientName = table.Column<string>(type: "TEXT", nullable: false),
                    RedirectUris = table.Column<string>(type: "TEXT", nullable: false),
                    TokenEndpointAuthMethod = table.Column<string>(type: "TEXT", nullable: false),
                    GrantTypes = table.Column<string>(type: "TEXT", nullable: false),
                    ResponseTypes = table.Column<string>(type: "TEXT", nullable: false),
                    ClientUri = table.Column<string>(type: "TEXT", nullable: false),
                    LogoUri = table.Column<string>(type: "TEXT", nullable: false),
                    TosUri = table.Column<string>(type: "TEXT", nullable: false),
                    Scope = table.Column<string>(type: "TEXT", nullable: false),
                    Contacts = table.Column<string>(type: "TEXT", nullable: false),
                    ClientSecret = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}

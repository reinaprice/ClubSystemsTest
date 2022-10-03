using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClubSystemsTest.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Insert of sample data - can be removed later
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientID", "Forename", "Surname", "Email" },
                values: new object[,] {
                    { 1, "Alice", "One", "aa.aa@aa.aa" },
                    { 2, "Bob", "Two", "bb.bb@bb.bb" } ,
                    { 3, "Carol", "Three", "aa.aa@aa.aa" },
                    { 4, "Dave", "Four", "bb.bb@bb.bb" }
                });

            migrationBuilder.InsertData(
                table: "MembershipTypes",
                columns: new[] { "MembershipTypeID", "Name" },
                values: new object[,] {
                    { 1, "Primary" },
                    { 2, "Secondary" }
                });

            migrationBuilder.InsertData(
                table: "Memberships",
                columns: new[] { "MembershipID", "ClientID", "MembershipTypeID", "Balance" },
                values: new object[,] {
                    { 1, 1, 1, 100 },
                    { 2, 1, 2, 200 },
                    { 3, 2, 1, -100 },
                    { 4, 2, 2, 0 },
                    { 5, 3, 1, 100 },
                    { 6, 3, 2, -200 },
                    { 7, 4, 1, -1000 },
                    { 8, 4, 2, -1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Memberships");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "MembershipTypes");


            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Forename = table.Column<string>(type: "TEXT", nullable: false),
                    Surname = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientID);
                });

            migrationBuilder.CreateTable(
                name: "MembershipTypes",
                columns: table => new
                {
                    MembershipTypeID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipTypes", x => x.MembershipTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Memberships",
                columns: table => new
                {
                    MembershipID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientID = table.Column<int>(type: "INTEGER", nullable: false),
                    MembershipTypeID = table.Column<int>(type: "INTEGER", nullable: false),
                    Balance = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memberships", x => x.MembershipID);
                    table.ForeignKey(
                        name: "FK_Memberships_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Memberships_MembershipTypes_MembershipTypeID",
                        column: x => x.MembershipTypeID,
                        principalTable: "MembershipTypes",
                        principalColumn: "MembershipTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_clientID",
                table: "Memberships",
                column: "clientID");

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_membershipTypeID",
                table: "Memberships",
                column: "membershipTypeID");

        }
    }
}

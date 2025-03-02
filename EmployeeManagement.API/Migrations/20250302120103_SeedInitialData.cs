using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportsToId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_ReportsToId",
                        column: x => x.ReportsToId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PinCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Designation", "FirstName", "LastName", "ReportsToId" },
                values: new object[] { 1, "Software Engineer", "Ramesh", "Kumar", null });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Area", "City", "EmployeeId", "PinCode" },
                values: new object[,]
                {
                    { 1, "Bandra", "Mumbai", 1, "400050" },
                    { 6, "Andheri", "Mumbai", 1, "400053" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Designation", "FirstName", "LastName", "ReportsToId" },
                values: new object[,]
                {
                    { 2, "Senior Developer", "Suresh", "Singh", 1 },
                    { 4, "QA Engineer", "Anjali", "Gupta", 1 }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Area", "City", "EmployeeId", "PinCode" },
                values: new object[,]
                {
                    { 2, "Connaught Place", "Delhi", 2, "110001" },
                    { 4, "Gachibowli", "Hyderabad", 4, "500032" },
                    { 7, "Saket", "Delhi", 2, "110017" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Designation", "FirstName", "LastName", "ReportsToId" },
                values: new object[] { 3, "Project Manager", "Priya", "Sharma", 2 });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Area", "City", "EmployeeId", "PinCode" },
                values: new object[,]
                {
                    { 3, "Koramangala", "Bangalore", 3, "560034" },
                    { 8, "Indiranagar", "Bangalore", 3, "560038" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Designation", "FirstName", "LastName", "ReportsToId" },
                values: new object[] { 5, "DevOps Engineer", "Rajesh", "Patel", 3 });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Area", "City", "EmployeeId", "PinCode" },
                values: new object[] { 5, "Hinjewadi", "Pune", 5, "411057" });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_EmployeeId",
                table: "Addresses",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ReportsToId",
                table: "Employees",
                column: "ReportsToId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace RazonPagesLessons.Servises.Migrations
{
    public partial class CodFirstSpGetEmployeeByID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create procedure CodFirstSpGetEmployeeByID
                                     @Id int
                                     as
                                     Begin
                                     Select * from Employees
                                     where Id = @Id
                                     End";

            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure CodFirstSpGetEmployeeByID";

            migrationBuilder.Sql(procedure);

        }
    }
}

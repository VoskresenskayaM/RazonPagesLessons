using Microsoft.EntityFrameworkCore.Migrations;

namespace RazonPagesLessons.Servises.Migrations
{
    public partial class AddNewEmploee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create procedure spAddNewEmploee
                                    @Name nvarchar(100),
                                    @Email nvarchar(100),
                                    @PhotoPath nvarchar(100),
                                    @Dept int
                                    as
                                    Begin 
                                        INSERT INTO Employees(Name, Email,PhotoPath,Department)
                                        VALUES (@Name,@Email,@PhotoPath, @Dept)
                                    End";

            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            string procedure = @"Drop procedure spAddNewEmploee";
            migrationBuilder.Sql(procedure);


        }
    }
}

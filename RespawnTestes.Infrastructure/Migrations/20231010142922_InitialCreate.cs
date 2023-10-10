using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RespawnTester.Infrastructure.Migrations;

public partial class InitialCreate : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Products",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                IsAvailable = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Products", x => x.Id);
            });

        migrationBuilder.Sql(@"INSERT INTO [dbo].[Products]
                   ([Id]
                   ,[Name]
                   ,[Description]
                   ,[Price]
                   ,[ExpirationDate]
                   ,[IsAvailable])
             VALUES
                   (NEWID()
                   ,N'OnModelCreating Test Product'
                   ,N'It''s a test'
                   ,13.11
                   ,'2099-12-31'
                   ,1)");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Products");
    }
}

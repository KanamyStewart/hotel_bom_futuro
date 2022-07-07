using Microsoft.EntityFrameworkCore.Migrations;

namespace aula_final.Migrations
{
    public partial class segundo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReservaId",
                table: "Despesas");

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "Despesas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quarto",
                table: "Despesas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "ValorTotal",
                table: "Despesas",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Despesas_ProdutoId",
                table: "Despesas",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Despesas_Produtos_ProdutoId",
                table: "Despesas",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Despesas_Produtos_ProdutoId",
                table: "Despesas");

            migrationBuilder.DropIndex(
                name: "IX_Despesas_ProdutoId",
                table: "Despesas");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Despesas");

            migrationBuilder.DropColumn(
                name: "Quarto",
                table: "Despesas");

            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "Despesas");

            migrationBuilder.AddColumn<int>(
                name: "ReservaId",
                table: "Despesas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

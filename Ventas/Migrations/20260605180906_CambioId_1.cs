using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ventas.Migrations
{
    /// <inheritdoc />
    public partial class CambioId_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProductoModel",
                newName: "Producto_Id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Pedido",
                newName: "Pedido_Id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "EstadoPedido",
                newName: "Estado_Id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DetallePedido",
                newName: "Detalle_Id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cliente",
                newName: "Cliente_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Producto_Id",
                table: "ProductoModel",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Pedido_Id",
                table: "Pedido",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Estado_Id",
                table: "EstadoPedido",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Detalle_Id",
                table: "DetallePedido",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Cliente_Id",
                table: "Cliente",
                newName: "Id");
        }
    }
}

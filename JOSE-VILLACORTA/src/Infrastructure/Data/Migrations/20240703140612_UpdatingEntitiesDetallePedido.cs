using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace xyzboutique.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingEntitiesDetallePedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Pedidos_PedidoId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_TipoProductos_TipoId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_UnidadesDeMedida_UnidadDeMedidaId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_PedidoId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "Productos");

            migrationBuilder.RenameColumn(
                name: "UnidadDeMedidaId",
                table: "Productos",
                newName: "IdUnidadesDeMedida");

            migrationBuilder.RenameColumn(
                name: "TipoId",
                table: "Productos",
                newName: "IdTipoProductos");

            migrationBuilder.RenameIndex(
                name: "IX_Productos_UnidadDeMedidaId",
                table: "Productos",
                newName: "IX_Productos_IdUnidadesDeMedida");

            migrationBuilder.RenameIndex(
                name: "IX_Productos_TipoId",
                table: "Productos",
                newName: "IX_Productos_IdTipoProductos");

            migrationBuilder.CreateTable(
                name: "DetallePedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoId = table.Column<int>(type: "int", nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: true),
                    PedidoId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallePedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetallePedidos_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DetallePedidos_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedidos_PedidoId",
                table: "DetallePedidos",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedidos_ProductoId",
                table: "DetallePedidos",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_TipoProductos_IdTipoProductos",
                table: "Productos",
                column: "IdTipoProductos",
                principalTable: "TipoProductos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_UnidadesDeMedida_IdUnidadesDeMedida",
                table: "Productos",
                column: "IdUnidadesDeMedida",
                principalTable: "UnidadesDeMedida",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_TipoProductos_IdTipoProductos",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_UnidadesDeMedida_IdUnidadesDeMedida",
                table: "Productos");

            migrationBuilder.DropTable(
                name: "DetallePedidos");

            migrationBuilder.RenameColumn(
                name: "IdUnidadesDeMedida",
                table: "Productos",
                newName: "UnidadDeMedidaId");

            migrationBuilder.RenameColumn(
                name: "IdTipoProductos",
                table: "Productos",
                newName: "TipoId");

            migrationBuilder.RenameIndex(
                name: "IX_Productos_IdUnidadesDeMedida",
                table: "Productos",
                newName: "IX_Productos_UnidadDeMedidaId");

            migrationBuilder.RenameIndex(
                name: "IX_Productos_IdTipoProductos",
                table: "Productos",
                newName: "IX_Productos_TipoId");

            migrationBuilder.AddColumn<int>(
                name: "PedidoId",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_PedidoId",
                table: "Productos",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Pedidos_PedidoId",
                table: "Productos",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_TipoProductos_TipoId",
                table: "Productos",
                column: "TipoId",
                principalTable: "TipoProductos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_UnidadesDeMedida_UnidadDeMedidaId",
                table: "Productos",
                column: "UnidadDeMedidaId",
                principalTable: "UnidadesDeMedida",
                principalColumn: "Id");
        }
    }
}

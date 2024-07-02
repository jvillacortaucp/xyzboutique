using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace xyzboutique.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoTrabajador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Puesto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoProductos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoProductos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnidadesDeMedida",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abreviatura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadesDeMedida", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroDePedido = table.Column<int>(type: "int", nullable: true),
                    FechaDePedido = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaDeRecepcion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaDeDespacho = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaDeEntrega = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VendedorId = table.Column<int>(type: "int", nullable: true),
                    RepartidorId = table.Column<int>(type: "int", nullable: true),
                    Estado = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Empleados_RepartidorId",
                        column: x => x.RepartidorId,
                        principalTable: "Empleados",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pedidos_Empleados_VendedorId",
                        column: x => x.VendedorId,
                        principalTable: "Empleados",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SKU = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoId = table.Column<int>(type: "int", nullable: true),
                    Etiquetas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<double>(type: "float", nullable: true),
                    UnidadDeMedidaId = table.Column<int>(type: "int", nullable: true),
                    PedidoId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Productos_TipoProductos_TipoId",
                        column: x => x.TipoId,
                        principalTable: "TipoProductos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Productos_UnidadesDeMedida_UnidadDeMedidaId",
                        column: x => x.UnidadDeMedidaId,
                        principalTable: "UnidadesDeMedida",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_RepartidorId",
                table: "Pedidos",
                column: "RepartidorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_VendedorId",
                table: "Pedidos",
                column: "VendedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_PedidoId",
                table: "Productos",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_TipoId",
                table: "Productos",
                column: "TipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_UnidadDeMedidaId",
                table: "Productos",
                column: "UnidadDeMedidaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "TipoProductos");

            migrationBuilder.DropTable(
                name: "UnidadesDeMedida");

            migrationBuilder.DropTable(
                name: "Empleados");
        }
    }
}

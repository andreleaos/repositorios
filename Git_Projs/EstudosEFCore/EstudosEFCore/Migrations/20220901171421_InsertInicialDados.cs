using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EstudosEFCore.Migrations
{
    public partial class InsertInicialDados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tbl_motor",
                columns: new[] { "motor_id", "ativo", "cnh", "nome", "validadeCNH" },
                values: new object[,]
                {
                    { "eb9c4fdc-992f-4e37-91e4-86d3e4e0a898", (sbyte)1, "45698765498", "Joao Marcos", new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "5f4edb07-a52a-41cc-ba0a-40c8a884197d", (sbyte)1, "6987589365", "Francisco Fernando", new DateTime(2024, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "tbl_veicl",
                columns: new[] { "veicl_id", "ano", "modelo", "placa" },
                values: new object[,]
                {
                    { "e18505b9-525a-454f-a945-2f952ca166a1", 2019, "Volvo FH 5540", "HDT3B58" },
                    { "bb473d85-7546-475e-a316-ed737ff029c4", 2018, "Scania R450", "DRG7T34" }
                });

            migrationBuilder.InsertData(
                table: "tbl_motr_veicl",
                columns: new[] { "veicl_id", "motor_id" },
                values: new object[] { "e18505b9-525a-454f-a945-2f952ca166a1", "eb9c4fdc-992f-4e37-91e4-86d3e4e0a898" });

            migrationBuilder.InsertData(
                table: "tbl_motr_veicl",
                columns: new[] { "veicl_id", "motor_id" },
                values: new object[] { "bb473d85-7546-475e-a316-ed737ff029c4", "5f4edb07-a52a-41cc-ba0a-40c8a884197d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tbl_motr_veicl",
                keyColumns: new[] { "veicl_id", "motor_id" },
                keyValues: new object[] { "bb473d85-7546-475e-a316-ed737ff029c4", "5f4edb07-a52a-41cc-ba0a-40c8a884197d" });

            migrationBuilder.DeleteData(
                table: "tbl_motr_veicl",
                keyColumns: new[] { "veicl_id", "motor_id" },
                keyValues: new object[] { "e18505b9-525a-454f-a945-2f952ca166a1", "eb9c4fdc-992f-4e37-91e4-86d3e4e0a898" });

            migrationBuilder.DeleteData(
                table: "tbl_motor",
                keyColumn: "motor_id",
                keyValue: "5f4edb07-a52a-41cc-ba0a-40c8a884197d");

            migrationBuilder.DeleteData(
                table: "tbl_motor",
                keyColumn: "motor_id",
                keyValue: "eb9c4fdc-992f-4e37-91e4-86d3e4e0a898");

            migrationBuilder.DeleteData(
                table: "tbl_veicl",
                keyColumn: "veicl_id",
                keyValue: "bb473d85-7546-475e-a316-ed737ff029c4");

            migrationBuilder.DeleteData(
                table: "tbl_veicl",
                keyColumn: "veicl_id",
                keyValue: "e18505b9-525a-454f-a945-2f952ca166a1");
        }
    }
}

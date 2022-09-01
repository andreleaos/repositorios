﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EstudosEFCore.Migrations
{
    public partial class ConfigDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_motor",
                columns: table => new
                {
                    motor_id = table.Column<string>(type: "varchar(50)", nullable: false),
                    nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    cnh = table.Column<string>(type: "varchar(50)", nullable: true),
                    validadeCNH = table.Column<DateTime>(type: "datetime", nullable: false),
                    ativo = table.Column<byte>(type: "tinyint", nullable: true, defaultValue: (byte)1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_motor", x => x.motor_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_veicl",
                columns: table => new
                {
                    veicl_id = table.Column<string>(type: "varchar(50)", nullable: false),
                    modelo = table.Column<string>(type: "varchar(100)", nullable: true),
                    placa = table.Column<string>(type: "varchar(20)", nullable: true),
                    ano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_veicl", x => x.veicl_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_motr_veicl",
                columns: table => new
                {
                    veicl_id = table.Column<string>(type: "varchar(50)", nullable: false),
                    motor_id = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_motr_veicl", x => new { x.veicl_id, x.motor_id });
                    table.ForeignKey(
                        name: "FK_tbl_motr_veicl_tbl_motor_motor_id",
                        column: x => x.motor_id,
                        principalTable: "tbl_motor",
                        principalColumn: "motor_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_motr_veicl_tbl_veicl_veicl_id",
                        column: x => x.veicl_id,
                        principalTable: "tbl_veicl",
                        principalColumn: "veicl_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_motr_veicl_motor_id",
                table: "tbl_motr_veicl",
                column: "motor_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_motr_veicl");

            migrationBuilder.DropTable(
                name: "tbl_motor");

            migrationBuilder.DropTable(
                name: "tbl_veicl");
        }
    }
}

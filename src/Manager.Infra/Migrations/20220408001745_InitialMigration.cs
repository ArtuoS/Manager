﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manager.Infra.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    EMAIL = table.Column<string>(type: "VARCHAR(180)", maxLength: 180, nullable: false),
                    PASSWORD = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
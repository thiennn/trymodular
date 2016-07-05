using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Modular.WebHost.Migrations
{
    public partial class AddSampleSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ModuleA_Sample",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ModuleA_Sample",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ModuleA_Sample");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ModuleA_Sample");
        }
    }
}

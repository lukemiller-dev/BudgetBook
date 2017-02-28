using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace newBudgetBook.Migrations
{
    public partial class fixSpent2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CurrentTotal",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Spent",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentTotal",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Spent",
                table: "AspNetUsers");
        }
    }
}

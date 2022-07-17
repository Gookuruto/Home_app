using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NodaTime;

#nullable disable

namespace Bill_api.Migrations
{
    public partial class ChangeSomeTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentPeriod",
                table: "BillProviders");

            migrationBuilder.RenameColumn(
                name: "BillId",
                table: "Bills",
                newName: "Id");

            migrationBuilder.AlterColumn<LocalDate>(
                name: "FirstPayment",
                table: "BillProviders",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<int>(
                name: "PaymentDays",
                table: "BillProviders",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentDays",
                table: "BillProviders");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Bills",
                newName: "BillId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FirstPayment",
                table: "BillProviders",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(LocalDate),
                oldType: "date");

            migrationBuilder.AddColumn<Duration>(
                name: "PaymentPeriod",
                table: "BillProviders",
                type: "interval",
                nullable: false,
                defaultValue: NodaTime.Duration.Zero);
        }
    }
}

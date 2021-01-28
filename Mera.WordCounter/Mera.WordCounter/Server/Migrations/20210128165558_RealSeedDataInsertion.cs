using Microsoft.EntityFrameworkCore.Migrations;

namespace Mera.WordCounter.Server.Migrations
{
    public partial class RealSeedDataInsertion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Texts",
                columns: new[] { "Id", "Content" },
                values: new object[,]
                {
                    { 1, "One morning, . ,  when Gregor Samsa woke" },
                    { 2, "from   troubled dreams, he found himself" },
                    { 3, "transformed in his bed into a    horrible vermin." },
                    { 4, "He lay on his" },
                    { 5, "armour-like back, and if he lifted his head a little he could see" },
                    { 6, "his brown, .  belly, slightly domed and ,,,, divided by" },
                    { 7, "arches into stiff sections." },
                    { 8, "The bedding .. was hardly    able to cover" },
                    { 9, "it and seemed" },
                    { 10, " ready to slide off any moment." }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Texts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Texts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Texts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Texts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Texts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Texts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Texts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Texts",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Texts",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Texts",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Airlines.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Рейсы",
                columns: table => new
                {
                    код_рейса = table.Column<int>(type: "INT", nullable: false),
                    дата = table.Column<int>(type: "INT", nullable: false),
                    время = table.Column<int>(type: "INT", nullable: false),
                    откуда = table.Column<int>(type: "INT", nullable: false),
                    куда = table.Column<int>(type: "INT", nullable: false),
                    код_экипажа = table.Column<int>(type: "INT", nullable: false),
                    код_самолёта = table.Column<int>(type: "INT", nullable: false),
                    время_полёта = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Рейсы", x => x.код_рейса);
                });

            migrationBuilder.CreateTable(
                name: "Типы_самолётов",
                columns: table => new
                {
                    код_типа = table.Column<int>(type: "INT", nullable: false),
                    наименование = table.Column<int>(type: "INT", nullable: false),
                    назначение = table.Column<int>(type: "INT", nullable: false),
                    ограничения = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Типы_самолётов", x => x.код_типа);
                });

            migrationBuilder.CreateTable(
                name: "Билеты",
                columns: table => new
                {
                    паспортные_данные = table.Column<int>(type: "INT", nullable: false),
                    место = table.Column<int>(type: "INT", nullable: false),
                    код_рейса = table.Column<int>(type: "INT", nullable: false),
                    цена = table.Column<int>(type: "INT", nullable: false),
                    ФИО_пассажира = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Билеты", x => x.паспортные_данные);
                    table.ForeignKey(
                        name: "FK_Билеты_Рейсы_код_рейса",
                        column: x => x.код_рейса,
                        principalTable: "Рейсы",
                        principalColumn: "код_рейса",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Самолёты",
                columns: table => new
                {
                    код_сотрудников = table.Column<int>(type: "INT", nullable: false),
                    код_самолёта = table.Column<int>(type: "INT", nullable: false),
                    марка = table.Column<int>(type: "INT", nullable: false),
                    вместимость = table.Column<int>(type: "INT", nullable: false),
                    грузоподъёмность = table.Column<int>(type: "INT", nullable: false),
                    код_типа = table.Column<int>(type: "INT", nullable: false),
                    технические_характиристики = table.Column<int>(type: "INT", nullable: false),
                    дата_выпуска = table.Column<int>(type: "INT", nullable: false),
                    налётано_часов = table.Column<int>(type: "INT", nullable: false),
                    дата_последнего_ремонта = table.Column<int>(type: "INT", nullable: false),
                    код_рейса = table.Column<int>(type: "INT", nullable: false),
                    паспортные_данные = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Самолёты", x => x.код_сотрудников);
                    table.ForeignKey(
                        name: "FK_Самолёты_Рейсы_код_рейса",
                        column: x => x.код_рейса,
                        principalTable: "Рейсы",
                        principalColumn: "код_рейса",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Самолёты_Типы_самолётов_код_типа",
                        column: x => x.код_типа,
                        principalTable: "Типы_самолётов",
                        principalColumn: "код_типа",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Самолёты_Билеты_паспортные_данные",
                        column: x => x.паспортные_данные,
                        principalTable: "Билеты",
                        principalColumn: "паспортные_данные",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Экипажи",
                columns: table => new
                {
                    код_экипажа = table.Column<int>(type: "INT", nullable: false),
                    налётано_часов = table.Column<int>(type: "INT", nullable: false),
                    код_сотрудника_1 = table.Column<int>(type: "INT", nullable: false),
                    код_сотрудника_2 = table.Column<int>(type: "INT", nullable: false),
                    код_сотрудника_3 = table.Column<int>(type: "INT", nullable: false),
                    паспортные_данные = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Экипажи", x => x.код_экипажа);
                    table.ForeignKey(
                        name: "FK_Экипажи_Самолёты_код_сотрудника_1",
                        column: x => x.код_сотрудника_1,
                        principalTable: "Самолёты",
                        principalColumn: "код_сотрудников",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Экипажи_Самолёты_код_сотрудника_2",
                        column: x => x.код_сотрудника_2,
                        principalTable: "Самолёты",
                        principalColumn: "код_сотрудников",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Экипажи_Самолёты_код_сотрудника_3",
                        column: x => x.код_сотрудника_3,
                        principalTable: "Самолёты",
                        principalColumn: "код_сотрудников",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Экипажи_Билеты_паспортные_данные",
                        column: x => x.паспортные_данные,
                        principalTable: "Билеты",
                        principalColumn: "паспортные_данные",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Должности",
                columns: table => new
                {
                    код_должности = table.Column<int>(type: "INT", nullable: false),
                    наименование_должности = table.Column<int>(type: "INT", nullable: false),
                    оклад = table.Column<int>(type: "INT", nullable: false),
                    обязанности = table.Column<int>(type: "INT", nullable: false),
                    требования = table.Column<int>(type: "INT", nullable: false),
                    код_экипажа = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Должности", x => x.код_должности);
                    table.ForeignKey(
                        name: "FK_Должности_Экипажи_код_экипажа",
                        column: x => x.код_экипажа,
                        principalTable: "Экипажи",
                        principalColumn: "код_экипажа",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Сотрудники",
                columns: table => new
                {
                    код_сотрудников = table.Column<int>(type: "INT", nullable: false),
                    код_должности = table.Column<int>(type: "INT", nullable: false),
                    ФИО = table.Column<int>(type: "INT", nullable: false),
                    возраст = table.Column<int>(type: "INT", nullable: false),
                    пол = table.Column<int>(type: "INT", nullable: false),
                    адрес = table.Column<int>(type: "INT", nullable: false),
                    телефон = table.Column<int>(type: "INT", nullable: false),
                    паспортные_данные = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Сотрудники", x => x.код_сотрудников);
                    table.ForeignKey(
                        name: "FK_Сотрудники_Должности_код_должности",
                        column: x => x.код_должности,
                        principalTable: "Должности",
                        principalColumn: "код_должности",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Билеты_код_рейса",
                table: "Билеты",
                column: "код_рейса",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Должности_код_экипажа",
                table: "Должности",
                column: "код_экипажа");

            migrationBuilder.CreateIndex(
                name: "IX_Рейсы_код_экипажа",
                table: "Рейсы",
                column: "код_экипажа",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Самолёты_код_рейса",
                table: "Самолёты",
                column: "код_рейса");

            migrationBuilder.CreateIndex(
                name: "IX_Самолёты_код_самолёта",
                table: "Самолёты",
                column: "код_самолёта",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Самолёты_код_типа",
                table: "Самолёты",
                column: "код_типа",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Самолёты_паспортные_данные",
                table: "Самолёты",
                column: "паспортные_данные");

            migrationBuilder.CreateIndex(
                name: "IX_Сотрудники_код_должности",
                table: "Сотрудники",
                column: "код_должности");

            migrationBuilder.CreateIndex(
                name: "IX_Сотрудники_паспортные_данные",
                table: "Сотрудники",
                column: "паспортные_данные",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Экипажи_код_сотрудника_1",
                table: "Экипажи",
                column: "код_сотрудника_1");

            migrationBuilder.CreateIndex(
                name: "IX_Экипажи_код_сотрудника_2",
                table: "Экипажи",
                column: "код_сотрудника_2");

            migrationBuilder.CreateIndex(
                name: "IX_Экипажи_код_сотрудника_3",
                table: "Экипажи",
                column: "код_сотрудника_3");

            migrationBuilder.CreateIndex(
                name: "IX_Экипажи_паспортные_данные",
                table: "Экипажи",
                column: "паспортные_данные");

            migrationBuilder.AddForeignKey(
                name: "FK_Самолёты_Сотрудники_код_сотрудников",
                table: "Самолёты",
                column: "код_сотрудников",
                principalTable: "Сотрудники",
                principalColumn: "код_сотрудников",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Билеты_Рейсы_код_рейса",
                table: "Билеты");

            migrationBuilder.DropForeignKey(
                name: "FK_Самолёты_Рейсы_код_рейса",
                table: "Самолёты");

            migrationBuilder.DropForeignKey(
                name: "FK_Должности_Экипажи_код_экипажа",
                table: "Должности");

            migrationBuilder.DropTable(
                name: "Рейсы");

            migrationBuilder.DropTable(
                name: "Экипажи");

            migrationBuilder.DropTable(
                name: "Самолёты");

            migrationBuilder.DropTable(
                name: "Сотрудники");

            migrationBuilder.DropTable(
                name: "Типы_самолётов");

            migrationBuilder.DropTable(
                name: "Билеты");

            migrationBuilder.DropTable(
                name: "Должности");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KargoTakibi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    KullaniciID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.KullaniciID);
                });

            migrationBuilder.CreateTable(
                name: "Kargolar",
                columns: table => new
                {
                    KargoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GondericiAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GondericiIl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GondericiIlce = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GondericiAdresi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GondericiTelefonu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AliciAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AliciIl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AliciIlce = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AliciAdresi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AliciTelefonu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Durum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullaniciID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kargolar", x => x.KargoID);
                    table.ForeignKey(
                        name: "FK_Kargolar_Kullanicilar_KullaniciID",
                        column: x => x.KullaniciID,
                        principalTable: "Kullanicilar",
                        principalColumn: "KullaniciID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hareketler",
                columns: table => new
                {
                    HareketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KargoID = table.Column<int>(type: "int", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Durum = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hareketler", x => x.HareketID);
                    table.ForeignKey(
                        name: "FK_Hareketler_Kargolar_KargoID",
                        column: x => x.KargoID,
                        principalTable: "Kargolar",
                        principalColumn: "KargoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hareketler_KargoID",
                table: "Hareketler",
                column: "KargoID");

            migrationBuilder.CreateIndex(
                name: "IX_Kargolar_KullaniciID",
                table: "Kargolar",
                column: "KullaniciID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hareketler");

            migrationBuilder.DropTable(
                name: "Kargolar");

            migrationBuilder.DropTable(
                name: "Kullanicilar");
        }
    }
}

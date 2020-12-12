using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class QuanLyCuaHang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KhuyenMais",
                columns: table => new
                {
                    ID_KM = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phan_Tram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link_Anh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mo_ta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuyenMais", x => x.ID_KM);
                });

            migrationBuilder.CreateTable(
                name: "TheoDois",
                columns: table => new
                {
                    ID_TheoDoi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheoDois", x => x.ID_TheoDoi);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID_User = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<bool>(type: "bit", nullable: false),
                    Coin = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID_User);
                });

            migrationBuilder.CreateTable(
                name: "ThucPhams",
                columns: table => new
                {
                    ID_ThucPham = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiThucPham = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_KM = table.Column<int>(type: "int", nullable: false),
                    GiaGoc = table.Column<int>(type: "int", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link_Anh = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThucPhams", x => x.ID_ThucPham);
                    table.ForeignKey(
                        name: "FK_ThucPhams_KhuyenMais_ID_KM",
                        column: x => x.ID_KM,
                        principalTable: "KhuyenMais",
                        principalColumn: "ID_KM",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DonHangs",
                columns: table => new
                {
                    ID_DonHang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PTThanhToan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TongTien = table.Column<int>(type: "int", nullable: false),
                    ID_User = table.Column<int>(type: "int", nullable: false),
                    NgayThang = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHangs", x => x.ID_DonHang);
                    table.ForeignKey(
                        name: "FK_DonHangs_Users_ID_User",
                        column: x => x.ID_User,
                        principalTable: "Users",
                        principalColumn: "ID_User",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KhoHangs",
                columns: table => new
                {
                    ID_KhoHang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_ThucPham = table.Column<int>(type: "int", nullable: false),
                    TenThucPham = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhoHangs", x => x.ID_KhoHang);
                    table.ForeignKey(
                        name: "FK_KhoHangs_ThucPhams_ID_ThucPham",
                        column: x => x.ID_ThucPham,
                        principalTable: "ThucPhams",
                        principalColumn: "ID_ThucPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhapXuats",
                columns: table => new
                {
                    ID_NhapXuat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_ThucPham = table.Column<int>(type: "int", nullable: false),
                    So_Luong = table.Column<int>(type: "int", nullable: false),
                    Nhap_Xuat = table.Column<bool>(type: "bit", nullable: false),
                    NgayNX = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhapXuats", x => x.ID_NhapXuat);
                    table.ForeignKey(
                        name: "FK_NhapXuats_ThucPhams_ID_ThucPham",
                        column: x => x.ID_ThucPham,
                        principalTable: "ThucPhams",
                        principalColumn: "ID_ThucPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDonHangs",
                columns: table => new
                {
                    ID_ChiTiet = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_DonHang = table.Column<int>(type: "int", nullable: false),
                    ID_ThucPham = table.Column<int>(type: "int", nullable: false),
                    TenThucPham = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    So_Luong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDonHangs", x => x.ID_ChiTiet);
                    table.ForeignKey(
                        name: "FK_ChiTietDonHangs_DonHangs_ID_DonHang",
                        column: x => x.ID_DonHang,
                        principalTable: "DonHangs",
                        principalColumn: "ID_DonHang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietDonHangs_ThucPhams_ID_ThucPham",
                        column: x => x.ID_ThucPham,
                        principalTable: "ThucPhams",
                        principalColumn: "ID_ThucPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonHangs_ID_DonHang",
                table: "ChiTietDonHangs",
                column: "ID_DonHang");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonHangs_ID_ThucPham",
                table: "ChiTietDonHangs",
                column: "ID_ThucPham");

            migrationBuilder.CreateIndex(
                name: "IX_DonHangs_ID_User",
                table: "DonHangs",
                column: "ID_User");

            migrationBuilder.CreateIndex(
                name: "IX_KhoHangs_ID_ThucPham",
                table: "KhoHangs",
                column: "ID_ThucPham");

            migrationBuilder.CreateIndex(
                name: "IX_NhapXuats_ID_ThucPham",
                table: "NhapXuats",
                column: "ID_ThucPham");

            migrationBuilder.CreateIndex(
                name: "IX_ThucPhams_ID_KM",
                table: "ThucPhams",
                column: "ID_KM");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true,
                filter: "[Username] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietDonHangs");

            migrationBuilder.DropTable(
                name: "KhoHangs");

            migrationBuilder.DropTable(
                name: "NhapXuats");

            migrationBuilder.DropTable(
                name: "TheoDois");

            migrationBuilder.DropTable(
                name: "DonHangs");

            migrationBuilder.DropTable(
                name: "ThucPhams");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "KhuyenMais");
        }
    }
}

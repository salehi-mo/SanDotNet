using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobManagement.Infrastructure.EFCore.Migrations
{
    public partial class Init_NewJobDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonEshtegVazs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    PersonEshtegVazId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(maxLength: 500, nullable: false),
                    Slug = table.Column<string>(maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonEshtegVazs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonOzvNoas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    PersonOzvNoaId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(maxLength: 500, nullable: false),
                    Slug = table.Column<string>(maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonOzvNoas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Qorbs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    QorbId_sana = table.Column<long>(nullable: false),
                    Name = table.Column<string>(maxLength: 500, nullable: false),
                    Slug = table.Column<string>(maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qorbs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QorbMoass",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    QorbMoasId_sana = table.Column<long>(nullable: false),
                    Name = table.Column<string>(maxLength: 500, nullable: false),
                    Slug = table.Column<string>(maxLength: 300, nullable: false),
                    QorbId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QorbMoass", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QorbMoass_Qorbs_QorbId",
                        column: x => x.QorbId,
                        principalTable: "Qorbs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QorbMoasPors",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    QorbMoasPorId_sana = table.Column<long>(nullable: false),
                    Name = table.Column<string>(maxLength: 500, nullable: false),
                    Slug = table.Column<string>(maxLength: 300, nullable: false),
                    QorbMoasId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QorbMoasPors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QorbMoasPors_QorbMoass_QorbMoasId",
                        column: x => x.QorbMoasId,
                        principalTable: "QorbMoass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QorbMoasPorKars",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    QorbMoasPorKarId_sana = table.Column<long>(nullable: false),
                    Name = table.Column<string>(maxLength: 500, nullable: false),
                    Slug = table.Column<string>(maxLength: 300, nullable: false),
                    QorbMoasPorId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QorbMoasPorKars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QorbMoasPorKars_QorbMoasPors_QorbMoasPorId",
                        column: x => x.QorbMoasPorId,
                        principalTable: "QorbMoasPors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    PerId = table.Column<long>(nullable: false),
                    Nam = table.Column<string>(maxLength: 500, nullable: false),
                    Fam = table.Column<string>(maxLength: 500, nullable: false),
                    NamPed = table.Column<string>(maxLength: 500, nullable: false),
                    NoShe = table.Column<string>(maxLength: 500, nullable: false),
                    CodMelli = table.Column<string>(maxLength: 500, nullable: false),
                    Slug = table.Column<string>(maxLength: 300, nullable: false),
                    PersonOzvNoaId = table.Column<long>(nullable: true),
                    PersonEshtegVazId = table.Column<long>(nullable: true),
                    QorbId = table.Column<long>(nullable: true),
                    QorbMoasId = table.Column<long>(nullable: true),
                    QorbMoasPorId = table.Column<long>(nullable: true),
                    QorbMoasPorKarId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_PersonEshtegVazs_PersonEshtegVazId",
                        column: x => x.PersonEshtegVazId,
                        principalTable: "PersonEshtegVazs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persons_PersonOzvNoas_PersonOzvNoaId",
                        column: x => x.PersonOzvNoaId,
                        principalTable: "PersonOzvNoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persons_Qorbs_QorbId",
                        column: x => x.QorbId,
                        principalTable: "Qorbs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persons_QorbMoass_QorbMoasId",
                        column: x => x.QorbMoasId,
                        principalTable: "QorbMoass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persons_QorbMoasPors_QorbMoasPorId",
                        column: x => x.QorbMoasPorId,
                        principalTable: "QorbMoasPors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persons_QorbMoasPorKars_QorbMoasPorKarId",
                        column: x => x.QorbMoasPorKarId,
                        principalTable: "QorbMoasPorKars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PersonEshtegVazId",
                table: "Persons",
                column: "PersonEshtegVazId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PersonOzvNoaId",
                table: "Persons",
                column: "PersonOzvNoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_QorbId",
                table: "Persons",
                column: "QorbId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_QorbMoasId",
                table: "Persons",
                column: "QorbMoasId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_QorbMoasPorId",
                table: "Persons",
                column: "QorbMoasPorId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_QorbMoasPorKarId",
                table: "Persons",
                column: "QorbMoasPorKarId");

            migrationBuilder.CreateIndex(
                name: "IX_QorbMoasPorKars_QorbMoasPorId",
                table: "QorbMoasPorKars",
                column: "QorbMoasPorId");

            migrationBuilder.CreateIndex(
                name: "IX_QorbMoasPors_QorbMoasId",
                table: "QorbMoasPors",
                column: "QorbMoasId");

            migrationBuilder.CreateIndex(
                name: "IX_QorbMoass_QorbId",
                table: "QorbMoass",
                column: "QorbId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "PersonEshtegVazs");

            migrationBuilder.DropTable(
                name: "PersonOzvNoas");

            migrationBuilder.DropTable(
                name: "QorbMoasPorKars");

            migrationBuilder.DropTable(
                name: "QorbMoasPors");

            migrationBuilder.DropTable(
                name: "QorbMoass");

            migrationBuilder.DropTable(
                name: "Qorbs");
        }
    }
}

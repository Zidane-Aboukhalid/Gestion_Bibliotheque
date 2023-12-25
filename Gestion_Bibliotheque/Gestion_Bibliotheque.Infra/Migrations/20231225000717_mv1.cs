using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Gestion_Bibliotheque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class mv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    UtilisateurId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nom = table.Column<string>(type: "TEXT", nullable: false),
                    Prenom = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    Ecol = table.Column<string>(type: "TEXT", nullable: false),
                    Adresse = table.Column<string>(type: "TEXT", nullable: false),
                    JobInTech = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.UtilisateurId);
                });

            migrationBuilder.CreateTable(
                name: "RoleUtilisateur",
                columns: table => new
                {
                    RolesRoleId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UtilisateurId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUtilisateur", x => new { x.RolesRoleId, x.UtilisateurId });
                    table.ForeignKey(
                        name: "FK_RoleUtilisateur_Roles_RolesRoleId",
                        column: x => x.RolesRoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUtilisateur_Utilisateurs_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "UtilisateurId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateur_Roles",
                columns: table => new
                {
                    Utilisateur_RoleId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoleId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UtilisateurId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateur_Roles", x => x.Utilisateur_RoleId);
                    table.ForeignKey(
                        name: "FK_Utilisateur_Roles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Utilisateur_Roles_Utilisateurs_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "UtilisateurId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Name" },
                values: new object[,]
                {
                    { new Guid("0f1072d5-e635-4cec-9d36-7c0aed643df7"), "Etudiant" },
                    { new Guid("1d464c95-93f7-458a-84ed-b8ff32cc841f"), "Etudiant_VIP" },
                    { new Guid("54f31f1d-38ff-462e-861d-49ece7862c17"), "Etudiant_Bronze" },
                    { new Guid("7b398a20-6dae-4311-a78e-9fea5e7c4d00"), "Administrateur" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleUtilisateur_UtilisateurId",
                table: "RoleUtilisateur",
                column: "UtilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateur_Roles_RoleId",
                table: "Utilisateur_Roles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateur_Roles_UtilisateurId",
                table: "Utilisateur_Roles",
                column: "UtilisateurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleUtilisateur");

            migrationBuilder.DropTable(
                name: "Utilisateur_Roles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Utilisateurs");
        }
    }
}

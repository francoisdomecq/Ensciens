using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ensciens.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Famille",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreEleves = table.Column<int>(type: "INTEGER", nullable: false),
                    Points = table.Column<int>(type: "INTEGER", nullable: false),
                    Couleur = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Famille", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publicateur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: true),
                    Prenom = table.Column<string>(type: "TEXT", nullable: true),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    MotDePasse = table.Column<string>(type: "TEXT", nullable: true),
                    PhotoProfil = table.Column<string>(type: "TEXT", nullable: true),
                    Promotion = table.Column<string>(type: "TEXT", nullable: true),
                    FamilleId = table.Column<int>(type: "INTEGER", nullable: true),
                    Bureau_Logo = table.Column<string>(type: "TEXT", nullable: true),
                    Bureau_Description = table.Column<string>(type: "TEXT", nullable: true),
                    Logo = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    BureauId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicateur", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publicateur_Famille_FamilleId",
                        column: x => x.FamilleId,
                        principalTable: "Famille",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Publicateur_Publicateur_BureauId",
                        column: x => x.BureauId,
                        principalTable: "Publicateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Evenement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Lieu = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OrganisateurId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evenement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evenement_Publicateur_OrganisateurId",
                        column: x => x.OrganisateurId,
                        principalTable: "Publicateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lien Bureaux Eleve",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Role = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    EleveId = table.Column<int>(type: "INTEGER", nullable: false),
                    BureauId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lien Bureaux Eleve", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lien Bureaux Eleve_Publicateur_BureauId",
                        column: x => x.BureauId,
                        principalTable: "Publicateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lien Bureaux Eleve_Publicateur_EleveId",
                        column: x => x.EleveId,
                        principalTable: "Publicateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lien Club Eleve",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Role = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    EleveId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClubId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lien Club Eleve", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lien Club Eleve_Publicateur_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Publicateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lien Club Eleve_Publicateur_EleveId",
                        column: x => x.EleveId,
                        principalTable: "Publicateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Publication",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Contenu = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    DatePublication = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Medias = table.Column<string>(type: "TEXT", nullable: true),
                    EvenementId = table.Column<int>(type: "INTEGER", nullable: true),
                    PublicateurId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publication", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publication_Evenement_EvenementId",
                        column: x => x.EvenementId,
                        principalTable: "Evenement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Publication_Publicateur_PublicateurId",
                        column: x => x.PublicateurId,
                        principalTable: "Publicateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commentaires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Contenu = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    DateEnvoi = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PublicateurId = table.Column<int>(type: "INTEGER", nullable: false),
                    PublicationId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commentaires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commentaires_Publicateur_PublicateurId",
                        column: x => x.PublicateurId,
                        principalTable: "Publicateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commentaires_Publication_PublicationId",
                        column: x => x.PublicationId,
                        principalTable: "Publication",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commentaires_PublicateurId",
                table: "Commentaires",
                column: "PublicateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Commentaires_PublicationId",
                table: "Commentaires",
                column: "PublicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Evenement_OrganisateurId",
                table: "Evenement",
                column: "OrganisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Lien Bureaux Eleve_BureauId",
                table: "Lien Bureaux Eleve",
                column: "BureauId");

            migrationBuilder.CreateIndex(
                name: "IX_Lien Bureaux Eleve_EleveId",
                table: "Lien Bureaux Eleve",
                column: "EleveId");

            migrationBuilder.CreateIndex(
                name: "IX_Lien Club Eleve_ClubId",
                table: "Lien Club Eleve",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Lien Club Eleve_EleveId",
                table: "Lien Club Eleve",
                column: "EleveId");

            migrationBuilder.CreateIndex(
                name: "IX_Publicateur_BureauId",
                table: "Publicateur",
                column: "BureauId");

            migrationBuilder.CreateIndex(
                name: "IX_Publicateur_FamilleId",
                table: "Publicateur",
                column: "FamilleId");

            migrationBuilder.CreateIndex(
                name: "IX_Publication_EvenementId",
                table: "Publication",
                column: "EvenementId");

            migrationBuilder.CreateIndex(
                name: "IX_Publication_PublicateurId",
                table: "Publication",
                column: "PublicateurId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commentaires");

            migrationBuilder.DropTable(
                name: "Lien Bureaux Eleve");

            migrationBuilder.DropTable(
                name: "Lien Club Eleve");

            migrationBuilder.DropTable(
                name: "Publication");

            migrationBuilder.DropTable(
                name: "Evenement");

            migrationBuilder.DropTable(
                name: "Publicateur");

            migrationBuilder.DropTable(
                name: "Famille");
        }
    }
}

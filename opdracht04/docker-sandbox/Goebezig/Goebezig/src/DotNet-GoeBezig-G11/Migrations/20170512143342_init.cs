using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DotNetGoeBezigG11.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groeps",
                columns: table => new
                {
                    GroepId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<string>(maxLength: 50, nullable: false),
                    Open = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groeps", x => x.GroepId);
                });

            migrationBuilder.CreateTable(
                name: "Locaties",
                columns: table => new
                {
                    LocatieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Land = table.Column<string>(maxLength: 50, nullable: false),
                    Nummer = table.Column<int>(nullable: false),
                    Postcode = table.Column<int>(nullable: false),
                    Stad = table.Column<string>(maxLength: 100, nullable: false),
                    Straat = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locaties", x => x.LocatieId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActieContainers",
                columns: table => new
                {
                    ContainerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Beoordeeld = table.Column<bool>(nullable: false),
                    GroepId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActieContainers", x => x.ContainerId);
                    table.ForeignKey(
                        name: "FK_ActieContainers_Groeps_GroepId",
                        column: x => x.GroepId,
                        principalTable: "Groeps",
                        principalColumn: "GroepId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CurrentState",
                columns: table => new
                {
                    CurrentStateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Currentstate = table.Column<string>(nullable: false),
                    ForeignKeyGroep = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentState", x => x.CurrentStateId);
                    table.ForeignKey(
                        name: "FK_CurrentState_Groeps_ForeignKeyGroep",
                        column: x => x.ForeignKeyGroep,
                        principalTable: "Groeps",
                        principalColumn: "GroepId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Organisaties",
                columns: table => new
                {
                    OrganisatieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Discriminator = table.Column<string>(nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    HeeftLabel = table.Column<bool>(nullable: false),
                    LocatieId = table.Column<int>(nullable: true),
                    Naam = table.Column<string>(maxLength: 100, nullable: false),
                    Type = table.Column<string>(nullable: true),
                    IsOpen = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisaties", x => x.OrganisatieId);
                    table.ForeignKey(
                        name: "FK_Organisaties_Locaties_LocatieId",
                        column: x => x.LocatieId,
                        principalTable: "Locaties",
                        principalColumn: "LocatieId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Acties",
                columns: table => new
                {
                    ActieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActieContainerContainerId = table.Column<int>(nullable: true),
                    BerichtAangemaakt = table.Column<bool>(nullable: false),
                    Datum = table.Column<DateTime>(nullable: true),
                    Goedgekeurd = table.Column<bool>(nullable: false),
                    Omschrijving = table.Column<string>(nullable: true),
                    Titel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acties", x => x.ActieId);
                    table.ForeignKey(
                        name: "FK_Acties_ActieContainers_ActieContainerContainerId",
                        column: x => x.ActieContainerContainerId,
                        principalTable: "ActieContainers",
                        principalColumn: "ContainerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Motivaties",
                columns: table => new
                {
                    MotivatieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BerichtAangemaakt = table.Column<bool>(nullable: false),
                    DatumIngediend = table.Column<DateTime>(nullable: false),
                    Feedback = table.Column<string>(nullable: true),
                    Goedgekeurd = table.Column<bool>(nullable: false),
                    GroepId = table.Column<int>(nullable: true),
                    Inhoud = table.Column<string>(nullable: true),
                    OrganisatieId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motivaties", x => x.MotivatieId);
                    table.ForeignKey(
                        name: "FK_Motivaties_Groeps_GroepId",
                        column: x => x.GroepId,
                        principalTable: "Groeps",
                        principalColumn: "GroepId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Motivaties_Organisaties_OrganisatieId",
                        column: x => x.OrganisatieId,
                        principalTable: "Organisaties",
                        principalColumn: "OrganisatieId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Discriminator = table.Column<string>(nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Naam = table.Column<string>(maxLength: 50, nullable: false),
                    Voornaam = table.Column<string>(maxLength: 50, nullable: false),
                    GroepId = table.Column<int>(nullable: true),
                    LectorUserId = table.Column<int>(nullable: true),
                    SchoolOrganisatieId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_Groeps_GroepId",
                        column: x => x.GroepId,
                        principalTable: "Groeps",
                        principalColumn: "GroepId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_User_User_LectorUserId",
                        column: x => x.LectorUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Organisaties_SchoolOrganisatieId",
                        column: x => x.SchoolOrganisatieId,
                        principalTable: "Organisaties",
                        principalColumn: "OrganisatieId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Taken",
                columns: table => new
                {
                    TaakId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActieId = table.Column<int>(nullable: true),
                    Bijsturing = table.Column<string>(nullable: true),
                    DatumCreatie = table.Column<DateTime>(nullable: false),
                    DatumWijziging = table.Column<DateTime>(nullable: false),
                    Feedback = table.Column<string>(nullable: true),
                    NiveauVanRealisatie = table.Column<int>(nullable: false),
                    Tot = table.Column<DateTime>(nullable: true),
                    Van = table.Column<DateTime>(nullable: true),
                    Wat = table.Column<string>(nullable: true),
                    Wie = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taken", x => x.TaakId);
                    table.ForeignKey(
                        name: "FK_Taken_Acties_ActieId",
                        column: x => x.ActieId,
                        principalTable: "Acties",
                        principalColumn: "ActieId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Berichten",
                columns: table => new
                {
                    BerichtId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Aankondiging = table.Column<string>(nullable: true),
                    ActieId = table.Column<int>(nullable: true),
                    MotivatieId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Berichten", x => x.BerichtId);
                    table.ForeignKey(
                        name: "FK_Berichten_Acties_ActieId",
                        column: x => x.ActieId,
                        principalTable: "Acties",
                        principalColumn: "ActieId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Berichten_Motivaties_MotivatieId",
                        column: x => x.MotivatieId,
                        principalTable: "Motivaties",
                        principalColumn: "MotivatieId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contactpersoon",
                columns: table => new
                {
                    ContactpersoonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AanspreekTitel = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Functie = table.Column<string>(nullable: true),
                    MotivatieId = table.Column<int>(nullable: true),
                    Naam = table.Column<string>(nullable: true),
                    OrganisatieId = table.Column<int>(nullable: true),
                    TelefoonNummer = table.Column<string>(nullable: true),
                    Voornaam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contactpersoon", x => x.ContactpersoonId);
                    table.ForeignKey(
                        name: "FK_Contactpersoon_Motivaties_MotivatieId",
                        column: x => x.MotivatieId,
                        principalTable: "Motivaties",
                        principalColumn: "MotivatieId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contactpersoon_Organisaties_OrganisatieId",
                        column: x => x.OrganisatieId,
                        principalTable: "Organisaties",
                        principalColumn: "OrganisatieId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Melding",
                columns: table => new
                {
                    MeldingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(nullable: false),
                    FromUserUserId = table.Column<int>(nullable: true),
                    Gelezen = table.Column<bool>(nullable: false),
                    GroepNaam = table.Column<string>(nullable: true),
                    Inhoud = table.Column<string>(nullable: true),
                    ToUserUserId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Melding", x => x.MeldingId);
                    table.ForeignKey(
                        name: "FK_Melding_User_FromUserUserId",
                        column: x => x.FromUserUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Melding_User_ToUserUserId",
                        column: x => x.ToUserUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Melding_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Acties_ActieContainerContainerId",
                table: "Acties",
                column: "ActieContainerContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_ActieContainers_GroepId",
                table: "ActieContainers",
                column: "GroepId");

            migrationBuilder.CreateIndex(
                name: "IX_Berichten_ActieId",
                table: "Berichten",
                column: "ActieId");

            migrationBuilder.CreateIndex(
                name: "IX_Berichten_MotivatieId",
                table: "Berichten",
                column: "MotivatieId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contactpersoon_MotivatieId",
                table: "Contactpersoon",
                column: "MotivatieId");

            migrationBuilder.CreateIndex(
                name: "IX_Contactpersoon_OrganisatieId",
                table: "Contactpersoon",
                column: "OrganisatieId");

            migrationBuilder.CreateIndex(
                name: "IX_Melding_FromUserUserId",
                table: "Melding",
                column: "FromUserUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Melding_ToUserUserId",
                table: "Melding",
                column: "ToUserUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Melding_UserId",
                table: "Melding",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Motivaties_GroepId",
                table: "Motivaties",
                column: "GroepId");

            migrationBuilder.CreateIndex(
                name: "IX_Motivaties_OrganisatieId",
                table: "Motivaties",
                column: "OrganisatieId");

            migrationBuilder.CreateIndex(
                name: "IX_Organisaties_LocatieId",
                table: "Organisaties",
                column: "LocatieId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentState_ForeignKeyGroep",
                table: "CurrentState",
                column: "ForeignKeyGroep",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Taken_ActieId",
                table: "Taken",
                column: "ActieId");

            migrationBuilder.CreateIndex(
                name: "IX_User_GroepId",
                table: "User",
                column: "GroepId");

            migrationBuilder.CreateIndex(
                name: "IX_User_LectorUserId",
                table: "User",
                column: "LectorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_SchoolOrganisatieId",
                table: "User",
                column: "SchoolOrganisatieId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Berichten");

            migrationBuilder.DropTable(
                name: "Contactpersoon");

            migrationBuilder.DropTable(
                name: "Melding");

            migrationBuilder.DropTable(
                name: "CurrentState");

            migrationBuilder.DropTable(
                name: "Taken");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Motivaties");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Acties");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Organisaties");

            migrationBuilder.DropTable(
                name: "ActieContainers");

            migrationBuilder.DropTable(
                name: "Locaties");

            migrationBuilder.DropTable(
                name: "Groeps");
        }
    }
}

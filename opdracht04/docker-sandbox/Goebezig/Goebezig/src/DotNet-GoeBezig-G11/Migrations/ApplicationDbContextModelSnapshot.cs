using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DotNet_GoeBezig_G11.Data;

namespace DotNetGoeBezigG11.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DotNet_GoeBezig_G11.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("DotNet_GoeBezig_G11.Models.Domein.Actie", b =>
                {
                    b.Property<int>("ActieId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ActieContainerContainerId");

                    b.Property<bool>("BerichtAangemaakt");

                    b.Property<DateTime?>("Datum");

                    b.Property<bool>("Goedgekeurd");

                    b.Property<string>("Omschrijving");

                    b.Property<string>("Titel");

                    b.HasKey("ActieId");

                    b.HasIndex("ActieContainerContainerId");

                    b.ToTable("Acties");
                });

            modelBuilder.Entity("DotNet_GoeBezig_G11.Models.Domein.ActieContainer", b =>
                {
                    b.Property<int>("ContainerId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Beoordeeld");

                    b.Property<int?>("GroepId");

                    b.HasKey("ContainerId");

                    b.HasIndex("GroepId");

                    b.ToTable("ActieContainers");
                });

            modelBuilder.Entity("DotNet_GoeBezig_G11.Models.Domein.Bericht", b =>
                {
                    b.Property<int>("BerichtId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Aankondiging");

                    b.Property<int?>("ActieId");

                    b.Property<int?>("MotivatieId");

                    b.HasKey("BerichtId");

                    b.HasIndex("ActieId");

                    b.HasIndex("MotivatieId")
                        .IsUnique();

                    b.ToTable("Berichten");
                });

            modelBuilder.Entity("DotNet_GoeBezig_G11.Models.Domein.Contactpersoon", b =>
                {
                    b.Property<int>("ContactpersoonId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AanspreekTitel");

                    b.Property<string>("Email");

                    b.Property<string>("Functie");

                    b.Property<int?>("MotivatieId");

                    b.Property<string>("Naam");

                    b.Property<int?>("OrganisatieId");

                    b.Property<string>("TelefoonNummer");

                    b.Property<string>("Voornaam");

                    b.HasKey("ContactpersoonId");

                    b.HasIndex("MotivatieId");

                    b.HasIndex("OrganisatieId");

                    b.ToTable("Contactpersoon");
                });

            modelBuilder.Entity("DotNet_GoeBezig_G11.Models.Domein.Groep", b =>
                {
                    b.Property<int>("GroepId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<bool>("Open");

                    b.HasKey("GroepId");

                    b.ToTable("Groeps");
                });

            modelBuilder.Entity("DotNet_GoeBezig_G11.Models.Domein.Locatie", b =>
                {
                    b.Property<int>("LocatieId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Land")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<int>("Nummer");

                    b.Property<int>("Postcode");

                    b.Property<string>("Stad")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("Straat")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("LocatieId");

                    b.ToTable("Locaties");
                });

            modelBuilder.Entity("DotNet_GoeBezig_G11.Models.Domein.Melding", b =>
                {
                    b.Property<int>("MeldingId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Datum");

                    b.Property<int?>("FromUserUserId");

                    b.Property<bool>("Gelezen");

                    b.Property<string>("GroepNaam");

                    b.Property<string>("Inhoud");

                    b.Property<int?>("ToUserUserId");

                    b.Property<int?>("UserId");

                    b.HasKey("MeldingId");

                    b.HasIndex("FromUserUserId");

                    b.HasIndex("ToUserUserId");

                    b.HasIndex("UserId");

                    b.ToTable("Melding");
                });

            modelBuilder.Entity("DotNet_GoeBezig_G11.Models.Domein.Motivatie", b =>
                {
                    b.Property<int>("MotivatieId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("BerichtAangemaakt");

                    b.Property<DateTime>("DatumIngediend");

                    b.Property<string>("Feedback");

                    b.Property<bool>("Goedgekeurd");

                    b.Property<int?>("GroepId");

                    b.Property<string>("Inhoud");

                    b.Property<int?>("OrganisatieId");

                    b.HasKey("MotivatieId");

                    b.HasIndex("GroepId");

                    b.HasIndex("OrganisatieId");

                    b.ToTable("Motivaties");
                });

            modelBuilder.Entity("DotNet_GoeBezig_G11.Models.Domein.Organisatie", b =>
                {
                    b.Property<int>("OrganisatieId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<bool>("HeeftLabel");

                    b.Property<int?>("LocatieId");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("Type");

                    b.HasKey("OrganisatieId");

                    b.HasIndex("LocatieId");

                    b.ToTable("Organisaties");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Organisatie");
                });

            modelBuilder.Entity("DotNet_GoeBezig_G11.Models.Domein.State.CurrentState", b =>
                {
                    b.Property<int>("CurrentStateId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Currentstate")
                        .IsRequired();

                    b.Property<int>("ForeignKeyGroep");

                    b.HasKey("CurrentStateId");

                    b.HasIndex("ForeignKeyGroep")
                        .IsUnique();

                    b.ToTable("CurrentState");

                    b.HasDiscriminator<string>("Currentstate").HasValue("CurrentState");
                });

            modelBuilder.Entity("DotNet_GoeBezig_G11.Models.Domein.Taak", b =>
                {
                    b.Property<int>("TaakId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ActieId");

                    b.Property<string>("Bijsturing");

                    b.Property<DateTime>("DatumCreatie");

                    b.Property<DateTime>("DatumWijziging");

                    b.Property<string>("Feedback");

                    b.Property<int>("NiveauVanRealisatie");

                    b.Property<DateTime?>("Tot");

                    b.Property<DateTime?>("Van");

                    b.Property<string>("Wat");

                    b.Property<string>("Wie");

                    b.HasKey("TaakId");

                    b.HasIndex("ActieId");

                    b.ToTable("Taken");
                });

            modelBuilder.Entity("DotNet_GoeBezig_G11.Models.Domein.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("Voornaam")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("UserId");

                    b.ToTable("User");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DotNet_GoeBezig_G11.Models.Domein.School", b =>
                {
                    b.HasBaseType("DotNet_GoeBezig_G11.Models.Domein.Organisatie");

                    b.Property<bool>("IsOpen");

                    b.ToTable("School");

                    b.HasDiscriminator().HasValue("School");
                });

            modelBuilder.Entity("DotNet_GoeBezig_G11.Models.Domein.State.ActieGoedgekeurdState", b =>
                {
                    b.HasBaseType("DotNet_GoeBezig_G11.Models.Domein.State.CurrentState");


                    b.ToTable("ActieGoedgekeurdState");

                    b.HasDiscriminator().HasValue("ActieGoedgekeurd");
                });

            modelBuilder.Entity("DotNet_GoeBezig_G11.Models.Domein.State.ActieIngediendState", b =>
                {
                    b.HasBaseType("DotNet_GoeBezig_G11.Models.Domein.State.CurrentState");


                    b.ToTable("ActieIngediendState");

                    b.HasDiscriminator().HasValue("ActieIngediend");
                });

            modelBuilder.Entity("DotNet_GoeBezig_G11.Models.Domein.State.Endstate", b =>
                {
                    b.HasBaseType("DotNet_GoeBezig_G11.Models.Domein.State.CurrentState");


                    b.ToTable("Endstate");

                    b.HasDiscriminator().HasValue("EndState");
                });

            modelBuilder.Entity("DotNet_GoeBezig_G11.Models.Domein.State.MotivatieGoedgekeurdState", b =>
                {
                    b.HasBaseType("DotNet_GoeBezig_G11.Models.Domein.State.CurrentState");


                    b.ToTable("MotivatieGoedgekeurdState");

                    b.HasDiscriminator().HasValue("MotivatieGoedgekeurd");
                });

            modelBuilder.Entity("DotNet_GoeBezig_G11.Models.Domein.State.MotivatieIngediendState", b =>
                {
                    b.HasBaseType("DotNet_GoeBezig_G11.Models.Domein.State.CurrentState");


                    b.ToTable("MotivatieIngediendState");

                    b.HasDiscriminator().HasValue("MotivatieIngediend");
                });

            modelBuilder.Entity("DotNet_GoeBezig_G11.Models.Domein.State.StartState", b =>
                {
                    b.HasBaseType("DotNet_GoeBezig_G11.Models.Domein.State.CurrentState");


                    b.ToTable("StartState");

                    b.HasDiscriminator().HasValue("Start");
                });

            modelBuilder.Entity("DotNet_GoeBezig_G11.Models.Domein.Cursist", b =>
                {
                    b.HasBaseType("DotNet_GoeBezig_G11.Models.Domein.User");

                    b.Property<int?>("GroepId");

                    b.Property<int?>("LectorUserId");

                    b.Property<int?>("SchoolOrganisatieId");

                    b.HasIndex("GroepId");

                    b.HasIndex("LectorUserId");

                    b.HasIndex("SchoolOrganisatieId");

                    b.ToTable("Cursist");

                    b.HasDiscriminator().HasValue("Cursist");
                });

            modelBuilder.Entity("DotNet_GoeBezig_G11.Models.Domein.Lector", b =>
                {
                    b.HasBaseType("DotNet_GoeBezig_G11.Models.Domein.User");


                    b.ToTable("Lector");

                    b.HasDiscriminator().HasValue("Lector");
                });

            modelBuilder.Entity("DotNet_GoeBezig_G11.Models.Domein.Actie", b =>
                {
                    b.HasOne("DotNet_GoeBezig_G11.Models.Domein.ActieContainer")
                        .WithMany("Acties")
                        .HasForeignKey("ActieContainerContainerId");
                });

            modelBuilder.Entity("DotNet_GoeBezig_G11.Models.Domein.ActieContainer", b =>
                {
                    b.HasOne("DotNet_GoeBezig_G11.Models.Domein.Groep")
                        .WithMany("ActieContainers")
                        .HasForeignKey("GroepId");
                });

            modelBuilder.Entity("DotNet_GoeBezig_G11.Models.Domein.Bericht", b =>
                {
                    b.HasOne("DotNet_GoeBezig_G11.Models.Domein.Actie", "Actie")
                        .WithMany("Bericht")
                        .HasForeignKey("ActieId");

                    b.HasOne("DotNet_GoeBezig_G11.Models.Domein.Motivatie", "Motivatie")
                        .WithOne("Bericht")
                        .HasForeignKey("DotNet_GoeBezig_G11.Models.Domein.Bericht", "MotivatieId");
                });

            modelBuilder.Entity("DotNet_GoeBezig_G11.Models.Domein.Contactpersoon", b =>
                {
                    b.HasOne("DotNet_GoeBezig_G11.Models.Domein.Motivatie")
                        .WithMany("Contactpersonen")
                        .HasForeignKey("MotivatieId");

                    b.HasOne("DotNet_GoeBezig_G11.Models.Domein.Organisatie", "Organisatie")
                        .WithMany("Contactpersonen")
                        .HasForeignKey("OrganisatieId");
                });

            modelBuilder.Entity("DotNet_GoeBezig_G11.Models.Domein.Melding", b =>
                {
                    b.HasOne("DotNet_GoeBezig_G11.Models.Domein.User", "FromUser")
                        .WithMany()
                        .HasForeignKey("FromUserUserId");

                    b.HasOne("DotNet_GoeBezig_G11.Models.Domein.User", "ToUser")
                        .WithMany()
                        .HasForeignKey("ToUserUserId");

                    b.HasOne("DotNet_GoeBezig_G11.Models.Domein.User")
                        .WithMany("Meldingen")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("DotNet_GoeBezig_G11.Models.Domein.Motivatie", b =>
                {
                    b.HasOne("DotNet_GoeBezig_G11.Models.Domein.Groep")
                        .WithMany("Motivaties")
                        .HasForeignKey("GroepId");

                    b.HasOne("DotNet_GoeBezig_G11.Models.Domein.Organisatie", "Organisatie")
                        .WithMany()
                        .HasForeignKey("OrganisatieId");
                });

            modelBuilder.Entity("DotNet_GoeBezig_G11.Models.Domein.Organisatie", b =>
                {
                    b.HasOne("DotNet_GoeBezig_G11.Models.Domein.Locatie", "Locatie")
                        .WithMany()
                        .HasForeignKey("LocatieId");
                });

            modelBuilder.Entity("DotNet_GoeBezig_G11.Models.Domein.State.CurrentState", b =>
                {
                    b.HasOne("DotNet_GoeBezig_G11.Models.Domein.Groep", "Groep")
                        .WithOne("CurrentState")
                        .HasForeignKey("DotNet_GoeBezig_G11.Models.Domein.State.CurrentState", "ForeignKeyGroep")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DotNet_GoeBezig_G11.Models.Domein.Taak", b =>
                {
                    b.HasOne("DotNet_GoeBezig_G11.Models.Domein.Actie", "Actie")
                        .WithMany("Taken")
                        .HasForeignKey("ActieId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DotNet_GoeBezig_G11.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DotNet_GoeBezig_G11.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DotNet_GoeBezig_G11.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DotNet_GoeBezig_G11.Models.Domein.Cursist", b =>
                {
                    b.HasOne("DotNet_GoeBezig_G11.Models.Domein.Groep", "Groep")
                        .WithMany("Cursisten")
                        .HasForeignKey("GroepId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("DotNet_GoeBezig_G11.Models.Domein.Lector", "Lector")
                        .WithMany("Cursisten")
                        .HasForeignKey("LectorUserId");

                    b.HasOne("DotNet_GoeBezig_G11.Models.Domein.School", "School")
                        .WithMany("Cursisten")
                        .HasForeignKey("SchoolOrganisatieId")
                        .OnDelete(DeleteBehavior.SetNull);
                });
        }
    }
}

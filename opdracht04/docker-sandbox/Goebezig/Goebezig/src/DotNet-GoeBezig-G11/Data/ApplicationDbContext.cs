using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DotNet_GoeBezig_G11.Models;
using DotNet_GoeBezig_G11.Models.Domein;
using DotNet_GoeBezig_G11.Models.Domein.State;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNet_GoeBezig_G11.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Bericht> Berichten { get; set; }
        public DbSet<Locatie> Locaties { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Cursist> Cursists { get; set; }
        public DbSet<Lector> Lectors { get; set; }
        public DbSet<Groep> Groeps { get; set; }
        public DbSet<Organisatie> Organisaties { get; set; }
        public DbSet<Motivatie> Motivaties { get; set; }

        public DbSet<CurrentState> CurrentState { get; set; }

        public DbSet<ActieContainer> ActieContainers { get; set; }
       
        public DbSet<Actie> Acties { get; set; }

        public DbSet<Taak> Taken { get; set; }

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Locatie>(MapLocatie);
            builder.Entity<School>(MapSchool);
            builder.Entity<Cursist>(MapCursist);
            builder.Entity<Lector>(MapLector);
            builder.Entity<Groep>(MapGroep);
            builder.Entity<Bericht>(MapBericht);
            builder.Entity<Actie>(MapActie);
            builder.Entity<Motivatie>(MapMotivatie);
            builder.Entity<CurrentState>(MapCurrentState);
            builder.Entity<User>(MapUser);
            builder.Entity<Melding>(MapMelding);
            builder.Entity<ActieContainer>(MapActieContainer);
            
            
            builder.Entity<Taak>(MapTaak);
            //builder.Entity<Contactpersoon>(MapContactpersoon);

        }

        private static void MapTaak(EntityTypeBuilder<Taak> taak)
        {
            taak.ToTable("Taken");


        }

        private static void MapActie(EntityTypeBuilder<Actie> actie)
        {
            actie.HasMany(a => a.Taken)
                .WithOne(t => t.Actie);

           
        }

        private void MapBericht(EntityTypeBuilder<Bericht> bericht)
        {

           
            // bericht.HasKey(e => new {e.Actie,e.Motivatie});

            
           
        }

        private void MapActieContainer(EntityTypeBuilder<ActieContainer> container)
        {
            container.HasKey(c => c.ContainerId);
            container.HasMany(c => c.Acties);
        }

        private static void MapMelding(EntityTypeBuilder<Melding> melding)
        {
            melding.HasOne(m => m.ToUser);
            melding.HasOne(m => m.FromUser);
        }

        private static void MapUser(EntityTypeBuilder<User> user)
        {
            user.HasMany(u => u.Meldingen);
            
        }

        private static void MapCurrentState(EntityTypeBuilder<CurrentState> currentState)
        {
            currentState.HasDiscriminator<String>("Currentstate")
                .HasValue<StartState>("Start")
                .HasValue<MotivatieIngediendState>("MotivatieIngediend")
                .HasValue<MotivatieGoedgekeurdState>("MotivatieGoedgekeurd")
                .HasValue<ActieIngediendState>("ActieIngediend")
                .HasValue<ActieGoedgekeurdState>("ActieGoedgekeurd")

                .HasValue<Endstate>("EndState");


        }

        private static void MapGroep(EntityTypeBuilder<Groep> groep)
        {
            groep.Property(c => c.Naam)
                .HasMaxLength(50)
                .IsRequired();

            groep.Property(c => c.Open)
                .IsRequired();

            groep.HasOne(g => g.CurrentState)
                .WithOne(c => c.Groep)
                .HasForeignKey<CurrentState>( c  => c.ForeignKeyGroep);

            groep.HasMany(g => g.ActieContainers);
        }

        private static void MapLector(EntityTypeBuilder<Lector> lector)
        {
            lector.Property(c => c.Naam)
                .HasMaxLength(50)
                .IsRequired();

            lector.Property(l => l.Email)
                .HasMaxLength(100)
                .IsRequired();
        }

        private static void MapCursist(EntityTypeBuilder<Cursist> cursist)
        {
            //cursist.ToTable("Cursist");

             //cursist.HasKey(c => c.UserId);

            cursist.Property(c => c.Naam)
                .HasMaxLength(50)
                .IsRequired();

            cursist.Property(c => c.Voornaam)
                .HasMaxLength(50)
                .IsRequired();

            cursist.HasOne(c => c.School)
                .WithMany(s => s.Cursisten)
                .OnDelete(DeleteBehavior.SetNull);

            cursist.HasOne(c => c.Lector)
                .WithMany(l => l.Cursisten);
            //.OnDelete(DeleteBehavior.SetNull);

            cursist.HasOne(c => c.Groep)
                .WithMany(g => g.Cursisten)
            .OnDelete(DeleteBehavior.SetNull);






        }

        private static void MapSchool(EntityTypeBuilder<School> school)
        {
            school.Property(s => s.Naam)
                .HasMaxLength(100)
                .IsRequired();

            school.Property(s => s.Email)
                .HasMaxLength(100)
                .IsRequired();





        }

        private static void MapLocatie(EntityTypeBuilder<Locatie> locatie)
        {
            locatie.Property(l => l.Straat)
                .HasMaxLength(100)
                .IsRequired();

            locatie.Property(l => l.Nummer)
                .IsRequired();

            locatie.Property(l => l.Land)
                .HasMaxLength(50)
                .IsRequired();

            locatie.Property(l => l.Postcode)
                .IsRequired();

            locatie.Property(l => l.Stad)
                .HasMaxLength(100)
                .IsRequired();



        }

        private static void MapMotivatie(EntityTypeBuilder<Motivatie> motivatie)
        {
            motivatie.Property(m => m.Inhoud);

            motivatie.Property(m => m.DatumIngediend)
                .IsRequired();
          





        }
    }
}

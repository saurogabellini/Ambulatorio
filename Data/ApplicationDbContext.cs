using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore; // <-- Aggiungi questo
using Microsoft.AspNetCore.Identity;                     // <-- Aggiungi questo
using AmbulatorioApp.Data.Models;

namespace AmbulatorioApp.Data
{
    // Cambia DbContext con IdentityDbContext<IdentityUser>
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // I tuoi DbSet personalizzati rimangono invariati
        public DbSet<Operatore> Operatori { get; set; }
        public DbSet<Servizio> Servizi { get; set; }
        public DbSet<SlotDisponibilita> SlotDisponibilita { get; set; }
        public DbSet<Assenza> Assenze { get; set; }
        public DbSet<Prenotazione> Prenotazioni { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Questa chiamata è ora MOLTO importante perché configura le tabelle Identity
            base.OnModelCreating(modelBuilder);

            // Le tue configurazioni personalizzate rimangono invariate
            // Configurazione delle relazioni
            modelBuilder.Entity<SlotDisponibilita>()
                .HasOne(s => s.Operatore)
                .WithMany(o => o.SlotDisponibilita)
                .HasForeignKey(s => s.OperatoreId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SlotDisponibilita>()
                .HasOne(s => s.Servizio)
                .WithMany(s => s.SlotDisponibilita)
                .HasForeignKey(s => s.ServizioId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Assenza>()
                .HasOne(a => a.Operatore)
                .WithMany(o => o.Assenze)
                .HasForeignKey(a => a.OperatoreId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Prenotazione>()
                .HasOne(p => p.Operatore)
                .WithMany(o => o.Prenotazioni)
                .HasForeignKey(p => p.OperatoreId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Prenotazione>()
                .HasOne(p => p.Servizio)
                .WithMany(s => s.Prenotazioni)
                .HasForeignKey(p => p.ServizioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Prenotazione>()
                .HasOne(p => p.SlotDisponibilita)
                .WithMany(s => s.Prenotazioni)
                .HasForeignKey(p => p.SlotDisponibilitaId)
                .OnDelete(DeleteBehavior.Restrict);

            // Potresti voler aggiungere qui altre configurazioni specifiche per Identity
            // se necessario, ad esempio personalizzare i nomi delle tabelle:
            // modelBuilder.Entity<IdentityUser>().ToTable("Users");
            // modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            // ... ecc. ma di solito non è necessario all'inizio.
        }
    }
}
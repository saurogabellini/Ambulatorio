using Microsoft.EntityFrameworkCore;
using AmbulatorioApp.Data;

namespace AmbulatorioApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Assicurarsi che il database esista
            context.Database.EnsureCreated();

            // Verifica se ci sono già operatori nel database
            if (context.Operatori.Any())
            {
                return; // Il database è già stato inizializzato
            }

            // Qui puoi aggiungere dati di esempio se necessario
            // Ad esempio:
            /*
            var operatori = new[]
            {
                new Operatore { Nome = "Mario", Cognome = "Rossi", CodiceFiscale = "RSSMRA80A01H501U", Recapiti = "3331234567", Specializzazione = "Cardiologia" },
                new Operatore { Nome = "Laura", Cognome = "Bianchi", CodiceFiscale = "BNCLRA75B02H501V", Recapiti = "3339876543", Specializzazione = "Dermatologia" }
            };
            context.Operatori.AddRange(operatori);
            context.SaveChanges();
            */
        }
    }
}

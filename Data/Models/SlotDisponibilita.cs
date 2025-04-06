using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmbulatorioApp.Data.Models
{
    public class SlotDisponibilita
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OperatoreId { get; set; }

        [Required]
        public int ServizioId { get; set; }

        [Required]
        public int GiornoSettimana { get; set; } // 1 = Lunedì, 2 = Martedì, ecc.

        [Required]
        [Column(TypeName = "varchar(max)")]
        public TimeSpan OraInizio { get; set; }

        [Required]
        [Column(TypeName = "varchar(max)")]
        public TimeSpan OraFine { get; set; }

        [Required]
        public int DurataMinuti { get; set; } // Durata in minuti (30, 60, 90, ecc.)

        [Required]
        public bool Attivo { get; set; } = true;

        // Proprietà per la gestione dei turni ricorrenti
        public DateTime? DataInizioValidita { get; set; }
        public DateTime? DataFineValidita { get; set; }
        public int? CicloGiorni { get; set; } // Per la ricorrenza personalizzata (es. ogni 3 giorni)

        // Relazioni
        [ForeignKey("OperatoreId")]
        public virtual Operatore Operatore { get; set; }

        [ForeignKey("ServizioId")]
        public virtual Servizio Servizio { get; set; }

        public virtual ICollection<Prenotazione> Prenotazioni { get; set; }

        public SlotDisponibilita()
        {
            Prenotazioni = new HashSet<Prenotazione>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmbulatorioApp.Data.Models
{
    public class Operatore
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Il cognome è obbligatorio")]
        [StringLength(100, ErrorMessage = "Il cognome non può superare i 100 caratteri")]
        [Column(TypeName = "varchar(max)")]
        public string Cognome { get; set; }

        [Required(ErrorMessage = "Il nome è obbligatorio")]
        [StringLength(100, ErrorMessage = "Il nome non può superare i 100 caratteri")]
        [Column(TypeName = "varchar(max)")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Il codice fiscale è obbligatorio")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Il codice fiscale deve essere di 16 caratteri")]
        [Column(TypeName = "varchar(16)")]
        public string CodiceFiscale { get; set; }

        [StringLength(200, ErrorMessage = "I recapiti non possono superare i 200 caratteri")]
        [Column(TypeName = "varchar(max)")]
        public string Recapiti { get; set; }

        [StringLength(100, ErrorMessage = "La specializzazione non può superare i 100 caratteri")]
        [Column(TypeName = "varchar(max)")]
        public string Specializzazione { get; set; }

        // Relazioni
        public virtual ICollection<SlotDisponibilita> SlotDisponibilita { get; set; }
        public virtual ICollection<Assenza> Assenze { get; set; }
        public virtual ICollection<Prenotazione> Prenotazioni { get; set; }

        public Operatore()
        {
            SlotDisponibilita = new HashSet<SlotDisponibilita>();
            Assenze = new HashSet<Assenza>();
            Prenotazioni = new HashSet<Prenotazione>();
        }
    }
}

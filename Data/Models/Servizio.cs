using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmbulatorioApp.Data.Models
{
    public class Servizio
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Il nome del servizio è obbligatorio")]
        [StringLength(100, ErrorMessage = "Il nome del servizio non può superare i 100 caratteri")]
        [Column(TypeName = "varchar(max)")]
        public string Nome { get; set; }

        [StringLength(500, ErrorMessage = "La descrizione non può superare i 500 caratteri")]
        [Column(TypeName = "varchar(max)")]
        public string Descrizione { get; set; }

        // Relazioni
        public virtual ICollection<SlotDisponibilita> SlotDisponibilita { get; set; }
        public virtual ICollection<Prenotazione> Prenotazioni { get; set; }

        public Servizio()
        {
            SlotDisponibilita = new HashSet<SlotDisponibilita>();
            Prenotazioni = new HashSet<Prenotazione>();
        }
    }
}

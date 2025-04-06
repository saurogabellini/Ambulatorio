using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmbulatorioApp.Data.Models
{
    public class Prenotazione
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OperatoreId { get; set; }

        [Required]
        public int ServizioId { get; set; }

        [Required]
        public int SlotDisponibilitaId { get; set; }

        [Required]
        public DateTime DataPrenotazione { get; set; }

        [Required]
        public DateTime DataOraInizio { get; set; }

        [Required]
        public DateTime DataOraFine { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Il nome del cliente non può superare i 100 caratteri")]
        [Column(TypeName = "varchar(max)")]
        public string NomeCliente { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Il cognome del cliente non può superare i 100 caratteri")]
        [Column(TypeName = "varchar(max)")]
        public string CognomeCliente { get; set; }

        [StringLength(20, ErrorMessage = "Il telefono non può superare i 20 caratteri")]
        [Column(TypeName = "varchar(max)")]
        public string TelefonoCliente { get; set; }

        [EmailAddress]
        [StringLength(100, ErrorMessage = "L'email non può superare i 100 caratteri")]
        [Column(TypeName = "varchar(max)")]
        public string EmailCliente { get; set; }

        [StringLength(500)]
        public string Note { get; set; }

        // Relazioni
        [ForeignKey("OperatoreId")]
        public virtual Operatore Operatore { get; set; }

        [ForeignKey("ServizioId")]
        public virtual Servizio Servizio { get; set; }

        [ForeignKey("SlotDisponibilitaId")]
        public virtual SlotDisponibilita SlotDisponibilita { get; set; }
    }
}

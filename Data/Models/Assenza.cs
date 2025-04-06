using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmbulatorioApp.Data.Models
{
    public class Assenza
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OperatoreId { get; set; }

        [Required]
        public DateTime DataOraInizio { get; set; }

        [Required]
        public DateTime DataOraFine { get; set; }

        [StringLength(200)]
        public string Motivo { get; set; }

        // Relazioni
        [ForeignKey("OperatoreId")]
        public virtual Operatore Operatore { get; set; }
    }
}

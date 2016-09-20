namespace ZafiroCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ClaseHorario")]
    public partial class ClaseHorario
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long IdClase { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Dia { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string Hora { get; set; }

        public virtual Clase Clase { get; set; }
    }
}

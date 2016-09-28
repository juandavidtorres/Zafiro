namespace ZF_Core.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ClaseAsistencia")]
    public partial class ClaseAsistencia
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long IdClase { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long IdEstudiante { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime FechaClase { get; set; }

        public virtual Clase Clase { get; set; }

        public virtual Estudiante Estudiante { get; set; }
    }
}

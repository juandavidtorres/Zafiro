namespace ZafiroCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ClaseNota")]
    public partial class ClaseNota
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
        public decimal Nota { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long IdContenido { get; set; }

        public virtual Clase Clase { get; set; }

        public virtual Contenido Contenido { get; set; }

        public virtual Estudiante Estudiante { get; set; }
    }
}

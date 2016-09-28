namespace ZF_Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Clase")]
    public partial class Clase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clase()
        {
            ClaseAsistencia = new HashSet<ClaseAsistencia>();
            ClaseHorario = new HashSet<ClaseHorario>();
            ClaseNota = new HashSet<ClaseNota>();
            Profesor = new HashSet<Profesor>();
        }

        [Key]
        public long IdClase { get; set; }

        public DateTime FechaInicial { get; set; }

        public DateTime FechaFinal { get; set; }

        public long IdCurso { get; set; }

        [Required]
        [StringLength(500)]
        public string Descripcion { get; set; }

        public long IdCompania { get; set; }

        public bool Habilitada { get; set; }

        public virtual Compañia Compañia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClaseAsistencia> ClaseAsistencia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClaseHorario> ClaseHorario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClaseNota> ClaseNota { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Profesor> Profesor { get; set; }
    }
}

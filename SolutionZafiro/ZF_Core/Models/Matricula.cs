namespace ZF_Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Matricula")]
    public partial class Matricula
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Matricula()
        {
            MatriculaDetalle = new HashSet<MatriculaDetalle>();
            MatriculaFormaPago = new HashSet<MatriculaFormaPago>();
        }

        [Key]
        public long IdMatricula { get; set; }

        public long IdEstudiante { get; set; }

        public DateTime FechaRegistro { get; set; }

        public DateTime FechaOperacion { get; set; }

        public decimal ValorMatricula { get; set; }

        public long IdCompania { get; set; }

        public bool PazySalvo { get; set; }

        public virtual Compañia Compañia { get; set; }

        public virtual Estudiante Estudiante { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MatriculaDetalle> MatriculaDetalle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MatriculaFormaPago> MatriculaFormaPago { get; set; }
    }
}

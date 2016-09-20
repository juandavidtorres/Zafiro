namespace ZafiroCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Curso")]
    public partial class Curso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Curso()
        {
            CursoContenido = new HashSet<CursoContenido>();
            MatriculaDetalle = new HashSet<MatriculaDetalle>();
        }

        [Key]
        public long IdCurso { get; set; }

        public long? Nombre { get; set; }

        public long? IdCompania { get; set; }

        public long? IdCursoPrerrequisito { get; set; }

        public int AsistenciaMinima { get; set; }

        public virtual Compañia Compañia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CursoContenido> CursoContenido { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MatriculaDetalle> MatriculaDetalle { get; set; }
    }
}

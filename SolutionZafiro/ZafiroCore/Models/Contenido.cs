namespace ZafiroCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contenido")]
    public partial class Contenido
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contenido()
        {
            ClaseNota = new HashSet<ClaseNota>();
            CursoContenido = new HashSet<CursoContenido>();
        }

        [Key]
        public long IdContenido { get; set; }

        [StringLength(100)]
        public string Nombre { get; set; }

        public long? IdCompania { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClaseNota> ClaseNota { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CursoContenido> CursoContenido { get; set; }
    }
}

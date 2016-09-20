namespace ZafiroCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Estudiante")]
    public partial class Estudiante
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Estudiante()
        {
            ClaseAsistencia = new HashSet<ClaseAsistencia>();
            ClaseNota = new HashSet<ClaseNota>();
            Matricula = new HashSet<Matricula>();
        }

        [Key]
        public long IdEstudiante { get; set; }

        [Required]
        [StringLength(100)]
        public string Nuip { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellido { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaNacimiento { get; set; }

        [StringLength(50)]
        public string Telefono { get; set; }

        [MaxLength(100)]
        public byte[] Movil { get; set; }

        [StringLength(200)]
        public string Direccion { get; set; }

        [StringLength(100)]
        public string IdAspnetId { get; set; }

        public long? IdCompania { get; set; }

        public bool Habilitado { get; set; }

        public virtual Compañia Compañia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClaseAsistencia> ClaseAsistencia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClaseNota> ClaseNota { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Matricula> Matricula { get; set; }
    }
}

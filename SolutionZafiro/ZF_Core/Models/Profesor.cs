namespace ZF_Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Profesor")]
    public partial class Profesor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Profesor()
        {
            Clase = new HashSet<Clase>();
        }

        [Key]
        public long IdProfesor { get; set; }

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
        public virtual ICollection<Clase> Clase { get; set; }
    }
}

namespace ZF_Core.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("FormaPago")]
    public partial class FormaPago
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FormaPago()
        {
            MatriculaFormaPago = new HashSet<MatriculaFormaPago>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long IdFormaPago { get; set; }

        [StringLength(50)]
        public string Descripcion { get; set; }

        public bool Habilitada { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MatriculaFormaPago> MatriculaFormaPago { get; set; }
    }
}

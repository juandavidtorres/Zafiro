namespace ZafiroCore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MatriculaFormaPago")]
    public partial class MatriculaFormaPago
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long IdMatriculaFormaPago { get; set; }

        public long IdMatricula { get; set; }

        public long IdFormaPago { get; set; }

        [StringLength(50)]
        public string Documento { get; set; }

        public virtual FormaPago FormaPago { get; set; }

        public virtual Matricula Matricula { get; set; }
    }
}

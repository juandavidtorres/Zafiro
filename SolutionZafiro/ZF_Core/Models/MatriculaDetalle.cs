namespace ZF_Core.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("MatriculaDetalle")]
    public partial class MatriculaDetalle
    {
        [Key]
        public long IdMatriculaDetalle { get; set; }

        public long IdCurso { get; set; }

        public long? IdMatricula { get; set; }

        public virtual Curso Curso { get; set; }

        public virtual Matricula Matricula { get; set; }
    }
}

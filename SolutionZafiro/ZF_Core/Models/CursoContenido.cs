namespace ZF_Core.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CursoContenido")]
    public partial class CursoContenido
    {
        [Key]
        public long IdCursoContenido { get; set; }

        public long? IdContenido { get; set; }

        public bool EsEvaluable { get; set; }

        public long? IdCurso { get; set; }

        public virtual Contenido Contenido { get; set; }

        public virtual Curso Curso { get; set; }
    }
}

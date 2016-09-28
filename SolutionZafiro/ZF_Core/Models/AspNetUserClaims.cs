namespace ZF_Core.Models
{
    using System.ComponentModel.DataAnnotations;

    public partial class AspNetUserClaims
    {
        public int Id { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }

        [Required]
        [StringLength(128)]
        public string User_Id { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }
    }
}

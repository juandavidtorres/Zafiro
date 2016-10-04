using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ZF_Core.Models
{

    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public partial class ModelZafiro : DbContext
    {
        public ModelZafiro()
            : base("name=ModelZafiro")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Clase> Clase { get; set; }
        public virtual DbSet<Compañia> Compañia { get; set; }
        public virtual DbSet<Contenido> Contenido { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<CursoContenido> CursoContenido { get; set; }
        public virtual DbSet<Estudiante> Estudiante { get; set; }
        public virtual DbSet<FormaPago> FormaPago { get; set; }
        public virtual DbSet<Matricula> Matricula { get; set; }
        public virtual DbSet<MatriculaDetalle> MatriculaDetalle { get; set; }
        public virtual DbSet<MatriculaFormaPago> MatriculaFormaPago { get; set; }
        public virtual DbSet<Profesor> Profesor { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<ClaseAsistencia> ClaseAsistencia { get; set; }
        public virtual DbSet<ClaseHorario> ClaseHorario { get; set; }
        public virtual DbSet<ClaseNota> ClaseNota { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.User_Id);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Clase>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Clase>()
                .HasMany(e => e.ClaseAsistencia)
                .WithRequired(e => e.Clase)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Clase>()
                .HasMany(e => e.ClaseHorario)
                .WithRequired(e => e.Clase)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Clase>()
                .HasMany(e => e.ClaseNota)
                .WithRequired(e => e.Clase)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Clase>()
                .HasMany(e => e.Profesor)
                .WithMany(e => e.Clase)
                .Map(m => m.ToTable("ClaseProfesor").MapLeftKey("IdClase").MapRightKey("IdProfesor"));

            modelBuilder.Entity<Compañia>()
                .Property(e => e.Nit)
                .IsUnicode(false);

            modelBuilder.Entity<Compañia>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Compañia>()
                .HasMany(e => e.Clase)
                .WithRequired(e => e.Compañia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Compañia>()
                .HasMany(e => e.Matricula)
                .WithRequired(e => e.Compañia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Contenido>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Contenido>()
                .HasMany(e => e.ClaseNota)
                .WithRequired(e => e.Contenido)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Curso>()
                .HasMany(e => e.MatriculaDetalle)
                .WithRequired(e => e.Curso)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.Nuip)
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.IdAspnetId)
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .HasMany(e => e.ClaseAsistencia)
                .WithRequired(e => e.Estudiante)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Estudiante>()
                .HasMany(e => e.ClaseNota)
                .WithRequired(e => e.Estudiante)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Estudiante>()
                .HasMany(e => e.Matricula)
                .WithRequired(e => e.Estudiante)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FormaPago>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<FormaPago>()
                .HasMany(e => e.MatriculaFormaPago)
                .WithRequired(e => e.FormaPago)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Matricula>()
                .HasMany(e => e.MatriculaFormaPago)
                .WithRequired(e => e.Matricula)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MatriculaFormaPago>()
                .Property(e => e.Documento)
                .IsUnicode(false);

            modelBuilder.Entity<Profesor>()
                .Property(e => e.Nuip)
                .IsUnicode(false);

            modelBuilder.Entity<Profesor>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Profesor>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Profesor>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Profesor>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Profesor>()
                .Property(e => e.IdAspnetId)
                .IsUnicode(false);

            modelBuilder.Entity<ClaseHorario>()
                .Property(e => e.Hora)
                .IsUnicode(false);

            modelBuilder.Entity<ClaseNota>()
                .Property(e => e.Nota)
                .HasPrecision(18, 3);
        }
    }
}

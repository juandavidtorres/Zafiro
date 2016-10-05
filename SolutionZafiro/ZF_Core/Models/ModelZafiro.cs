using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ZF_Core.Models
{
    public class GestionUsuarios : UserManager<Usuario>
    {
        public GestionUsuarios(IUserStore<Usuario> AlmacenUsuarios)
            : base(AlmacenUsuarios) { }

        public static GestionUsuarios Crear(IdentityFactoryOptions<GestionUsuarios> opciones, IOwinContext contexto)
        {
            ContextoIdentity baseDatos = contexto.Get<ContextoIdentity>();
            GestionUsuarios gestionUsuarios = new GestionUsuarios(new UserStore<Usuario>(baseDatos));

            return gestionUsuarios;
        }
    }

    public class Usuario : IdentityUser
    {

    }

   

    public class InicializacionBBDDIdentity : DropCreateDatabaseIfModelChanges<ContextoIdentity>
    {
        protected override void Seed(ContextoIdentity context)
        {
            ProcesarConfiguracionInicial();
            base.Seed(context);
        }

        public void ProcesarConfiguracionInicial()
        {
            //pendiente la carga de datos inicial
        }
    }

    public class ContextoIdentity : IdentityDbContext<Usuario>
    {
        public ContextoIdentity()
            : base("name=ModelZafiro")
        {

        }
        static ContextoIdentity()
        {
            Database.SetInitializer<ContextoIdentity>(new InicializacionBBDDIdentity());
        }     

        public static ContextoIdentity Crear()
        {
            return new ContextoIdentity();
        }
    }
}

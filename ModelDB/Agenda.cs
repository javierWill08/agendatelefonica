using System;
using System.Collections.Generic;

namespace WebApiAgenda.ModelDB
{
    public partial class Agenda
    {
        public int Id { get; set; }
        public string NombreAgenda { get; set; }
        public int IdUsuario { get; set; }
        public int IdContacto { get; set; }

        public virtual Contacto IdContactoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}

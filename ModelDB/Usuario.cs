using System;
using System.Collections.Generic;

namespace WebApiAgenda.ModelDB
{
    public partial class Usuario
    {
        public Usuario()
        {
            Agenda = new HashSet<Agenda>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contrasenia { get; set; }

        public virtual ICollection<Agenda> Agenda { get; set; }
    }
}

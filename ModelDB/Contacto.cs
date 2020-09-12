using System;
using System.Collections.Generic;

namespace WebApiAgenda.ModelDB
{
    public partial class Contacto
    {
        public Contacto()
        {
            Agenda = new HashSet<Agenda>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public int Telefono { get; set; }

        public virtual ICollection<Agenda> Agenda { get; set; }
    }
}

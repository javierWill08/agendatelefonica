using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiAgenda.Model;
using WebApiAgenda.ModelDB;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiAgenda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioDTOController : ControllerBase
    {
        // GET: api/Usuario
        [HttpGet]
        public IEnumerable<UsuarioDTO> Get()
        {
            List<UsuarioDTO> usuarios = new List<UsuarioDTO>();

            //conexion a la base de datos
            using (AgendaMauiContext context = new AgendaMauiContext()) {
                //todos los registros de la tabla persona
                var entidades = context.Usuario;
                foreach (var user in entidades) {
                    UsuarioDTO u = new UsuarioDTO();
                    u.id = user.Id;
                    u.Nombre = user.Nombre;
                    u.Correo = user.Correo;
                    u.Contrasena = user.Contrasenia;

                    usuarios.Add(u);

                }
            }

                return usuarios;
        }

        // GET api/Usuario/5
        [HttpGet("{id}")]
        public UsuarioDTO Get(int id)
        {

            UsuarioDTO user = new UsuarioDTO();

            using (AgendaMauiContext context = new AgendaMauiContext()) {

                //linq para busqueda, con una expresion lamda
                var item = context.Usuario.FirstOrDefault(p => p.Id == id);

                user.id = item.Id;
                user.Nombre = item.Nombre;
                user.Correo = item.Correo;
                user.Contrasena = item.Contrasenia;
          
            
            }

                return user;
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public string Post([FromBody] UsuarioDTO value)
        {

            using (AgendaMauiContext context = new AgendaMauiContext()) {

                //se crea objeto de la base de datos
                Usuario userDB = new Usuario();
                //userDB.Id = value.id;--> no mapeado autoincrementado
                userDB.Nombre = value.Nombre;
                userDB.Correo = value.Correo;
                userDB.Contrasenia = value.Contrasena;

                context.Usuario.Add(userDB);
                context.SaveChanges();
            }



                return "todo KO";

        }

        // PUT api/Usuario>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] UsuarioDTO value)
        {
            using (AgendaMauiContext context = new AgendaMauiContext()) {

                var user = context.Usuario.FirstOrDefault(p=>p.Id==id);
                user.Id = value.id;
                user.Nombre = value.Nombre;
                user.Correo = value.Correo;
                user.Contrasenia = value.Contrasena;

                context.SaveChanges();

            }

                return "Todo OK ....";



        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public string  Delete(int id)
        {
            using (AgendaMauiContext context = new AgendaMauiContext()) {

                var item = context.Usuario.FirstOrDefault(p=>p.Id==id);
                context.Usuario.Remove(item);
                context.SaveChanges();

            }

                return "OK borrado";

        }
    }
}

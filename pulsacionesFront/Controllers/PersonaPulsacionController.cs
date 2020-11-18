using System.Collections.Generic;
using System.Linq;
using BLL;
using DAL;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
namespace pulsacionesFront.Controllers {
        [Route ("api/[controller]")]
        [ApiController]

        public class PersonaPulsacionController : ControllerBase​ {
            private readonly PersonaService _personaService;
            
            public PersonaPulsacionController (PulsacionesContext context) {
                _personaService = new PersonaService (context);
            }
            // GET: api/Persona​
            [HttpGet]
            public ActionResult<PersonaViewModel> Gets () {
                var response = _personaService.ConsultarTodos ();
                if (response.Error) {
                    return BadRequest (response.Mensaje);
                } else {
                    return Ok (response.Personas.Select (p => new PersonaViewModel (p)));
                }
            }
            // GET: api/Persona/5​
            [HttpGet ("{identificacion}")]
            public ActionResult<PersonaViewModel> Get (string identificacion) {
                var persona = _personaService.BuscarxIdentificacion (identificacion);
                if (persona == null) return NotFound ();
                var personaViewModel = new PersonaViewModel (persona);
                return personaViewModel;
            }

            // POST: api/Persona​

            [HttpPost]
            public ActionResult<PersonaViewModel> Post (PersonaInputModel personaInput) {
                Persona persona = MapearPersona (personaInput);
                var response = _personaService.Guardar (persona);
                if (response.Error) {
                    return BadRequest (response.Mensaje);
                }
                return Ok (response.Persona);
            }

            private Persona MapearPersona (PersonaInputModel personaInput) {
                var persona = new Persona​ {
                    identificacion = personaInput.identificacion,
                    nombre = personaInput.nombre,
                    edad = personaInput.edad,
                    sexo = personaInput.sexo​
                };
                return persona;
            }
        }
}
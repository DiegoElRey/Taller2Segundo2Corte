using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Entity;

namespace BLL {
    public class PersonaService {
        private readonly PulsacionesContext contexto;

        public PersonaService(PulsacionesContext context) {
            contexto = context;
        }
        public GuardarPersonaResponse Guardar(Persona persona) {
            try {
                persona.pulsacion =  persona.CalcularPulsaciones();
                contexto.Personas.Add(persona);
                contexto.SaveChanges();
                return new GuardarPersonaResponse(persona);
            } catch (Exception e)

            {
                return new GuardarPersonaResponse($"Error de la Aplicacion: {e.Message}");
            }

        }
        public ConsultaPersonaResponse ConsultarTodos() {
            try {
                List<Persona> personas = contexto.Personas.ToList();
                return new ConsultaPersonaResponse(personas);
            } catch (Exception e){
                return new ConsultaPersonaResponse($"Error en la aplicacion:  {e.Message}");
            }
        }

        public Persona BuscarxIdentificacion(string identificacion) {
            Persona persona = contexto.Personas.Find(identificacion);
            return persona;
        }

        public string Eliminar (string identificacion){
            Persona persona = new Persona();
            if ((persona = contexto.Personas.Find(identificacion)) != null) {
                contexto.Personas.Remove (persona);
                contexto.SaveChanges ();
                return $"Se ha eliminado la persona.";
            } else {
                return $"No se encontro la persona. ";
            }
        }

        public class ConsultaPersonaResponse {

            public ConsultaPersonaResponse(List<Persona> personas) {
                Error = false;
                Personas = personas;
            }

            public ConsultaPersonaResponse (string mensaje) {
                Error = true;
                Mensaje = mensaje;
            }
            public Boolean Error { get; set; }
            public string Mensaje { get; set; }
            public List<Persona> Personas { get; set; }
        }
        public class GuardarPersonaResponse

        {

            public GuardarPersonaResponse (Persona persona)

            {
                Error = false;

                Persona = persona;

            }

            public GuardarPersonaResponse (string mensaje)

            {
                Error = true;
                Mensaje = mensaje;
            }

            public bool Error { get; set; }

            public string Mensaje { get; set; }

            public Persona Persona { get; set; }

        }

    }
}
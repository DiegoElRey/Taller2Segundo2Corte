using Entity;
public class PersonaInputModel​
{
    public string identificacion { get; set; }
    public string nombre { get; set; }
    public int edad { get; set; }
    public string sexo { get; set; }
    
}

public class PersonaViewModel : PersonaInputModel​
{
        public PersonaViewModel()
        {
        }
        public PersonaViewModel(Persona persona)
        {
            identificacion = persona.identificacion;
            nombre = persona.nombre;
            edad = persona.edad;
            sexo = persona.sexo;
            Pulsacion = persona.pulsacion;
        }
        public decimal Pulsacion { get; set; }
        
    }
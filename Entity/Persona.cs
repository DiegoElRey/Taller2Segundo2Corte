using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Persona
    {
        [Key]
        public string identificacion { get; set; }
        public string nombre { get; set; }
        public string sexo { get; set; }
        public int edad { get; set; }
        public decimal pulsacion { get; set; }
    public decimal CalcularPulsaciones(){
        if(sexo.Equals("Masculino")){
            return (210 - edad)/10;
        } else if(sexo.Equals("Femenino")){
            return (220-edad)/10;
        }else{
            return 0;
        }
    }
        
    }
}

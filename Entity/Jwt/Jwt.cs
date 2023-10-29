using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Jwt
{
    public class Jwt
    {
        public Jwt()
        {
            // Inicializa las propiedades por defecto si es necesario
            Key = "TuClaveSecreta";
            Issuer = "TuEmisor";
            Audience = "TuAudiencia";
            Subjet = "TuSujeto";
        }
        public string Key {  get; set; }    
        public string Issuer { get; set; }
        public string Audience { get; set;}
        public string Subjet { get; set; }

    }
   
}

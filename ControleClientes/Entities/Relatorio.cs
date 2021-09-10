using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleClientes.Entities
{
    public class Relatorio
    {
        public  Registro Registro  { get; set; }
        public int LegalAgeCount { get; set; }
        public Classe ClasseCount { get; set; }
    }
}

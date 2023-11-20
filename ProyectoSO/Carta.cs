using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSO
{
    public class Carta
    {

        //las cartas cogerán valores desde la base de datos
        public int id { get; set; }
        public string nombre { get; set; } 
        public int fuerza { get; set; }
        public int tipo { get; set; }
        public int repetible { get; set; }

    }
}

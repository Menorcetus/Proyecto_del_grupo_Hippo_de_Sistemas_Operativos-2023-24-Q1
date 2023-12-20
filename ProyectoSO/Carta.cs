using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoSO
{
    public class Carta
    {

        //las cartas cogerán valores desde la base de datos
        public int id { get; set; }
        public int fuerza { get; set; }
        public int tipo { get; set; }

        public PictureBox picture;

    }
}

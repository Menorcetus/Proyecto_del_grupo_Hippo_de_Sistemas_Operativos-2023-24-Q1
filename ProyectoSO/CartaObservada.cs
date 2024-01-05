using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoSO
{
    public partial class CartaObservada : Form
    {
        string nombre;
        int fuerza;
        string descripcion;
        int id;
        PictureBox cartaimage;
        public CartaObservada(Carta carta)
        {
            InitializeComponent();
            this.nombre = carta.name;
            this.fuerza = carta.fuerza;
            this.cartaimage = carta.picture;
            this.id = carta.id;
        }

        private void CartaObservada_Load(object sender, EventArgs e)
        {
            CartaBox.BackgroundImage = cartaimage.Image;
            NombreLbl.Text = nombre;
            FuerzaLbl.Text = Convert.ToString(fuerza);
            NombreLbl_2.Text = "-  " + nombre + "  -";

         //carro de descripciones para cada carta
         switch (this.id)
            {
                case 0:

                    descripcion = "Relaciones pitagóricas para aplastar al enemigo.";
                    descripcLbl.Text = descripcion;

                break;

                case 1:

                    descripcion = "Desde Estambul con amor.";
                    descripcLbl.Text = descripcion;

                break;

                case 2:

                    descripcion = "Las nutrias se dan de la mano para no derivar \nmientras duermen. Para la guerra no les hace falta.";
                    descripcLbl.Text = descripcion;

                break;

                case 3:

                    descripcion = "Desde lo alto del rascacielos mis enemigos son \npequeños. Sólo desde arriba.";
                    descripcLbl.Text = descripcion;

                break;

                case 4:

                    descripcion = "Todo barrio necesita a un rey.";
                    descripcLbl.Text = descripcion;

                break;

                case 5:

                    descripcion = "Robar está mal. Ser un rata también.\nAunque ser un pirrata mola mogollón.";
                    descripcLbl.Text = descripcion;

                break;

                case 6:

                    descripcion = "Más lento que un corcel, pero potente como un toro.\nRecomendado para derribar puertas de castillos \ny también a tus enemigos.";
                    descripcLbl.Text = descripcion;

                break;

                case 7:

                    descripcion = "Hipertrofia y microcefalia.";
                    descripcLbl.Text = descripcion;

                break;

                case 8:

                    descripcion = "\"Hijo, papá era un hipopótamo, lo viste en el zoo.\"\nSi los centauros existen, también deben de existir \nlos hipotauros.";
                    descripcLbl.Text = descripcion;

                break;

                case 9:

                    descripcion = "La dulzura de este ser sólo será comparable a su furia.";
                    descripcLbl.Text = descripcion;

                break;

                case 10:

                    descripcion = "No es un músico.";
                    descripcLbl.Text = descripcion;

                break;

                case 11:

                    descripcion = "Una no hace nada, dos tampoco, tres tampoco, \ncuatro molestan,...\nMiles juntas sí son un problema.";
                    descripcLbl.Text = descripcion;

                break;

                case 12:

                    descripcion = "Cuando se tienen pies prensiles se puede apuntar con el pie izquierdo y \nagarrarse a las lianas con las manos.";
                    descripcLbl.Text = descripcion;

                break;

                case 13:

                    descripcion = "No saben leer lo que pone en esta carta.";
                    descripcLbl.Text = descripcion;

                break;

                case 14:

                    descripcion = "Gwyndael es un bebé, sólo ha dedicado sus cien años a practicar\n con el arco de juguete.";
                    descripcLbl.Text = descripcion;

                break;

                case 15:

                    descripcion = "El dominio de la pólvora está al alcance de muy pocos,\n para ello se ha de ser minero y llamarse Boris Karlsen.";
                    descripcLbl.Text = descripcion;

                break;

                case 16:

                    descripcion = "Quieren imitar a los enanos, pero no pueden con el retroceso\ndel arcabuz.";
                    descripcLbl.Text = descripcion;

                break;

                case 17:

                    descripcion = "\"Un rayo brillante surge de tu dedo índice hasta \nun punto que elijas dentro del alcance y explota \ncon un leve estruendo en un estallido de llamas.\n Todas las criaturas que se encuentren en una esfera\n de 20 pies de radio cuyo centro sea ese punto \ndeben hacer una tirada de salvación de Destreza:\n si fallan, reciben 8d6 puntos de daño por fuego y, \nsi tienen éxito, la mitad.\r\n\r\nEl fuego se propaga en las esquinas e incinera los objetos \n inflamables que se encuentren en el área y que nadie \n lleve puestos ni transporte.\"  in Draconis et Carceris.\r\n";
                    descripcLbl.Text = descripcion;

                break;

                case 18:

                    descripcion = "Nosferatu, el rey de la fiesta.";
                    descripcLbl.Text = descripcion;

                break;

                case 19:

                    descripcion = "\"¿Para qué tres cabezas si tiene sólo dos brazos?\"";
                    descripcLbl.Text = descripcion;

                break;

                case 20:

                    descripcion = "Es peor que el receptor superheterodino pero está bien.";
                    descripcLbl.Text = descripcion;

                break;

                case 21:

                    descripcion = "Amon amarth con ruedines de triciclo.";
                    descripcLbl.Text = descripcion;

                break;

                case 22:

                    descripcion = "\"Pese a que nunca dé dos veces en el mismo objetivo \nno se lo tenemos en cuenta, dado que un tiro basta...\"";
                    descripcLbl.Text = descripcion;

                break;

                case 23:

                    descripcion = "No es un azar que se llame Pain Harold, su nombre\nduele como sus estudios.";
                    descripcLbl.Text = descripcion;

                break;

                case 24:

                    descripcion = "Ya va siendo la hora que se inviertan los roles.";
                    descripcLbl.Text = descripcion;

                break;

                case 25:

                    descripcion = "Es un juego de palabras fácil, lo admitimos.";
                    descripcLbl.Text = descripcion;

                break;

                case 26:

                    descripcion = "Otra broma fácil, ¿y qué más da?";
                    descripcLbl.Text = descripcion;

                break;

                case 27:

                    descripcion = "Una enorme viga en un yermo desolador, con reacciones en \ntodas la direcciones y buena resistencia al momento flector.";
                    descripcLbl.Text = descripcion;

                break;

                case 28:

                    descripcion = "No se necesita tener una visión de rayos x para saber que algo no está bien.";
                    descripcLbl.Text = descripcion;

                break;

                case 29:

                    descripcion = "Arma de destrucción masiva imparable.";
                    descripcLbl.Text = descripcion;

                break;



            }
        }
    }
}

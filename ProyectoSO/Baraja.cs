using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSO
{
    internal class Baraja : Carta //la baraja coje las cartas
    {
        public int numero_cartas { get; set; } //esta será la mano del jugador
        public int jugador { get; set; } //hay que asignar a la baraja su jugador o user

        // 1) generar una lista entera con todas las cartas para cada jugador,
        //esas son todas las posibilidades dentro de la base de datos
        // 2) De esa lista generamos la mano del jugador aleatoriamente teniendo en cuenta que algunas se pueden repetir
       
        //1
        public void inicializar_Cartas(string mensaje)

            //el mensaje es id/nombre/fuerza/tipo/repetible....
        {
            string[] trozos = mensaje.Split('/');
            int l = trozos.Length;
            Carta[] Todas = new Carta[l/5]; //en la base datos hay l cartas dividido por 5, se podrá mejorar
            for (int i = 0; i < l/5 - 1; i=i+5)
            {
                Todas[i] = new Carta();
                Todas[i].id = Convert.ToInt32(trozos[i]);
                Todas[i].nombre = trozos[i+1];
                Todas[i].fuerza = Convert.ToInt32(trozos[i+2]);
                Todas[i].tipo = Convert.ToInt32(trozos[i+3]);
                Todas[i].repetible = Convert.ToInt32(trozos[i+4]);

            }

        }

        //2

        public void Generar_Mano()
        {


            Random random = new Random();



        }


    }

  
}
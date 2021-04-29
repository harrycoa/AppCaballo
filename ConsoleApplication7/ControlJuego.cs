using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication7
{
    /**
 * la clase Principal es la encargada de pedir los datos, asi como de
 * validar su introduccion
 */
    public class ControlJuego
    {
        /**
         * Atributos de la clase Principal
         */
        Tablero tablero;
        int longitud, inix, iniy;
        Juego juego;
        /**
         * Constructor sin parametros
         */
        public ControlJuego()
        {//intentar
            try
            {
                do
                {
                   
                    Console.Clear();
                    Console.WriteLine("\n");
                    Console.WriteLine(" SALTO DEL CABALLO");
                    
                    
                    Console.Write(" Ingrese el tamaño del tablero: ");
                    longitud = int.Parse(Console.ReadLine());
                }
                while (longitud < 5);
                tablero = new Tablero(longitud);

                do
                {
                   
                    //Console.ForegroundColor = ConsoleColor.Yellow;                  
                    Console.Write("\n Ingrese Fila de Inicio: ");
                    inix = int.Parse(Console.ReadLine());
                    Console.Write("\n Ingrese Columna de Inicio: ");
                    iniy = int.Parse(Console.ReadLine());
                    Console.Write("\n");
                }
                while (inix >= longitud || iniy >= longitud);

            }
            //captura
            catch (Exception e)
            {
                Console.WriteLine("Hay un error al introducir los datos" + "\n");
            }
            
            Console.WriteLine("La Posicion Inicial Del Caballo ES:" + "[" + inix + "," + iniy + "]");
            Console.WriteLine(" ");
             tablero.mostrar(longitud);
            juego = new Juego(inix, iniy);

            if (juego.jugar(tablero) == true)
            {
                Console.WriteLine("\n" + "\n");
                tablero.mostrar(longitud);
                Console.WriteLine(" ");
                
                Console.WriteLine("El Caballo Recorrio Correctamente el Tablero..!!" + "\n");

            }
            else
            {
                Console.WriteLine("\n" + "\n");
                tablero.mostrar(longitud);
                Console.WriteLine(" ");
                
                Console.WriteLine(" NO.. es posible recorrer el tablero..!!");
            }
             
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication7
{/**
 * Representa un tablero con sus diferentes caracteristicas
 */
    public class Tablero
    {
        /**
         * Atributos de la clase tablero
         */
        public int[,] tabla;
        public int longitud;
        /**
         * Constructor com parametros
         * @param longitud La longitud del tablero
         */
        public Tablero(int longitud)
        {
            tabla = new int[longitud, longitud];
            this.longitud = longitud;
        }

        /**
         * Imprime por pantalla el tablero
         * @param longitud La longitud del tablero de ajedrez
         */
        public void mostrar(int longitud)
        {

            for (int i = 0; i < longitud; i++)
                for (int j = 0; j < longitud; j++)
                {
                    if (j < longitud - 1)
                    {
                        if (tabla[i, j] < 10)
                        {
                            //Console.ForegroundColor = ConsoleColor.Blue;                  
                            Console.Write(" "+tabla[i, j] + " ");
                           // Console.ForegroundColor = ConsoleColor.Blue;

                        }
                        else
                        {
                            if (tabla[i, j] < 100)
                            {
                              //  Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write(" " + tabla[i, j] + " ");
                            }
                            else
                                Console.Write(" " + tabla[i, j] + " ");
                        } //fin del primer else
                    } //fin del primer if
                    else
                        Console.Write(" " + tabla[i, j] + "\n");
                }           
        }

    }
}
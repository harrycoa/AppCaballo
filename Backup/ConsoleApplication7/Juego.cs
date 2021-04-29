using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication7
{/**
 * Representa un juego con sus diferentes caracteristicas
 */
    public class Juego
    {
        /**
         * Atributos de la clase juego
         */
        int x, y;
        int nuevax = 0, nuevay = 0, solx = 0, soly = 0, total = 0;
        /**
         * Constructor com parametros
         * @param x La coordenada x del punto de partida
         * @param y La coordenada y del punto de partida
         */
        public Juego(int x, int y)
        {
            
            this.x = x;
            
            this.y = y;
        }

        /**
         * Devuelve verdadero si recorre todo el tablero
         * @param tabla El tablero donde se desarrolla el juego
         * @return devuelve "true" si es capaz de recorrer todo el tablero
         * correctamente
         */
        public bool jugar(Tablero tabla)
        {
            for (int num = 1; num < tabla.longitud * tabla.longitud + 1; num++)
            {
                tabla.tabla[x,y] = num;

                if ((mover(tabla, x, y, num) == false && num < tabla.longitud * tabla.longitud - 1))
                    return false;
            }

            return true;
        }

        /**
         * Devuelve falso si no puede realizarse el movimiento
         * @param tabla El tablero donde se desarrolla el juego
         * @param xx La coordenada x del punto de partida
         * @param yy La coordenada y del punto de partida
         * @param num El numero de casilla recorrida
         * @return devuelve "false" si no es posible recorrer todo el tablero
         */
        public bool mover(Tablero tabla, int xx, int yy, int num)
        {

            int acesible, minacesible;
            minacesible = 9;
            solx = xx;
            soly = yy;

            for (int i = 1; i < 9; i++)
            { //mirar si es 9 o es 8
                if (saltar(tabla, i, x, y, nuevax, nuevay) == true)
                {
                    acesible = contar(tabla, nuevax, nuevay);
                    if ((acesible < minacesible) && ((acesible > 0) ||
                    ((acesible == 0) && (num == tabla.longitud * tabla.longitud - 1))))
                    {

                        minacesible = acesible;
                        solx = nuevax;
                        soly = nuevay;
                    } //fin del segundo if
                } //fin del primer if
            } //fin del for
            x = solx;
            y = soly;
            return (minacesible < 9);
        }

        /**
         * Devuelve falso si el salto no es posible
         * @param tabla El tablero donde se desarrolla el juego
         * @param i Indica el tipo de salto a realizar
         * @param valex La coordenada x de la casilla actual
         * @param valey La coordenada y de la casilla actual
         * @param nx La coordenada x de la casilla a la que salta
         * @param ny La coordenada y de la casilla a la que salta
         * @return devuelve "false" si no es posible realizar el salto
         */
        public bool saltar(Tablero tabla, int i, int valex, int valey, int nx,
                              int ny)
        {
            nuevax = nx;
            nuevay = ny;
            switch (i)
            {
                case 1:
                    nuevax = valex - 1;
                    nuevay = valey - 2;
                    break;
                case 2:
                    nuevax = valex - 2;
                    nuevay = valey - 1;
                    break;
                case 3:
                    nuevax = valex - 2;
                    nuevay = valey + 1;
                    break;
                case 4:
                    nuevax = valex - 1;
                    nuevay = valey + 2;
                    break;
                case 5:
                    nuevax = valex + 1;
                    nuevay = valey + 2;
                    break;
                case 6:
                    nuevax = valex + 2;
                    nuevay = valey + 1;
                    break;
                case 7:
                    nuevax = valex + 2;
                    nuevay = valey - 1;
                    break;
                case 8:
                    nuevax = valex + 1;
                    nuevay = valey - 2;
                    break;
               // default:Console.WriteLine("La opcion elegida es incorrecta." + "\n");
            } //fin del switch           
            
            return ((0 <= nuevax) && (nuevax < tabla.longitud) && (0 <= nuevay) &&
                    (nuevay < tabla.longitud) && (tabla.tabla[nuevax,nuevay] == 0));
        }

        /**
         * Devuelve el numero de casillas a las que puede saltar el caballo
         * desde una posicion dada
         * @param tabla El tablero donde se desarrolla el juego
         * @param x La coordenada x de la casilla actual
         * @param y La coordenada y de la casilla actual
         * @return accion El numero de casillas a las que se podria saltar desde
         * la casilla actual
         */
        public int contar(Tablero tabla, int x, int y)
        {

            int accion = 0, i, nx = 0, ny = 0;

            for (i = 1; i < 9; i++)
            {
                if (saltarSimulado(tabla, i, x, y, nx, ny))
                    accion++;
            }
            return accion;
        }

        /**
         * Metodo llamado desde "contar" que simula los saltos que puede dar
         * el caballo desde una posicion dada, y devuelve falso si el salto no
         * es posible
         * @param tabla El tablero donde se desarrolla el juego
         * @param i Indica el tipo de salto a realizar
         * @param valex La coordenada x de la casilla actual
         * @param valey La coordenada y de la casilla actual
         * @param nx La coordenada x de la casilla a la que salta
         * @param ny La coordenada y de la casilla a la que salta
         * @return devuelve "false" si no es posible realizar el salto
         */
        public bool saltarSimulado(Tablero tabla, int i, int valex, int valey, int nx, int ny)
        {
            switch (i)
            {
                case 1:
                    nx = valex - 1;
                    ny = valey - 2;
                    break;
                case 2:
                    nx = valex - 2;
                    ny = valey - 1;
                    break;
                case 3:
                    nx = valex - 2;
                    ny = valey + 1;
                    break;
                case 4:
                    nx = valex - 1;
                    ny = valey + 2;
                    break;
                case 5:
                    nx = valex + 1;
                    ny = valey + 2;
                    break;
                case 6:
                    nx = valex + 2;
                    ny = valey + 1;
                    break;
                case 7:
                    nx = valex + 2;
                    ny = valey - 1;
                    break;
                case 8:
                    nx = valex + 1;
                    ny = valey - 2;
                    break;
               // default:  Console.WriteLine("La opcion elegida es incorrecta." + "\n"); 
            } //fin del switch
            
            
            return ((0 <= nx) && (nx < tabla.longitud) && (0 <= ny) &&
                    (ny < tabla.longitud) && (tabla.tabla[nx,ny] == 0));
        }

    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace BuscaMinas
{
    public class Buscaminas
    {
        //Aquí cree dos campos de juego, uno visual y otro real, este ultimo es el se va a usar para el juego.
        private char[,] game_Field_Real;
        private char[,] game_Field_Visual;
        private int filas;
        private int columnas;
        private int numMinas;
        private int minasDescubiertas;
        //Acá añadí una variable que determine cuantas areas sin bombas hay.
        private int clear_Areas;

        public void Jugar()
        {
            //Este es la instancia de la clase Validations para llamar a los metodos de validaciones correspondientes.
            //Los metodos de esta clase son: input_Int, Validate_Bombs, input_Index.
            Validations main_Validation = new Validations();

            Console.WriteLine("¡Welcome to the Minesweeper!");
            
            filas = main_Validation.input_Int("Enter the number of rows to the Game: ", 5);
            columnas = main_Validation.input_Int("Enter the number of colums to the Game: ", 5);
            numMinas = main_Validation.validate_Bombs(columnas, filas);

            InicializarCampoJuego();
            ColocarMinas();
            minasDescubiertas = 0;
            //Acá le asigno el valor a la variable de areas limpias, que basicamente
            //el total de campos generados por el usuario menos el número de minas que ingreso el usuario
            clear_Areas = filas * columnas - numMinas;

            //A continuación esta el ciclo fue cambiado dado que el punto 6 dice que apenas descubra una mina termine el juego
            //Además se organizo el if, para que termine con el else
            while (minasDescubiertas < 1)
            {
                Console.Clear();
                //Aquí llama al MostrarCampoJuego y le asigna como parametro el campo visual
                //que es donde solo habran "#"
                MostrarCampoJuego(game_Field_Visual);


                int fila = main_Validation.input_Index($"Enter the row position, between 0-{filas - 1}: ", filas);
                int columna = main_Validation.input_Index($"Enter the column position, between 0-{columnas - 1}: ", columnas);

                //Acá dejé el campo de juego Real que es donde están las minas
                //para que dado que caso que el jugador encuentre una bomba finalice el juego.
                if (game_Field_Real[fila, columna] == '*')
                {
                    Console.Clear();
                    //Acá muestra el campo Real, para que el jugador pueda ver donde estaban las bombas
                    MostrarCampoJuego(game_Field_Real);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡Boom!You found a bomb. Game Over...");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Original base code by Teacher Edwin!");
                    Console.WriteLine("Translation by the other Edwin (Student)!");
                    Console.ResetColor();
                    minasDescubiertas++;
                }
            
                //Esto tiene relación con lo anterior, Si no ha encontrado minas y limpio todas las
                //areas pues significa que ganó
                else if (clear_Areas == 0)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You won, buddy!");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Original base code by Teacher Edwin!");
                    Console.WriteLine("Translation by the other Edwin (Student)!");
                    Console.ResetColor();
                    break;
                }

                else
                {
                    //Esto sigue siendo lo mismo, solo que añadí que en el campo visual tambien se elminen los "#"
                    game_Field_Real[fila, columna] = ' ';
                    game_Field_Visual[fila, columna] = ' ';
                    //Acá incluye el mensaje "Nothing on that area" para indicar que se salvo por ese intento
                    Console.WriteLine("Nothing on that area");
                    //Además acá va restando las areas limpias para luego, si ya no quedan areas sin bombas y el
                    //jugador se determine no piso ninguna mina, se determine que ganó.
                    clear_Areas--;
                }
                //Esto no le encontré utilidad, dado que el punto 6 dice "cuando el
                //usuario seleccione una posición que contenga una bomba el juego terminará"
                //if (minasDescubiertas == numMinas)
                //{
                //    minasDescubiertas++;
                //    Console.Clear();
                //    MostrarCampoJuego();
                //}
            }

            Console.WriteLine("¡Thanks for Play! Press any keyboard to exit...");
        }

        //Esta funciona incluye ambas matrices, tanto la visual
        //como la real, para poner los "#" en el campo
        private void InicializarCampoJuego()
        {
            game_Field_Real = new char[filas, columnas];
            game_Field_Visual = new char[filas, columnas];
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    game_Field_Real[i, j] = '#';
                    game_Field_Visual[i, j] = '#';
                }
            }
        }

        private void ColocarMinas()
        {
            Random random = new Random();
            int minasColocadas = 0;
            while (minasColocadas < numMinas)
            {
                int fila = random.Next(filas);
                int columna = random.Next(columnas);
                if (game_Field_Real[fila, columna] != '*')
                {
                    game_Field_Real[fila, columna] = '*';
                    minasColocadas++;
                }
            }
        }
        //A esta función le añadí un parametro, para que cuando se llamada me permita
        //mostrar el Campo del juego con "#" y cuando acabe el juego me permita llamar al campo donde
        //se ven las minas, para que el jugador logre conocer donde estaban las bombas.
        private void MostrarCampoJuego(char[,] game_Field)
        {
            Console.WriteLine("Field Game:");
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    Console.Write(game_Field[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace BuscaMinas
{
    public class Validations
    {

        public int input_Int(string request, int limit)
        {
            int num;
            bool sentinel = true;
            do
            {
                Console.WriteLine(request);
                if (int.TryParse(Console.ReadLine(), out num))
                {
                    if (num <= limit && num >= 0) sentinel = false;
                    else Console.WriteLine($"The size of the map is limited to {limit}");
                }
                else Console.WriteLine("The value isn't a number valid: ");
            } while (sentinel);
            return num;
        }

        public int input_Index(string request, int limit)
        {
            int num;
            bool sentinel = true;
            do
            {
                Console.WriteLine(request);
                if (int.TryParse(Console.ReadLine(), out num))
                {
                    if (num < limit && num > -1) sentinel = false;
                    else Console.WriteLine($"The size of the map is limited to 0-{limit} ");
                }
                else Console.WriteLine("The value isn't a number valid: ");
            } while (sentinel);
            return num;
        }
        public int validate_Bombs(int value_X, int value_Y)
        {
           int number_Boms = 0;
           bool sentile = true;
           while(sentile)
            {
                number_Boms = input_Int("Enter the number of bombs", value_X * value_Y);
                if (number_Boms < value_X * value_Y) sentile = false ;

                else Console.WriteLine($"The number of boms is more higher than map,{value_X * value_Y}");

            }
            return number_Boms;
        }


    }
}

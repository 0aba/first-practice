using System.Globalization;


namespace Program5
{
    class Program5
    {
        public static void Main()
        {
            Console.WriteLine("Введите число a: "); // x
            float numA = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Введите число b: "); // y
            float numB = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            /*
             * y = k * x + b
             *  b = 2 // для двух наклонных границ
             *
             *  1)
             *  (x, y): (-2, -3)
             *
             *  -3 = -2 * k + 2 => k = 2.5 
             *
             * // левая граница
             * Форумала для кода: ( y - 2 ) / 2.5 = x 
             *
             *  2)
             *  (x, y): (2, -3)
             *
             *  -3 = 2 * k + 2 => k = -2.5
             * 
             * // правая граница
             * Форумала для кода: ( y - 2 ) / -2.5 = x 
             */
 
            // f перед числом нужна для того, чтобы исправить баг когда 0.8 != 0.8 т.к. один имеет тип float, а другой double
            if (( ((numB - 2) / 2.5f) <= numA && ((numB - 2) / -2.5f) >= numA ) && (numB >= -3 && numB <= 2)) 
            {
                Console.WriteLine("Точка входит в эту область");
            }
            else
            {
                Console.WriteLine("Точка не входит в эту область");
            }

        }
    }
}
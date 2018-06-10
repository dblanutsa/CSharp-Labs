using System;

internal class Program
{
    private static int cowAmount; //количество коров

    private static int dishTypeAmount; //количество типов блюд

    private static int dishAmountForCow; //количество блюд которое может принести корова
        
    private static Random random = new Random();
            
    public static void Main(string[] args)
    {
        int[] dishArray;
        if (!IsGenerate())
        {
            DataInput(ref cowAmount, "Введите количество коров", "Количество коров должно быть между", 2, 200);
            DataInput(ref dishAmountForCow, "Введите количество блюд которое может принести корова", 
                "Количество блюд которое может принести корова должно быть между", 0, 6);
            DataInput(ref dishTypeAmount, "Введите количество видов блюд", "Количество видов блюд должно быть между", 5, 100);

            dishArray = new int[dishTypeAmount];
            
            Console.WriteLine("Введите максимальное количество блюд для каждого типа.");
            for (var i = 0; i < dishTypeAmount; i++)
            {
                Console.Write("Для " + (i + 1) + " блюда: ");
                dishArray[i] = Convert.ToInt32(Console.ReadLine());
            }
        }
        else
        {
            cowAmount = random.Next(3, 200);
            dishTypeAmount = random.Next(6, 101);
            dishAmountForCow = random.Next(1, 7);
            //генерация входных значений
            Console.WriteLine("Сгенерированые входные данные: ");
            Console.WriteLine("Количество коров - " + cowAmount);
            Console.WriteLine("Количество типов блюд  - " + dishTypeAmount);
            Console.WriteLine("Количество блюд которое может принести корова - " + dishAmountForCow);
            //генерация массива с максимальным количество блюд для каждого типа
            dishArray = new int[dishTypeAmount];
            for (var i = 0; i < dishArray.Length; i++)
            {
                dishArray[i] = random.Next(4, 21);
            }
            Console.Write("Mаксимальное количество блюд для каждого типа: ");
            ArrayPrint(dishArray);
        }
        var n = 0;
        var count = 0; //максимальное количество пищи, которую коровы могут принести на вечеринку
        for (var i = 0; i < cowAmount; i++)
        {
            Array.Sort(dishArray);
            Array.Reverse(dishArray);
            for (var j = 0; j < dishAmountForCow; j++)
            {
                if (dishArray[n] == 0)
                {
                    break;
                }
                dishArray[n] = dishArray[n] - 1;
                count++;
                n++;
            }
            n = 0;
        }
        Console.WriteLine("Mаксимальное количество пищи, которую коровы могут принести на вечеринку: " + count);
    }

    private static void DataInput(ref int value, string message1, string message2, int min, int max)
    {
        do
        {
            Console.Write(message1 + "(" + min + ", " + max + "): ");
            try
            {
                value = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException e)
            {
            }
        } while (value <= min || value >= max);
    }

    private static bool IsGenerate()
    {
        string gen;
        do
        {
            Console.Write("Сгенерировать случайные входные данные?(+, -): ");
            gen = Console.ReadLine();
        } while (!gen.Equals("+") && !gen.Equals("-"));

        return gen.Equals("+");
    }

    private static void ArrayPrint(int[] array)
    {
        if (array == null) throw new ArgumentNullException("array");
        for (var i = 0; i < array.Length; i++)
        {
           Console.Write(array[i] + " "); 
        }
        Console.WriteLine();
    }

}


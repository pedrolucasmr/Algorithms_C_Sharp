using System;

namespace sorter
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] array=NumberGenerator.NumbersToString(NumberGenerator.RandomNumberGenerator(0,1000,10));
            //double[] numbers=NumberGenerator.RandomNumberGenerator(0,1000,10);
            double[] numbers=new double[]{9,8,5,3,6,2};
            double[] SelectionSortArray=SelectionSort.Sort(numbers);
            System.Console.WriteLine("Números Desordenados:");
            for(int j=0;j<numbers.Length;j++){
                System.Console.WriteLine(numbers[j]);
            }
            System.Console.WriteLine("\n\n\nNúmeros Ordenados:");
            for(int i=0;i<SelectionSortArray.Length;i++){
                Console.WriteLine(SelectionSortArray[i]);
            }
            Console.Read();               
        }
    }
}

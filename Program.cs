using System;

namespace sorter
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int i=0;i<10;i++){
                double[] numbers=NumberGenerator.RandomNumberGenerator(0,1000000,100000);
                double[] numbers1=NumberGenerator.RandomNumberGenerator(0,1000000,100000);
                //double[] numbers=new double[]{9,8,5,3,6,2};
                System.Console.WriteLine("\n/////////////////Executando Bubble Sort/////////////////");
                BubbleSort.SortWithTest(numbers);
                System.Console.WriteLine("\n/////////////////Executando Selection Sort/////////////////");
                SelectionSort.SortWithTest(numbers1);
            }           
        }
    }
}

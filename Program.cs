using System;

namespace sorter
{
    class Program
    {
        static void Main(string[] args)
        {
            SelectionSort selectionSort= new SelectionSort();
            BubbleSort bubbleSort=new BubbleSort();
            for(int i=0;i<10;i++){
                double[] numbers=NumberGenerator.RandomNumberGenerator(0,1000000,500000);
                double[] numbers1=NumberGenerator.RandomNumberGenerator(0,1000000,500000);
                //double[] numbers=new double[]{9,8,5,3,6,2};
                //System.Console.WriteLine("\n/////////////////Executando Bubble Sort/////////////////");
                //NumberGenerator.PrintArray(bubbleSort.Sort(numbers));
                selectionSort.SortAndWrite(numbers1);
                bubbleSort.SortAndWrite(numbers);
            }           
        }
    }
}

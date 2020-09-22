using System;

namespace sorter
{
    class Program
    {
        static void Main(string[] args)
        {
            SelectionSort selectionSort= new SelectionSort();
            BubbleSort bubbleSort=new BubbleSort();
            for(int i=0;i<2;i++){
                selectionSort.SortAndWrite(NumberGeneratorService.GenerateNumbers(NumberGeneratorService.GenerateQuatity()));
                bubbleSort.SortAndWrite(NumberGeneratorService.GenerateTestArray());
            }           
        }
        public static void PrintArray(double[] array){
            for(int i=0;i<array.Length;i++){
                System.Console.WriteLine(array[i]);
            }
        }
    }
}

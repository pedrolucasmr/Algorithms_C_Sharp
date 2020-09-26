using System;
using sorter;

namespace sorter
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Selecione que rotina rodar:\n1-Rotina Aleatória\n2-Rotina de testes\n3-Rotina de testes grandes\n4-Executar testes consecutivos\n5-Executar testes de Armazenação ");
            int option=int.Parse(Console.ReadLine());
            Console.Clear();
            switch(option){
                case 1:
                    System.Console.WriteLine("Quantas vezes devemos executar?");
                    int n=int.Parse(Console.ReadLine());
                    for(int i=0;i<n;i++){
                    RunRandomAlgorithm();
                    }
                    break;
                case 2:
                    RunTests();
                    break;
                case 3:
                    RunHugeTests();
                    break;
                case 4:
                    RunConsecutiveTests();
                    break;
                case 5:
                    RunStoringTests();
                    break;
                default:
                    System.Console.WriteLine("Opção inválida");
                    break;
            }
        }
        public static void RunRandomAlgorithm(){
            System.Console.WriteLine("Iniciando Rotina Aleatória");
            SelectionSort selectionSort= new SelectionSort();
            BubbleSort bubbleSort=new BubbleSort();
            QuickSort quickSort=new QuickSort(); 
            Random rng=new Random();
            int randomAlgorithm=rng.Next(1,3);
            switch(randomAlgorithm){
                case 1:
                    selectionSort.SortAndWrite(NumberGeneratorService.GenerateNumbers());
                    break;
                case 2:
                    bubbleSort.SortAndWrite(NumberGeneratorService.GenerateNumbers());
                    break;
                case 3:
                    bubbleSort.SortAndWrite(NumberGeneratorService.GenerateNumbers());
                    break;
                default:
                    System.Console.WriteLine("Algoritmo ainda não implementado");
                    break;

            }
        }
        public static void RunTests(){
            System.Console.WriteLine("Iniciando rotina de testes");
            SelectionSort selectionSort= new SelectionSort();
            BubbleSort bubbleSort=new BubbleSort();
            QuickSort quickSort=new QuickSort(); 
            MergeSort mergeSort=new MergeSort();
            double[] numbers1=selectionSort.Sort(NumberGeneratorService.GenerateTestArray());
            double[] numbers2=bubbleSort.Sort(NumberGeneratorService.GenerateTestArray());
            double[] numbers3=quickSort.Sort(NumberGeneratorService.GenerateTestArray());
            double[] numbers4=mergeSort.Sort(NumberGeneratorService.GenerateTestArray());
            System.Console.WriteLine("Organizado: "+selectionSort.SortTest(numbers1));
            PrintArray(numbers1);
            System.Console.WriteLine("Organizado: "+bubbleSort.SortTest(numbers2));
            PrintArray(numbers2);
            System.Console.WriteLine("Organizado: "+quickSort.SortTest(numbers3));
            PrintArray(numbers3);
            System.Console.WriteLine("Oganizado: "+mergeSort.SortTest(numbers4));
            PrintArray(numbers4);
        }
        public static void RunHugeTests(){
            System.Console.WriteLine("Iniciando rotina de testes grande");
            SelectionSort selectionSort= new SelectionSort();
            BubbleSort bubbleSort=new BubbleSort();
            QuickSort quickSort=new QuickSort(); 
            MergeSort mergeSort=new MergeSort();
            double[] numbers1=selectionSort.SortAndWrite(NumberGeneratorService.GenerateNumbers());
            System.Console.WriteLine("Organizado: "+selectionSort.SortTest(numbers1));
            double[] numbers2=bubbleSort.SortAndWrite(NumberGeneratorService.GenerateNumbers());
            System.Console.WriteLine("Organizado: "+bubbleSort.SortTest(numbers2));
            double[] numbers3=quickSort.SortAndWrite(NumberGeneratorService.GenerateNumbers());
            System.Console.WriteLine("Organizado: "+quickSort.SortTest(numbers3));
            double[] numbers4=mergeSort.SortAndWrite(NumberGeneratorService.GenerateNumbers());
            System.Console.WriteLine("Oganizado: "+mergeSort.SortTest(numbers4));
        }
        public static void RunConsecutiveTests(){
            System.Console.WriteLine("Iniciando rotina de testes consecutivos. Isso deve levar um tempo.");
            SelectionSort selectionSort=new SelectionSort();
            BubbleSort bubbleSort=new BubbleSort();
            QuickSort quickSort=new QuickSort();
            MergeSort mergeSort=new MergeSort();
            string path="Results/ConsecutiveResults.txt";
            int quantity=10;
            for(int i=0;i<6;i++){
            double[] numbers=NumberGeneratorService.GenerateNumbers(quantity);
            double[] numbers1=NumberGeneratorService.GenerateNumbers(quantity);
            double[] numbers2=NumberGeneratorService.GenerateNumbers(quantity);
            double[] numbers3=NumberGeneratorService.GenerateNumbers(quantity);
            selectionSort.SortAndWrite(numbers,path);
            bubbleSort.SortAndWrite(numbers1,path);
            quickSort.SortAndWrite(numbers2,0,0,path);
            mergeSort.SortAndWrite(numbers3,0,0,path);
            quantity=quantity*10;
            }
        }
        public static void RunStoringTests(){
            System.Console.WriteLine("Iniciando rotina de testes de armazenamento");
            SelectionSort selectionSort=new SelectionSort();
            BubbleSort bubbleSort=new BubbleSort();
            QuickSort quickSort=new QuickSort();
            MergeSort mergeSort=new MergeSort();
            bubbleSort.SortAndStore(NumberGeneratorService.GenerateTestArray());
            selectionSort.SortAndStore(NumberGeneratorService.GenerateTestArray());
            quickSort.SortAndStore(NumberGeneratorService.GenerateTestArray());
            mergeSort.SortAndStore(NumberGeneratorService.GenerateTestArray());
        }
        public static void PrintArray(double[] array){
            for(int i=0;i<array.Length;i++){
                System.Console.WriteLine(array[i]);
            }
        }
    }
}

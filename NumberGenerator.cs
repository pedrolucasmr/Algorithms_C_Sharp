using System;
using System.Collections;
using System.Linq;

namespace sorter
{
    public static class NumberGenerator
    {
        public static double[] RandomNumberGenerator(int min, int max,int quantity){
            Random RNG=new Random();
            double[] numbersArray=new double[quantity];
            for(int j=0;j<quantity;j++){
             numbersArray[j]=RNG.NextDouble()*(max-min)+min;
             numbersArray[j]=Math.Round(numbersArray[j],2);
            }
            return numbersArray;
        }
        public static string[] NumbersToString(double[] initialArray){
            string[] finalArray=new string[initialArray.Length];
            for(int i=0;i<initialArray.Length;i++){
                
                finalArray[i]=Math.Round(initialArray[i],3).ToString();
            }
            return finalArray;
        }
        public static void PrintArray(double[] array){
            for(int i=0;i<array.Length;i++){
                System.Console.WriteLine(array[i]);
            }
        }
    }
}
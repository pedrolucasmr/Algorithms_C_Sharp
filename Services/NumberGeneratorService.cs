using System;
using System.Collections;
using System.Linq;

namespace sorter
{
    public static class NumberGeneratorService
    {
        public static double[] GenerateNumbers(int quantity=0){
            quantity=quantity==0?GenerateQuatity():quantity;
            Random RNG=new Random();
            double[] numbersArray=new double[quantity];
            for(int j=0;j<quantity;j++){
             numbersArray[j]=RNG.Next()+RNG.NextDouble();
             numbersArray[j]=Math.Round(numbersArray[j],2);
            }
            return numbersArray;
        }
        public static int GenerateQuatity(){
            Random RNG=new Random();
            int result;
            do{
                result=RNG.Next();
            }while(result<500000 || result>1000000);
            return result;
        }
        public static double[] GenerateTestArray(){
            Random RNG=new Random();
            double[] testArray=new double[11];
            for(int i=0;i<=10;i++){
                testArray[i]=RNG.NextDouble()*10;
                testArray[i]=Math.Round(testArray[i],2);
            }
            return testArray;
        }        
    }
}
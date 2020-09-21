using System;
using System.Collections;

namespace sorter
{
    public class BubbleSort:ISortingAlgorithm
    {
        public string Name {get;set;}="Bubble Sort";
        public string TimeNotation {get;set;}="O(N^2)";
        public string SpaceNotation {get;set;}="O(1)";
        public TimeSpan RunStart {get;set;}
        public TimeSpan runEnd;
        public TimeSpan RunEnd {get=>runEnd;set=>SetRunEnd();}
        public void SetRunEnd(){
            runEnd=DateTime.Now.TimeOfDay;
            TotalTime=RunEnd.Subtract(RunStart);
        }
        public TimeSpan TotalTime {get;set;}
        public double[] Sort(double[] array){
            System.Console.WriteLine("\n/////////////////Executando Bubble Sort/////////////////");
            for(int i=0;i<array.Length-1;i++){
                bool swapped=false;
                for(int j=0;j<array.Length-i-1;j++){
                    if(array[j+1]<array[j]){
                        double aux=array[j];
                        array[j]=array[j+1];
                        array[j+1]=aux;
                        swapped=true;
                    }
                }
                if(swapped==false){
                    break;
                }
            }
            return array;
        }
        public double[] SortAndWrite(double[] array){
            System.Console.WriteLine("\n/////////////////Executando Bubble Sort/////////////////");
            this.RunStart=DateTime.Now.TimeOfDay;
            for(int i=0;i<array.Length-1;i++){
                    for(int j=0;j<array.Length-i-1;j++){
                        if(array[j+1]<array[j]){
                            double aux=array[j];
                            array[j]=array[j+1];
                            array[j+1]=aux;
                        }
                    }
            }
            this.SetRunEnd();
            AlgorithmRunWriter.WriteRun(this.Name,this.TimeNotation,this.SpaceNotation,this.RunStart,this.RunEnd,this.TotalTime,array.Length);
            return array;
        }
        public bool SortTest(double[] array){
            System.Console.WriteLine("Teste de funcionalidade. Algoritmo: Bubble Sort");
            for(int i=0;i<array.Length-1;i++){
                if(array[i]>array[i+1]){
                    return false;
                }
            }
            return true;
        }
    }
}
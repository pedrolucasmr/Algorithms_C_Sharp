using System;
using System.Collections;


namespace sorter
{
    public class SelectionSort:ISortingAlgorithm
    {
        public string Name {get;set;}="Selection Sort";
        public string TimeNotation{get;set;}="O(n^2)";
        public string SpaceNotation{get;set;}="O(1)";
        public TimeSpan RunStart {get;set;}
        public TimeSpan runEnd {get;set;}
        public TimeSpan RunEnd {get=>runEnd;set=>SetRunEnd();}
        public void SetRunEnd(){
            runEnd=DateTime.Now.TimeOfDay;
            TotalTime=RunEnd.Subtract(RunStart);
        }
        public TimeSpan TotalTime {get;set;}
        public double[] Sort(double[] array){
            System.Console.WriteLine("\n/////////////////Executando Selection Sort/////////////////");
            int n=array.Length;
            for(int i=0;i<n-1;i++){
                int minIndex=i;
                for(int j=i+1;j<n;j++){
                    if(array[j]<array[minIndex]){
                        minIndex=j;                        
                    }                    
                }
                double aux=array[minIndex];
                        array[minIndex]=array[i];
                        array[i]=aux;
            }
            return array;
        }
        public double[] SortAndWrite(double[] array){
            System.Console.WriteLine("\n/////////////////Executando Selection Sort/////////////////");
            this.RunStart=DateTime.Now.TimeOfDay;
            int n=array.Length;
            for(int i=0;i<n-1;i++){
                int minIndex=i;
                for(int j=i+1;j<n;j++){
                    if(array[j]<array[minIndex]){
                        minIndex=j;                        
                    }                    
                }
                double aux=array[minIndex];
                        array[minIndex]=array[i];
                        array[i]=aux;
            }
            this.SetRunEnd();
            AlgorithmRunWriter.WriteRun(this.Name,this.TimeNotation,this.SpaceNotation,this.RunStart,this.RunEnd,this.TotalTime,array.Length);
            return array;
        }
        public bool SortTest(double[] array){
            System.Console.WriteLine("Teste de funcionalidade. Algoritmo: Selection Sort");
            for(int i=0;i<array.Length-1;i++){
                if(array[i]>array[i+1]){
                    return false;
                }
            }
                return true;
        }
    }
}
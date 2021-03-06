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
        
        public TimeSpan TotalTime {get;set;}
        public int Entries {get;set;}
        public void SetRunEnd(){
            runEnd=DateTime.Now.TimeOfDay;
            TotalTime=RunEnd.Subtract(RunStart);
        }
        public double[] Sort(double[] array){
            System.Console.WriteLine("\n/////////////////Executando Bubble Sort/////////////////");
            this.Entries=array.Length;
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
        public double[] SortAndWrite(double[] array,string path="Results/Results.txt"){
            this.RunStart=DateTime.Now.TimeOfDay;
            Sort(array);
            this.SetRunEnd();
            WriterService.WriteRun(this,path);
            return array;
        }
        public void SortAndStore(double[] array){
            this.RunStart=DateTime.Now.TimeOfDay;
            Sort(array);
            this.SetRunEnd();
           if(WriterService.StoreRun(this)){
               System.Console.WriteLine("Informações armazenadas com sucesso");
           }
           else{
               System.Console.WriteLine("Fala ao armazenar informações");
           }
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
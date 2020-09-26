using System.ComponentModel;
using System;
using System.Threading;
using System.Collections;

namespace sorter
{
    public class QuickSort:ISortingAlgorithm
    {
        public string Name {get;set;}="Quick Sort";
        public string TimeNotation {get;set;} ="O(n*log n)";
        public string SpaceNotation {get;set;}="O(log n)";
        public TimeSpan RunStart {get;set;}
        public TimeSpan runEnd;
        public TimeSpan RunEnd{get=>runEnd;set=>SetRunEnd();}
        
        public TimeSpan TotalTime {get;set;}
        public int Entries {get;set;}
        public void SetRunEnd(){
            runEnd=DateTime.Now.TimeOfDay;
            TotalTime=runEnd.Subtract(RunStart);
        }
        private void _Sort(double[] array,int start,int end){            
            if(start<end){
                int partition=Partition(array,start,end);
                _Sort(array,start,partition-1);
                _Sort(array,partition+1,end);
            }
            
        }
        public double[] Sort(double[] array,int start=0,int end=0){
            System.Console.WriteLine("\n/////////////////Executando Quick Sort/////////////////");
            this.Entries=array.Length;
            end=end==0?array.Length-1:end;
            _Sort(array,start,end);
            return array;
        }
        public int Partition(double[] array,int start, int end){
            double pivot=array[(start+end)/2];
            int i=(start-1);
            for(int j=start;j<=end-1;j++){
                if(array[j]<pivot){
                    i++;                    
                    double aux=array[i];
                    array[i]=array[j];
                    array[j]=aux;
                }
            }
            double aux2=array[i+1];
            array[i+1]=array[end];
            array[end]=aux2;
            return i+1;
        }

        public double[] SortAndWrite(double[] array, int start=0, int end=0,string path="Results/Results.txt"){
            this.RunStart=DateTime.Now.TimeOfDay;
            Sort(array,start,end);
            this.SetRunEnd();
            WriterService.WriteRun(this,path);
            return array;
        }
        public void SortAndStore(double[] array, int start=0,int end=0){
            this.RunStart=DateTime.Now.TimeOfDay;
            Sort(array,start,end);
            this.SetRunEnd();
            if(WriterService.StoreRun(this)){
                System.Console.WriteLine("Informações armazenadas com sucesso");
            }
            else{
                System.Console.WriteLine("Falha ao armazenar informações");
            }
        }
        public bool SortTest(double[] array){
            System.Console.WriteLine("Teste de funcionalidade. Algoritmo: "+this.Name);
            for(int i=0;i<array.Length-1;i++){
                if(array[i+1]<array[i]){
                    return false;
                }
            }
            return true;
        }

    }
}
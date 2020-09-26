using System;
using System.Collections;

namespace sorter
{
    public class MergeSort : ISortingAlgorithm
    {
        public string Name {get;set;}="Merge Sort";
        public string TimeNotation {get;set;}="O(n*log n)";
        public string SpaceNotation{get;set;}="O(n)";
        public TimeSpan RunStart {get;set;}
        private TimeSpan runEnd;
        public TimeSpan RunEnd{get=>runEnd;set=>SetRunEnd();}
        public TimeSpan TotalTime {get;set;}
        public int Entries {get;set;}
        public void SetRunEnd(){
            this.runEnd=DateTime.Now.TimeOfDay;
            this.TotalTime=RunEnd.Subtract(RunStart);
        }
        public void Merge(double[] array,int start, int middle, int end){
            int n1=middle-start+1;
            int n2=end-middle;
            double[] subArray1=new double[n1];
            double[] subarray2=new double [n2];
            for(int i=0;i<n1;++i){
                subArray1[i]=array[start+i];
            }
            for(int j=0;j<n2;++j){
                subarray2[j]=array[middle+1+j];
            }
            int subArray1I=0;
            int subArray2I=0;
            int mainArrayI=start;
            while(subArray1I<n1&&subArray2I<n2){
                if(subArray1[subArray1I]<=subarray2[subArray2I]){
                    array[mainArrayI]=subArray1[subArray1I];
                    subArray1I++;
                }
                else{
                    array[mainArrayI]=subarray2[subArray2I];
                    subArray2I++;
                }
                mainArrayI++;
            }
            while(subArray1I<n1){
                array[mainArrayI]=subArray1[subArray1I];
                subArray1I++;
                mainArrayI++;
            }
            while(subArray2I<n2){
                array[mainArrayI]=subarray2[subArray2I];
                subArray2I++;
                mainArrayI++;
            }
        }
        public void _Sort(double[] array, int start, int end){
            if(start<end){
                int middle=(start+end)/2;
                _Sort(array,start,middle);
                _Sort(array,middle+1,end);
                Merge(array,start,middle,end);
            }
        }
        public double[] Sort(double[] array,int start=0,int end=0){
            System.Console.WriteLine("\n/////////////////Executando Merge Sort/////////////////");
            this.Entries=array.Length;
            end=end==0?array.Length:end;
            _Sort(array,start,end-1);
            return array;
        }
        public double[] SortAndWrite(double[] array,int start=0,int end=0,string path="Results/Results.txt"){
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
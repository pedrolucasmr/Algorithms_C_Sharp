using System;
using System.Collections;


namespace sorter
{
    public static class SelectionSort
    {
        public static double[] Sort(double[] array){
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
        public static double[] SortWithTest(double[] array){
            AutoTest at= new AutoTest();
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
            at.SetEnd(DateTime.Now);
            at.WriteTest("O(n²)","O(1)", "Selection Sort",array.Length);
            return array;
        }
    }
}
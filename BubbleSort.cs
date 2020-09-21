using System;
using System.Collections;

namespace sorter
{
    public class BubbleSort
    {
        public static double[] Sort(double[] array){
            for(int i=0;i<array.Length-1;i++){
                int index=i;
                    for(int j=i+1;j<array.Length;j++){
                        if(array[j]<index){
                            double aux=array[index];
                            array[index]=array[j];
                            array[j]=aux;
                        }
                    }
            }
            return array;
        }
        public static double[] SortWithTest(double[] array){
            AutoTest at=new AutoTest();
            for(int i=0;i<array.Length-1;i++){
                int index=i;
                    for(int j=i+1;j<array.Length;j++){
                        if(array[j]<index){
                            double aux=array[index];
                            array[index]=array[j];
                            array[j]=aux;
                        }
                    }
            }
            at.SetEnd(DateTime.Now);
            at.WriteTest("O(n²)","O(1)","Bubble Sort",array.Length);
            return array;
        }
    }
}
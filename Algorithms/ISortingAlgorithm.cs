using System;
using System.Collections;

namespace sorter
{
    public interface ISortingAlgorithm
    {
        public string Name {get;set;}
        public string TimeNotation {get;set;}
        public string SpaceNotation {get;set;}
        public TimeSpan RunStart {get;set;}
        public TimeSpan RunEnd {get;set;}
        public abstract void SetRunEnd();
        public TimeSpan TotalTime{get;set;}
        public int Entries {get;set;}
        
         public virtual double[] Sort(double[] array){return array;}
         public abstract bool SortTest(double[] array);
         public virtual double[] SortAndWrite(double[] array){return array;}
         public virtual void SortAndStore(double[] array){}
    }
}
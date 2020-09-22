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
        
         public abstract double[] Sort(double[] array);
         public abstract bool SortTest(double[] array);
         public abstract double[] SortAndWrite(double[] array);
    }
}
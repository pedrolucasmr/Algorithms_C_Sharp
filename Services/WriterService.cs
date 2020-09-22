using System;
using System.Threading;
using System.IO;
using System.Text;

namespace sorter
{
    public static class WriterService
    {
        /*public TimeSpan Start {get;set;}
        private TimeSpan end;
        public TimeSpan End{
            get=> end;
            set=>SetEnd(DateTime.Now);
        }
        public void SetEnd(DateTime value){
            end=value.TimeOfDay;
            this.TotalTime=end.Subtract(Start);            
        }
        public AlgorithmRunWriter(){
            Start=DateTime.Now.TimeOfDay;
        }
        public TimeSpan TotalTime {get;set;}*/
        public static void WriteRun(string name, string timeNotation, string spaceNotation, TimeSpan start, TimeSpan end, TimeSpan totalTime, int entries){
            using(StreamWriter sw= new StreamWriter("Results/Results.txt",true)){                
                sw.WriteLine("----------------------------------------------------");
                sw.WriteLine("Algoritmo: "+name);
                sw.WriteLine("Horario de ínicio da execução: "+start);
                sw.WriteLine("Horário de Término da execução: "+end);
                sw.WriteLine("Tempo total de execução: "+totalTime);
                sw.WriteLine("Número de elementos ordenados: "+entries);
                sw.WriteLine("Notação de Tempo média do Algoritmo: "+timeNotation);
                sw.WriteLine("Notação de Espaço média do Algoritmo: "+spaceNotation);
                sw.WriteLine("----------------------------------------------------");
            }
        }
    }
}
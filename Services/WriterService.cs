using System;
using System.Threading;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace sorter
{
    public static class WriterService
    {
        public static void WriteRun(ISortingAlgorithm algorithm,string path){
            using(StreamWriter sw= new StreamWriter(path,true)){                
                sw.WriteLine("----------------------------------------------------");
                sw.WriteLine("Algoritmo: "+algorithm.Name);
                sw.WriteLine("Horario de ínicio da execução: "+algorithm.RunStart);
                sw.WriteLine("Horário de Término da execução: "+algorithm.RunEnd);
                sw.WriteLine("Tempo total de execução: "+algorithm.TotalTime);
                sw.WriteLine("Número de elementos ordenados: "+algorithm.Entries);
                sw.WriteLine("Notação de Tempo média do Algoritmo: "+algorithm.TimeNotation);
                sw.WriteLine("Notação de Espaço média do Algoritmo: "+algorithm.SpaceNotation);
                sw.WriteLine("----------------------------------------------------");
            }
        }
    }
}
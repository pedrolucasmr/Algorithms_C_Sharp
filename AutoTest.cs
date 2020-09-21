using System;
using System.Threading;
using System.IO;
using System.Text;

namespace sorter
{
    public class AutoTest
    {
        public TimeSpan Start {get;set;}
        private TimeSpan end;
        public TimeSpan End{
            get=> end;
            set=>SetEnd(DateTime.Now);
        }
        public void SetEnd(DateTime value){
            end=value.TimeOfDay;
            this.TotalTime=end.Subtract(Start);            
        }
        public AutoTest(){
            Start=DateTime.Now.TimeOfDay;
        }
        public TimeSpan TotalTime {get;set;}
        public void WriteTest(string timeNotation, string spaceNotation, string alg, int entries){
            string messagePart1="Teste com "+alg+": iniciado em "+this.Start.ToString()+" e terminado em "+this.End.ToString()+".";
            string messagePart2="Total de "+this.TotalTime+" minutos de execução com "+entries+" valores. Notação de tempo média do algoritmo: "+timeNotation+"; Notação de espaço média do algoritmo: "+spaceNotation;
            using(StreamWriter sw= new StreamWriter("Test.txt",true)){                
                sw.WriteLine(messagePart1);
                sw.WriteLine(messagePart2);
                sw.WriteLine("--------------");
            }
        }
    }
}
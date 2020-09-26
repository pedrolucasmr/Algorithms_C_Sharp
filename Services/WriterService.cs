using System;
using System.Threading;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;

namespace sorter
{
    public static class WriterService
    {
        public static bool StoreRun(ISortingAlgorithm algorithm){         
            string connectionString=File.ReadAllText("Data/conn.txt");
            MySqlConnection connection= new MySqlConnection(connectionString);
            MySqlCommand command= new MySqlCommand();
            try{
                connection.Open();
                command.CommandType=System.Data.CommandType.StoredProcedure;
                command.Connection=connection;
                command.CommandText="insertNewRun";
                command.Parameters.Add(new MySqlParameter("iAName",algorithm.Name));
                command.Parameters.Add(new MySqlParameter("iTimeNotation",algorithm.TimeNotation));
                command.Parameters.Add(new MySqlParameter("iSpaceNotation",algorithm.SpaceNotation));
                command.Parameters.Add(new MySqlParameter("iRunStart",algorithm.RunStart));
                command.Parameters.Add(new MySqlParameter("iRunEnd",algorithm.RunEnd));
                command.Parameters.Add(new MySqlParameter("iTotalTime",algorithm.TotalTime));
                command.Parameters.Add(new MySqlParameter("iEntries",algorithm.Entries));
                command.ExecuteNonQuery();
                return true;
            }
            catch(Exception e){
                System.Console.WriteLine(e);
                return false;
            }
            finally{
                connection.Close();
                GC.Collect();
            }
        }
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
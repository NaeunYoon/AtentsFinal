using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace gameDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectInfo = "server = localhost;"+ 
                                 "port = 3306;" +
                                 "Database = game;" +
                                 "Uid = root;" +
                                 "pwd=1234;";

            using (MySqlConnection sql = new MySqlConnection(connectInfo))
            {
                sql.Open();

                string sql1 = "update quest set 'reward' = 1000 where 'index' = 9;";

                MySqlCommand cmd1 = new MySqlCommand(sql1, sql);

                string sql2 = "select * from game.quest;";

                MySqlCommand cmd2 = new MySqlCommand(sql2, sql);

                //MySqlDataReader reader = cmd2.ExecuteReader();
                MySqlDataReader reader = cmd2.ExecuteReader();

                while (reader.Read())
                {
                    int index = (int)reader["index"];
                    string id = (string)reader["id"];
                    int reward = (int)reader["reward"];

                    Console.WriteLine(index + " "+ id + " " + reward);
                }
                reader.Close();
                sql.Close();
            }

        }
    }
}
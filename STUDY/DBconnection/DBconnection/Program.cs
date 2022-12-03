using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DBconnection
{
    //struct a
    //{
    //    public string name;
    //    public string role;
    //    public int stageNum;
    //    public int age;
    //}


    internal class Program
    {
        static void Main(string[] args)
        {
            //a stA;
            //stA.age = 10;
            //Console.WriteLine(stA.age);


            //string connectionInfo = "server = localhost;" + //내가 접속하는 SQL을 문자열로 저장
            //                        "port=3306;" +
            //                        "Database=login;" +
            //                        "Uid=root;" +
            //                        "pwd=1234";
            //using (MySqlConnection sqlon = new MySqlConnection(connectionInfo)) //데이터베이스 서버에 연결
            //{
            //    sqlon.Open();
            //    //string sql = "select * from user";
            //    //string sql = "ipdate user set str = 100 where index = '오우거'";

            //    string sql1 = "update `user2` set name = '제르딘' where `index` = 2";
            //    MySqlCommand cmd1 = new MySqlCommand(sql1, sqlon);
            //    string sql2 = "select * from `user2`";
            //    MySqlCommand cmd2 = new MySqlCommand(sql2, sqlon);

            //    MySqlDataReader r=cmd2.ExecuteReader();
            //    while (r.Read())
            //    {
            //        int id = (int)r["index"];   //컬럼명
            //        string name = (string)r["name"];    //컬럼명
            //        string address = (string)r["address"];  //컬럼명

            //        //DB 에서 tinyint(1)로 정의한 자료형
            //        //byte 로 읽는다

            //        //byte data = r.GetByte("gender");

            //        Console.WriteLine(id + "_"+name+"_"+address);
            //    }
            //    r.Close();
            //    sqlon.Close();
            //}
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sql_DBconnector;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            MySqlDB mySqlDB = new MySqlDB();

            var table = mySqlDB.Select();
            int id = 4;
            string first = "leggo";
            string last = "Naija";
            string email = "NJ@yaho.com";
            int phone = 08902445;
            string passw = "jamess";

            mySqlDB.Insert(first,last,email,phone,passw);
            Console.ReadKey();
        }
    }
}

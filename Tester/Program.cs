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

   
            mySqlDB.Delete(4);
        }
    }
}

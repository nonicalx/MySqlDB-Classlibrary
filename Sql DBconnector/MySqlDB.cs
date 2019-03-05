using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Sql_DBconnector
{
    public class MySqlDB
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        /// <summary>
        /// Constructor: Calls up the intialize meethod on object creation
        /// </summary>
        public MySqlDB()
        {
            Initialize();
        }

        /// <summary>
        /// intializes the connection to the mySql database
        /// </summary>
        private void Initialize()
        {
            server = "localhost";
            database = "testdb";
            uid = "root";
            string connect = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connect);
        }


        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {

                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Couldn't connect to the server, please contact your administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid Username or password, Please try again");
                        break;
                }
                Console.ReadKey();
                return false;
                
            }   
        }

        private bool CloseConnection()
        {
       
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public void Insert()
        {
            string query = "INSERT INTO Members (firstname, lastname, email, phoneNumber, password) VALUES('chukwudubem', 'smith', 'dubem@yahoo.com', '0904567643', '123qwwerre')";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.ExecuteNonQuery();
                Console.WriteLine("Data inserted");
                Console.ReadKey();
                this.CloseConnection();
            }
        }

        /// <summary>
        /// updates the data in the mysql database in a sepcified row with id.
        /// </summary>
        /// <param name="id"></param>
        public void Update(int id)
        {
            string query = $"UPDATE Members SET firstname='Ikechi', lastname='agu', email='nebo@gmail.com', phoneNumber='07074343343', password='qwweewre223' WHERE id={id}";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.ExecuteNonQuery();

                this.CloseConnection();
                Console.WriteLine($"Data with id {id} has been Updated");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Deletes a row in a sql database table.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            string query = $"DELETE FROM Members WHERE id= {id}";

            if (this.OpenConnection()==true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();

                this.CloseConnection();
                Console.WriteLine($"Data with id {id} has been Deleted");
                Console.ReadKey();
            }
        }

        public List<string>[] Select()
        {
            string query = "SELECT * FROM Members";

            List<string>[] list = new List<string>[6];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();
            list[4] = new List<string>();
            list[5] = new List<string>();

            if(this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //data reader start
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Reads data from Mysql database and stores them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["id"] + "");
                    list[1].Add(dataReader["firstname"] + "");
                    list[2].Add(dataReader["lastname"] + "");
                    list[3].Add(dataReader["email"] + "");
                    list[4].Add(dataReader["phoneNumber"] + "");
                    list[5].Add(dataReader["password"] + "");
                }

                //close data reader
                dataReader.Close();

                this.CloseConnection();

                return list;
            }
            else
            {
                return list;
            }
        }

        public int Count()
        {
            string query = "SELECT Count(*) From Members";
            int count = -1;

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                count = int.Parse(cmd.ExecuteScalar() + "");

                this.CloseConnection();

                return count;
            }
            else
            {
                return count;
            }
        }

        public void Backup()
        {
            throw new NotImplementedException();
        }

        public void Retore()
        {
            throw new NotImplementedException();
        }
    }

    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ConsoleApplicationAdo.net
{
    class dbOperation
    {
        static void Main(string[] args)
        {
            log4net.Config.BasicConfigurator.Configure();
            Console.WriteLine("1.CREATE TABLE ");
            Console.WriteLine("2.INSERT INTO TABLE ");
            Console.WriteLine("3..UPDATE INTO TABLE ");
            Console.WriteLine("4.DELETE TABLE ");
            Console.WriteLine("5.Exit ");
            Console.WriteLine("6.Show Table ");
            ineligible:
            Console.WriteLine("Enter a number:");
            int num = Convert.ToInt32(Console.ReadLine());
           switch (num)
            {
                case 1:
                    dbOperation.createTable();
                    Console.Read();
                    goto ineligible;
                case 2:
                    dbOperation.insertInToTable();
                    Console.Read();
                    goto ineligible;
                case 3:
                    dbOperation.updateInToTable();
                    Console.Read();
                    goto ineligible;
                case 4:
                    dbOperation.deleteTable();
                    Console.Read();
                    goto ineligible;
                case 6:
                    dbOperation.ShowTable();
                    Console.Read();
                    goto ineligible;
                case 5:
                    break;
                default:
                    Console.WriteLine("select correct option");
                    goto ineligible;
            }
           
        
        }


        public static void createTable()
        {
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(throughUsingDbConnection));
            log.Info("Enter Table Name");
            string tname = Console.ReadLine();
            log.Info("Enter Two  prperties Name");
            log.Info("Enter First Properties int type");
            string cid = Console.ReadLine();
            log.Info("Enter second properties string type");
            string cname = Console.ReadLine();
            string SqlQry = "create table  " + tname + " (" + cid + " int, " + cname + " varchar(90))";
            string constring = @"Data Source=.\AnkitSQL;Initial Catalog=Customer;Persist Security Info=True;User ID=sa;Password=125817865";
            using (SqlConnection con = new SqlConnection(constring))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(SqlQry, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Console.WriteLine("table successfully created");
                    Console.Read();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }

        }

        public static void insertInToTable()
        {
            log4net.ILog log1 = log4net.LogManager.GetLogger(typeof(throughUsingDbConnection));
            log1.Info("Enter Table Name");
            string tname1 = Console.ReadLine();
            log1.Info("Enter first properties value (int type)");
            int cIdValue = Convert.ToInt32(Console.ReadLine());
            log1.Info("Enter second properties value (string type)");
            string cNameValue = Console.ReadLine();
            string SqlQry1 = "insert into " + tname1 + " values(" + cIdValue + ",' " + cNameValue + " ')";
            string constring1 = @"Data Source=.\AnkitSQL;Initial Catalog=Customer;Persist Security Info=True;User ID=sa;Password=125817865";
            using (SqlConnection con = new SqlConnection(constring1))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(SqlQry1, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Console.WriteLine("insert successfully");
                    Console.Read();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }


        public static void updateInToTable()
        {
            log4net.ILog log3 = log4net.LogManager.GetLogger(typeof(throughUsingDbConnection));
            log3.Info("Enter Table Name Which Table you want update");
            string tableName = Console.ReadLine();
            log3.Info("Enter key properties Name");
            string key = Console.ReadLine();
            log3.Info("Enter id no");
            string id = Console.ReadLine();
            log3.Info("Enter properties Name");
            string tname = Console.ReadLine();
            log3.Info("Enter properties value");
            string value = Console.ReadLine();

           // string SqlQry3 = "drop table  " + tname3 + " ";
            string SqlQry3 = "update " + tableName + " set " + tname + "='" + value + "' where " + key + " =" + id + ";";
            string constring3 = @"Data Source=.\AnkitSQL;Initial Catalog=Customer;Persist Security Info=True;User ID=sa;Password=125817865";
            using (SqlConnection con = new SqlConnection(constring3))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(SqlQry3, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Console.WriteLine("update successfully");
                    Console.Read();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }

        public static void deleteTable()
        {
            log4net.ILog log2 = log4net.LogManager.GetLogger(typeof(throughUsingDbConnection));
            log2.Info("Enter Table Name");
            string tname2 = Console.ReadLine();
            string SqlQry2 = "drop table  " + tname2 + " ";
            string constring2 = @"Data Source=.\AnkitSQL;Initial Catalog=Customer;Persist Security Info=True;User ID=sa;Password=125817865";
            using (SqlConnection con = new SqlConnection(constring2))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(SqlQry2, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Console.WriteLine("Delete successfully");
                    Console.Read();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }
        public static void ShowTable()
        {
            log4net.ILog log2 = log4net.LogManager.GetLogger(typeof(throughUsingDbConnection));
            log2.Info("Enter Table Name");
            string tname2 = Console.ReadLine();
            log2.Info("Enter Firstkey properties Name");
            string key = Console.ReadLine();
            log2.Info("Enter second properties Name");
            string value = Console.ReadLine();

            string SqlQry2 = "select * from " + tname2 + " ";
            string constring2 = @"Data Source=.\AnkitSQL;Initial Catalog=Customer;Persist Security Info=True;User ID=sa;Password=125817865";
            using (SqlConnection con = new SqlConnection(constring2))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(SqlQry2, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Console.WriteLine("========================");
                    Console.WriteLine("" + key + "" + "   " + "" + value + "");
                    while (reader.Read())
                    {
                        
                        Console.WriteLine(reader[0].ToString() +"  "+ reader[1].ToString());
                       
                    }
                    Console.WriteLine("Table Data successfully Showing");
                    Console.Read();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }

        



    }
}

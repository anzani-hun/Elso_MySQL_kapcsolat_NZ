using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

class Program
{
    static void Main(string[] args)
        {
        //változónevek definiálása
        string connectionString, sqlStatement, output;
        MySqlConnection dbConnection;
        MySqlCommand sqlCommand;


        Console.WriteLine("Első MySQL kapcsolatom.");

        connectionString = "server=localhost;userid=root;password=;database=mo_telepulesek";
        dbConnection = new MySqlConnection(connectionString);


        //kapcsolat megnyitása
        dbConnection.Open();

        //mariaDB verzió kiíratása 1. verzió
        Console.WriteLine("A MySQL szerver verziója: " + dbConnection.ServerVersion);


        sqlStatement = "SELECT version();";
        sqlCommand = new MySqlCommand(sqlStatement, dbConnection);


        //parancs végrehajtása - a parancsok elküldése |ennek lesz egy visszatérő értéke|  kell a végére .ToString()
        output = sqlCommand.ExecuteScalar().ToString();

        //mariaDB verzió kiíratása 2. verzió
        Console.WriteLine("A MySQL szerver verziója: " + output);


        dbConnection.Close();

        Console.ReadKey();
        }
}


using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace _01._ADO.Net
{
    class Program
    {
        const string SqlConnectionString = @"Server=DESKTOP-L3ARJIL\SQLEXPRESS;Database={0};Integrated Security=true";
        static void Main(string[] args)
        {
            //create database using master
            //CreateDatabase();

            using var connection = new SqlConnection(string.Format(SqlConnectionString, "MinionsDB"));
            connection.Open();
            //01. InitialSetup(connection);
            //02. VillainNames(connection);
            //03. SqlCommand command = MinionNames(connection);
            //04. AddMinion(connection);
            //05. SqlCommand updateCommand = ChangeTownNamesCasing(connection);
            //06. SqlCommand sqlCommand;
            //    RemoveVillain(connection, out sqlCommand);
            //07. SqlCommand selectCommand;
            //    SqlDataReader reader;
            //    PrintAllMinionNames(connection, out selectCommand, out reader);
            //08. SqlCommand selectedCommand;
            //    SqlDataReader reader;
            //    IncreaseMinionAge(connection, out selectedCommand, out reader);
            //09. SqlCommand command, selectCommand;
            //    SqlDataReader reader;
            //    IncreaseAgeStoredProcedure(connection, out command, out selectCommand, out reader);
        }

        //1. Initial Setup
        private static void InitialSetup(SqlConnection connection)
        {
            //create tables
            var createTables = GetCreateTableStatements();
            foreach (var query in createTables)
            {
                ExecuteNonQuery(connection, query);
            }

            //insert values
            var insertStatements = GetInsertDataStatements();
            foreach (var query in insertStatements)
            {
                ExecuteNonQuery(connection, query);
            }
        }
        private static void ExecuteNonQuery(SqlConnection connection, string query)
        {
            using (var command = new SqlCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }
        private static string[] GetCreateTableStatements()
        {
            var result = new string[]
            {
                "CREATE TABLE Countries (Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50))",

                "CREATE TABLE Towns(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50), CountryCode INT FOREIGN KEY REFERENCES Countries(Id))",

                "CREATE TABLE Minions(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(30), Age INT, TownId INT FOREIGN KEY REFERENCES Towns(Id))",

                "CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50))",

                "CREATE TABLE Villains (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id))",

                "CREATE TABLE MinionsVillains (MinionId INT FOREIGN KEY REFERENCES Minions(Id),VillainId INT FOREIGN KEY REFERENCES Villains(Id),CONSTRAINT PK_MinionsVillains PRIMARY KEY (MinionId, VillainId))"
            };
            return result;
        }
        private static string[] GetInsertDataStatements()
        {
            var result = new string[]
            {
                "INSERT INTO Countries ([Name]) VALUES('Bulgaria'),('England'),('Cyprus'),('Germany'),('Norway')",

                "INSERT INTO Towns([Name], CountryCode) VALUES('Plovdiv', 1),('Varna', 1),('Burgas', 1),('Sofia', 1),('London', 2),('Southampton', 2),('Bath', 2),('Liverpool', 2),('Berlin', 3),('Frankfurt', 3),('Oslo', 4)",

                "INSERT INTO Minions(Name, Age, TownId) VALUES('Bob', 42, 3),('Kevin', 1, 1),('Bob ', 32, 6),('Simon', 45, 3),('Cathleen', 11, 2),('Carry ', 50, 10),('Becky', 125, 5),('Mars', 21, 1),('Misho', 5, 10),('Zoe', 125, 5),('Json', 21, 1)",

                "INSERT INTO EvilnessFactors(Name) VALUES('Super good'),('Good'),('Bad'), ('Evil'),('Super evil')",

                "INSERT INTO Villains(Name, EvilnessFactorId) VALUES('Gru', 2),('Victor', 1),('Jilly', 3),('Miro', 4),('Rosen', 5),('Dimityr', 1),('Dobromir', 2)",

                "INSERT INTO MinionsVillains(MinionId, VillainId) VALUES(4, 2),(1, 1),(5, 7),(3, 5),(2, 6),(11, 5),(8, 4),(9, 7),(7, 1),(1, 3),(7, 3),(5, 3),(4, 3),(1, 2),(2, 1),(2, 7)"
            };

            return result;
        }
        private static void CreateDatabase()
        {
            using (var connection = new SqlConnection(string.Format(SqlConnectionString, "master")))
            {
                connection.Open();

                string createDatabase = "CREATE DATABASE MinionsDB";

                using (var command = new SqlCommand(createDatabase, connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Database created successfully!");
                }

                var createTableStatements = GetCreateTableStatements();
            }
        }

        //2. Villain Names
        private static void VillainNames(SqlConnection connection)
        {
            string query = @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                   FROM Villains AS v 
                                   JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                                  GROUP BY v.Id, v.Name 
                                 HAVING COUNT(mv.VillainId) > 3 
                                  ORDER BY COUNT(mv.VillainId)";

            using (var command = new SqlCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var name = reader[0];
                        var count = reader[1];

                        Console.WriteLine($"{name} - {count}");
                    }
                }
            }
        }

        //3. Minion Names
        private static SqlCommand MinionNames(SqlConnection connection)
        {
            int id = int.Parse(Console.ReadLine());
            string villainNameQuery = "SELECT Name FROM Villains WHERE Id = @Id";
            var command = new SqlCommand(villainNameQuery, connection);
            command.Parameters.AddWithValue("@Id", id);

            var result = command.ExecuteScalar();


            string minionsQuery = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";

            if (result == null)
            {
                Console.WriteLine($"No villain with ID {id} exists in the database.");
            }
            else
            {
                Console.WriteLine($"Villain: {result}");

                using (var minionCommand = new SqlCommand(minionsQuery, connection))
                {
                    minionCommand.Parameters.AddWithValue("@Id", id);
                    using (var reader = minionCommand.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("(no minions)");
                        }
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader[0]}. {reader[1]} {reader[2]}");
                        }
                    }
                }
            }

            return command;
        }

        //4. Add Minion
        private static void AddMinion(SqlConnection connection)
        {
            string[] minionInfo = Console.ReadLine().Split();
            string minionName = minionInfo[1];
            int age = int.Parse(minionInfo[2]);
            string townName = minionInfo[3];

            string[] villainInfo = Console.ReadLine().Split();
            string villainName = villainInfo[1];

            //1
            var town = GetTownId(connection, townName);
            if (town == null)
            {
                AddTown(connection, townName);
                Console.WriteLine($"Town {townName} was added to the database.");
            }

            //2
            town = GetTownId(connection, townName);

            //3
            var villain = GetVillainId(connection, villainName);
            if (villain == null)
            {
                AddVillain(connection, villainName);
                Console.WriteLine($"Villain {villainName} was added to the database.");
            }

            //4
            villain = GetVillainId(connection, villainName);

            //5
            var minion = GetMinionId(connection, minionName);
            if (minion == null)
            {
                AddMinion(connection, minionName, age, town);
                minion = GetMinionId(connection, minionName);
                AddMinionVillain(connection, minion, villain);
                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
            }
        }
        private static int? GetTownId(SqlConnection connection, string town)
        {
            string townIdQuery = "SELECT Id FROM Towns WHERE Name = @townName";
            using var sqlCommand = new SqlCommand(townIdQuery, connection);
            sqlCommand.Parameters.AddWithValue("@townName", town);
            int? townId = (int?)sqlCommand.ExecuteScalar();

            return townId;
        }
        private static int? GetVillainId(SqlConnection connection, string villainName)
        {
            string villainIdQuery = "SELECT Id FROM Villains WHERE Name = @Name";
            using (var command = new SqlCommand(villainIdQuery, connection))
            {
                command.Parameters.AddWithValue("@Name", villainName);
                int? id = (int?)command.ExecuteScalar();
                return id;
            }
        }
        private static int? GetMinionId(SqlConnection connection, string minionName)
        {
            string minionIdQuery = "SELECT Id FROM Minions WHERE Name = @Name";
            using (var command = new SqlCommand(minionIdQuery, connection))
            {
                command.Parameters.AddWithValue("@Name", minionName);
                int? id = (int?)command.ExecuteScalar();
                return id;
            }
        }
        private static void AddTown(SqlConnection connection, string townName)
        {
            string insertTownQuery = "INSERT INTO Towns (Name) VALUES (@townName)";
            using (var insertCommand = new SqlCommand(insertTownQuery, connection))
            {
                insertCommand.Parameters.AddWithValue("@townName", townName);
                insertCommand.ExecuteNonQuery();
            }
        }
        private static void AddVillain(SqlConnection connection, string villainName)
        {
            string insertQuery = "INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";
            using (var insertCommand = new SqlCommand(insertQuery, connection))
            {
                insertCommand.Parameters.AddWithValue("@villainName", villainName);
                insertCommand.ExecuteNonQuery();
            }
        }
        private static void AddMinion(SqlConnection connection, string minionName, int age, int? town)
        {
            string insertQuery = "INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";

            using (var insertCommand = new SqlCommand(insertQuery, connection))
            {
                insertCommand.Parameters.AddWithValue("@name", minionName);
                insertCommand.Parameters.AddWithValue("@age", age);
                insertCommand.Parameters.AddWithValue("@townId", town);
                insertCommand.ExecuteNonQuery();
            }
        }
        private static void AddMinionVillain(SqlConnection connection, int? minion, int? villain)
        {
            string insertQuery = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";

            using (var insertCommand = new SqlCommand(insertQuery, connection))
            {
                insertCommand.Parameters.AddWithValue("@villainId", minion);
                insertCommand.Parameters.AddWithValue("@minionId", villain);
                insertCommand.ExecuteNonQuery();
            }
        }

        //5. Change Town Names Casing
        private static SqlCommand ChangeTownNamesCasing(SqlConnection connection)
        {
            string countryName = Console.ReadLine();

            string updateTownNameQuery = @"UPDATE Towns
                                              SET Name = UPPER(Name)
                                            WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

            string selectTownNamesQuery = @" SELECT t.Name 
                                               FROM Towns as t
                                               JOIN Countries AS c ON c.Id = t.CountryCode
                                              WHERE c.Name = @countryName";
            var updateCommand = new SqlCommand(updateTownNameQuery, connection);
            updateCommand.Parameters.AddWithValue("@countryName", countryName);
            var affectedRows = updateCommand.ExecuteNonQuery();

            if (affectedRows == 0)
            {
                Console.WriteLine("No town names were affected.");
            }
            else
            {
                Console.WriteLine($"{affectedRows} town names were affected.");

                using var selectCommand = new SqlCommand(selectTownNamesQuery, connection);
                selectCommand.Parameters.AddWithValue("@countryName", countryName);

                using (var reader = selectCommand.ExecuteReader())
                {
                    var towns = new List<string>();
                    while (reader.Read())
                    {
                        towns.Add((string)reader[0]);
                    }
                    Console.WriteLine($"[{string.Join(", ", towns)}]");
                }
            }

            return updateCommand;
        }

        //6. Remove Villain
        private static void RemoveVillain(SqlConnection connection, out SqlCommand sqlCommand)
        {
            int id = int.Parse(Console.ReadLine());

            var evilNameQuery = @"SELECT Name FROM Villains WHERE Id = @villainId";
            sqlCommand = new SqlCommand(evilNameQuery, connection);
            sqlCommand.Parameters.AddWithValue("@villainId", id);
            var name = (string)sqlCommand.ExecuteScalar();

            if (name == null)
            {
                Console.WriteLine($"No suck villain was found.");
                return;
            }

            var deleteMinionsVillainsQuery = @"DELETE FROM MinionsVillains 
                                                WHERE VillainId = @villainId";

            var sqlDeleteMVCommand = new SqlCommand(deleteMinionsVillainsQuery, connection);
            sqlDeleteMVCommand.Parameters.AddWithValue("@villainId", id);
            var affectedRows = sqlDeleteMVCommand.ExecuteNonQuery();



            var deleteVillainsQuery = @"DELETE FROM Villains
                                         WHERE Id = @villainId";

            var sqlDeleteVCommand = new SqlCommand(deleteVillainsQuery, connection);
            sqlDeleteVCommand.Parameters.AddWithValue("@villainId", id);
            sqlDeleteVCommand.ExecuteNonQuery();

            Console.WriteLine($"{name} was deleted.");
            Console.WriteLine($"{affectedRows} minions were released.");
        }

        //7. Print All Minion Names
        private static void PrintAllMinionNames(SqlConnection connection, out SqlCommand selectCommand, out SqlDataReader reader)
        {
            var minionsQuery = "SELECT Name FROM Minions";
            selectCommand = new SqlCommand(minionsQuery, connection);
            reader = selectCommand.ExecuteReader();
            var minions = new List<string>();

            while (reader.Read())
            {
                minions.Add((string)reader[0]);
            }

            int counter = 0;
            for (int i = 0; i < minions.Count / 2; i++)
            {
                Console.WriteLine(minions[0 + counter]);
                Console.WriteLine(minions[minions.Count - 1 - counter]);
                counter++;
            }

            if (minions.Count % 2 != 0)
            {
                Console.WriteLine(minions[minions.Count / 2]);
            }
        }

        //8. Increase Minion Age
        private static void IncreaseMinionAge(SqlConnection connection, out SqlCommand selectedCommand, out SqlDataReader reader)
        {
            int[] minionsIds = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string updateMinionsQuery = @"UPDATE Minions
                                             SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                                           WHERE Id = @Id";

            foreach (var id in minionsIds)
            {
                using var sqlCommand = new SqlCommand(updateMinionsQuery, connection);
                sqlCommand.Parameters.AddWithValue("@Id", id);
                sqlCommand.ExecuteNonQuery();
            }

            string selectMinionsQuery = @"SELECT Name, Age FROM Minions";
            selectedCommand = new SqlCommand(selectMinionsQuery, connection);
            reader = selectedCommand.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"{reader[0]} {reader[1]}");
            }
        }

        //9. Increase Age Stored Procedure
        private static void IncreaseAgeStoredProcedure(SqlConnection connection, out SqlCommand command, out SqlCommand selectCommand, out SqlDataReader reader)
        {
            int id = int.Parse(Console.ReadLine());

            //first run procedure in sql
            var query = @"EXEC usp_GetOlder @id";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();

            string selectQuery = @"SELECT Name, Age FROM Minions WHERE Id = @Id";
            selectCommand = new SqlCommand(selectQuery, connection);
            selectCommand.Parameters.AddWithValue("@Id", id);
            reader = selectCommand.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"{reader[0]} - {reader[1]} years old");
            }
        }
    }
}

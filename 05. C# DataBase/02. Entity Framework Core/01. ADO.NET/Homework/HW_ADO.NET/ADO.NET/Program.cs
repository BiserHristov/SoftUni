
using Microsoft.Data.SqlClient;

namespace ADO.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        //const string SQLConnectionString = "Server=.;Database=master; Integrated Security=true";

        const string SQLConnectionString = "Server=.;Database=MinionsDB; Integrated Security=true";

        static void Main()
        {
            using (var connection = new SqlConnection(SQLConnectionString))
            {
                connection.Open();


                //Task.1
                //InitalSetup(connection);

                //Task.2
                //VillianNames(connection);

                //Task.3
                //MinionNames(connection);

                //Task.4
                //AddMinion(connection);

                //Task. 5
                //ChangeTownNameCasing(connection);

                //Task. 6
                //RemoveVillian(connection);


                //Task. 7
                //PrintAllMinionsNames(connection);

                //Task. 8
                //IncreaseMinionAge(connection);

                //Task. 9
                //IncreaseAgeStoreProcedure(connection);


            }

        }

        //Task 1
        private static void InitalSetup(SqlConnection connection)
        {
            //string createDBQuery = @"CREATE DATABASE MinionsDB";
            //ExecuteNonQuery(createDBQuery, connection);


            string createTablesQuery = @"CREATE TABLE Countries (Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50))

                                            CREATE TABLE Towns(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), CountryCode INT FOREIGN KEY REFERENCES Countries(Id))

                                            CREATE TABLE Minions(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(30), Age INT, TownId INT FOREIGN KEY REFERENCES Towns(Id))

                                            CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50))

                                            CREATE TABLE Villains(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id))

                                            CREATE TABLE MinionsVillains(MinionId INT FOREIGN KEY REFERENCES Minions(Id), VillainId INT FOREIGN KEY REFERENCES Villains(Id), CONSTRAINT PK_MinionsVillains PRIMARY KEY(MinionId, VillainId))";

            ExecuteNonQuery(createTablesQuery, connection);

            string insertTablesQuery = @"INSERT INTO Countries ([Name]) VALUES ('Bulgaria'),('England'),('Cyprus'),('Germany'),('Norway')

                                INSERT INTO Towns ([Name], CountryCode) VALUES ('Plovdiv', 1),('Varna', 1),('Burgas', 1),('Sofia', 1),('London', 2),('Southampton', 2),('Bath', 2),('Liverpool', 2),('Berlin', 3),('Frankfurt', 3),('Oslo', 4)

                                INSERT INTO Minions (Name,Age, TownId) VALUES('Bob', 42, 3),('Kevin', 1, 1),('Bob ', 32, 6),('Simon', 45, 3),('Cathleen', 11, 2),('Carry ', 50, 10),('Becky', 125, 5),('Mars', 21, 1),('Misho', 5, 10),('Zoe', 125, 5),('Json', 21, 1)

                                INSERT INTO EvilnessFactors (Name) VALUES ('Super good'),('Good'),('Bad'), ('Evil'),('Super evil')

                                INSERT INTO Villains (Name, EvilnessFactorId) VALUES ('Gru',2),('Victor',1),('Jilly',3),('Miro',4),('Rosen',5),('Dimityr',1),('Dobromir',2)

                                INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (4,2),(1,1),(5,7),(3,5),(2,6),(11,5),(8,4),(9,7),(7,1),(1,3),(7,3),(5,3),(4,3),(1,2),(2,1),(2,7)";


            ExecuteNonQuery(insertTablesQuery, connection);
        }


        //Task 2
        private static void VillianNames(SqlConnection connection)
        {
            string selectNamesQuery = @"  SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                                FROM Villains AS v 
                                                JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                                            GROUP BY v.Id, v.Name 
                                              HAVING COUNT(mv.VillainId) > 3 
                                            ORDER BY COUNT(mv.VillainId)";
            using var command = new SqlCommand(selectNamesQuery, connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"{reader[0]} - {reader[1]}");
            }
        }
       
        //Task 3
        private static void MinionNames(SqlConnection connection)
        {
            int villianId = int.Parse(Console.ReadLine());
            string existingVillianQuery = "SELECT Name FROM Villains WHERE Id = @Id";
            using var command = new SqlCommand(existingVillianQuery, connection);
            command.Parameters.AddWithValue("@Id", villianId);
            var villianName = command.ExecuteScalar();

            if (villianName == null)
            {
                Console.WriteLine($"No villain with ID {villianId} exists in the database.");
                return;
            }

            Console.WriteLine($"Villain: {villianName}");

            string selectMinionsQuery = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";
            using var selectMinionsCommand = new SqlCommand(selectMinionsQuery, connection);
            selectMinionsCommand.Parameters.AddWithValue("@Id", villianId);
            using var reader = selectMinionsCommand.ExecuteReader();

            if (!reader.HasRows)
            {
                Console.WriteLine("(no minions)");
                return;
            }

            while (reader.Read())
            {
                Console.WriteLine($"{reader["RowNum"]}. {reader["Name"]} {reader["Age"]}");
            }

        }

        //Task 4
        private static void AddMinion(SqlConnection connection)
        {
            string[] minionInfo = Console.ReadLine().Split(' ');
            string mName = minionInfo[1];
            int mAge = int.Parse(minionInfo[2]);
            string mTownName = minionInfo[3];

            string vName = Console.ReadLine().Split(' ')[1];

            //Check if there is existing town with given name
            string townNameQuery = @"SELECT Id FROM Towns WHERE Name = @townName";
            using var minionCommand = new SqlCommand(townNameQuery, connection);
            minionCommand.Parameters.AddWithValue("@townName", mTownName);
            var serchedTownId = minionCommand.ExecuteScalar();

            if (serchedTownId == null)
            {
                string insertTownQuery = @"INSERT INTO Towns (Name) VALUES (@townName)";
                using var insertCommand = new SqlCommand(insertTownQuery, connection);
                insertCommand.Parameters.AddWithValue("@townName", mTownName);
                insertCommand.ExecuteNonQuery();
                Console.WriteLine($"Town {mTownName} was added to the database.");
            }

            //Check if there is existing villian with given name
            string villianQuery = @"SELECT Id FROM Villains WHERE Name = @Name";
            using var villianCommand = new SqlCommand(villianQuery, connection);
            villianCommand.Parameters.AddWithValue("@Name", vName);
            var searchedVillianId = villianCommand.ExecuteScalar();

            if (searchedVillianId == null)
            {
                string insertVillivanQuery = @"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";
                using var insertCommand = new SqlCommand(insertVillivanQuery, connection);
                insertCommand.Parameters.AddWithValue("@villainName", vName);
                insertCommand.ExecuteNonQuery();
                Console.WriteLine($"Villain {vName} was added to the database.");
            }



            //Add minion to villian
            serchedTownId = minionCommand.ExecuteScalar();

            string insertMinionQuery = @"INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";
            using var insertMinionCommand = new SqlCommand(insertMinionQuery, connection);
            insertMinionCommand.Parameters.AddWithValue("@name", mName);
            insertMinionCommand.Parameters.AddWithValue("@age", mAge);
            insertMinionCommand.Parameters.AddWithValue("@townId", (int)serchedTownId);
            insertMinionCommand.ExecuteNonQuery();

            string serchedMinionIdQuery = @"SELECT Id FROM Minions WHERE Name = @Name";
            using var serchedMinionIdCommand = new SqlCommand(serchedMinionIdQuery, connection);
            serchedMinionIdCommand.Parameters.AddWithValue("@Name", mName);
            int searchedMinionId = (int)serchedMinionIdCommand.ExecuteScalar();

            searchedVillianId = villianCommand.ExecuteScalar();

            string insertMinionVillianQuery = @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId )";
            using var insertMinionVillianCommand = new SqlCommand(insertMinionVillianQuery, connection);
            insertMinionVillianCommand.Parameters.AddWithValue("@minionId", searchedMinionId);
            insertMinionVillianCommand.Parameters.AddWithValue("@villainId", searchedVillianId);
            insertMinionVillianCommand.ExecuteNonQuery();

            Console.WriteLine($"Successfully added {mName} to be minion of {vName}.");
        }

        //Task 5
        private static void ChangeTownNameCasing(SqlConnection connection)
        {
            string cName = Console.ReadLine();
            string updateQuery = @" UPDATE Towns
                                                   SET Name = UPPER(Name)
                                                 WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

            using var updateCommand = new SqlCommand(updateQuery, connection);
            updateCommand.Parameters.AddWithValue("@countryName", cName);
            int affectedTownsCount = (int)updateCommand.ExecuteNonQuery();

            if (affectedTownsCount == 0)
            {
                Console.WriteLine("No town names were affected.");
                return;

            }

            Console.WriteLine($"{affectedTownsCount} town names were affected.");

            string selectQuery = @" SELECT t.Name 
                                           FROM Towns as t
                                           JOIN Countries AS c ON c.Id = t.CountryCode
                                          WHERE c.Name = @countryName";
            using var selectCommand = new SqlCommand(selectQuery, connection);
            selectCommand.Parameters.AddWithValue("@countryName", cName);
            using var reader = selectCommand.ExecuteReader();

            List<string> towns = new List<string>();

            while (reader.Read())
            {
                towns.Add(reader[0].ToString());

            }

            Console.WriteLine($"[{string.Join(", ", towns)}]");
        }

        //Task 6
        private static void RemoveVillian(SqlConnection connection)
        {
            int villainId = int.Parse(Console.ReadLine());

            string villianQuery = @"SELECT Name FROM Villains WHERE Id = @villainId";
            using var villianCommand = new SqlCommand(villianQuery, connection);
            villianCommand.Parameters.AddWithValue("@villainId", villainId);
            var villianName = villianCommand.ExecuteScalar();

            if (villianName == null)
            {
                Console.WriteLine("No such villain was found.");
                return;
            }


            string deleteMinionsVilliansQuery = @"DELETE FROM MinionsVillains 
                                                      WHERE VillainId = @villainId";
            using var deleteMinionsVilliansCommand = new SqlCommand(deleteMinionsVilliansQuery, connection);
            deleteMinionsVilliansCommand.Parameters.AddWithValue("@villainId", villainId);
            int freeMinionsCount = (int)deleteMinionsVilliansCommand.ExecuteNonQuery();

            string deleteVillianQuery = @"DELETE FROM Villains
                                                        WHERE Id = @villainId";
            using var deleteVillianCommand = new SqlCommand(deleteVillianQuery, connection);
            deleteVillianCommand.Parameters.AddWithValue("@villainId", villainId);
            int deletedVillianCount = (int)deleteVillianCommand.ExecuteNonQuery();


            Console.WriteLine($"{villianName} was deleted.");

            Console.WriteLine($"{freeMinionsCount} minions were released.");
        }

        //Task 7
        private static void PrintAllMinionsNames(SqlConnection connection)
        {
            string selectNamesQuery = @"SELECT Name FROM Minions";
            using var selectNamesCommand = new SqlCommand(selectNamesQuery, connection);
            using var reader = selectNamesCommand.ExecuteReader();
            var list = new List<string>();
            while (reader.Read())
            {
                list.Add(reader[0].ToString());
            }

            for (int i = 0; i < list.Count / 2; i++)
            {
                Console.WriteLine(list[i]);
                Console.WriteLine(list[list.Count - 1 - i]);

            }

            if (list.Count % 2 != 0)
            {
                Console.WriteLine(list[list.Count / 2]);
            }
        }

        //Task 8
        private static void IncreaseMinionAge(SqlConnection connection)
        {
            var minionsId = Console.ReadLine()
                               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToList();
            string updateQuery = @" UPDATE Minions
                                           SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                                         WHERE Id = @Id";


            for (int i = 0; i < minionsId.Count; i++)
            {
                using var updateCommand = new SqlCommand(updateQuery, connection);
                updateCommand.Parameters.AddWithValue("@Id", minionsId[i]);
                updateCommand.ExecuteNonQuery();

            }


            string selectAllNamesQuery = @"SELECT Name, Age FROM Minions";
            using var selectAllNamesCommand = new SqlCommand(selectAllNamesQuery, connection);
            using var reader = selectAllNamesCommand.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader[0]} {reader[1]}");

            }
        }

        //Task 9
        private static void IncreaseAgeStoreProcedure(SqlConnection connection)
        {
            int minionId = int.Parse(Console.ReadLine());

            string procedureQuery = @"EXEC usp_GetOlder @Id";
            using var procedureCommand = new SqlCommand(procedureQuery, connection);
            procedureCommand.Parameters.AddWithValue("@Id", minionId);
            procedureCommand.ExecuteNonQuery();

            string selectMinionQuery = @"SELECT Name, Age FROM Minions WHERE Id = @Id";
            using var selectMinionCommand = new SqlCommand(selectMinionQuery, connection);
            selectMinionCommand.Parameters.AddWithValue("@Id", minionId);
            using var reader = selectMinionCommand.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader["Name"]} – {reader["Age"]} years old");

            }

        }



        private static void ExecuteNonQuery(string query, SqlConnection connection)
        {
            using var command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
        }
    }
}

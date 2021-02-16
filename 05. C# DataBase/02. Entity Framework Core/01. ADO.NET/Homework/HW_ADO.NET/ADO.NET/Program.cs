
using Microsoft.Data.SqlClient;

namespace ADO.NET
{
    using System;

    public class Program
    {
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



            }

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



        //Task 1
        private static void InitalSetup(SqlConnection connection)
        {
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
        private static void ExecuteNonQuery(string query, SqlConnection connection)
        {
            using var command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
        }
    }
}

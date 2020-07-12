using P07.MilitaryElite.Interfaces;
using P07.MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P07.MilitaryElite.Core
{
    public class Engine
    {
        private List<ISoldier> soldiers;

        public Engine()
        {
            this.soldiers = new List<ISoldier>();
        }

        public void Run()
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            

            while (input[0] != "End")
            {
                string command = input[0];

                if (command == "Private")
                {
                    int id = int.Parse(input[1]);
                    string fName = input[2];
                    string lName = input[3];
                    decimal salary = decimal.Parse(input[4]);

                    Private @private = new Private(id, fName, lName, salary);
                    this.soldiers.Add(@private);
                }
                //Check •	LEutenantGeneral
                else if (command == "LieutenantGeneral")
                {
                    int id = int.Parse(input[1]);
                    string fName = input[2];
                    string lName = input[3];
                    decimal salary = decimal.Parse(input[4]);
                    LieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, fName, lName, salary);

                    for (int i = 5; i < input.Length; i++)
                    {
                        var @private = this.soldiers.Where(x => x.Id == int.Parse(input[i]) && x.GetType().Name == "Private").FirstOrDefault();
                        if (@private!=null)
                        {
                            lieutenantGeneral.AddPrivate(@private as IPrivate);

                        }
                     
                    }
                    this.soldiers.Add(lieutenantGeneral);
                }
                else if (command == "Engineer")
                {
                    int id = int.Parse(input[1]);
                    string fName = input[2];
                    string lName = input[3];
                    decimal salary = decimal.Parse(input[4]);
                    string corp = input[5];

                    Engineer engineer = new Engineer(id, fName, lName, salary, corp);

                    for (int i = 6; i < input.Length; i += 2)
                    {
                        string repairPart = input[i];
                        int repairHours = int.Parse(input[i + 1]);
                        IRepair repair = new Repair(repairPart, repairHours);
                        engineer.AddReapir(repair);
                    }

                    this.soldiers.Add(engineer);
                }

                else if (command == "Commando")
                {
                    int id = int.Parse(input[1]);
                    string fName = input[2];
                    string lName = input[3];
                    decimal salary = decimal.Parse(input[4]);
                    string corp = input[5];
                    try
                    {
                        Commando commando = new Commando(id, fName, lName, salary, corp);

                        for (int i = 6; i < input.Length; i += 2)
                        {
                            string missionName = input[i];
                            string missionState = input[i + 1];
                            IMission mission = new Mission(missionName, missionState);
                            commando.AddMission(mission);
                        }

                        this.soldiers.Add(commando);

                    }
                    catch (Exception)
                    {

                        throw;
                    }

                }
                 else if (command == "Spy")
                {
                    int id = int.Parse(input[1]);
                    string fName = input[2];
                    string lName = input[3];
                    int codeNumber = int.Parse(input[4]);

                    Spy spy = new Spy(id, fName, lName, codeNumber);

                    this.soldiers.Add(spy);
                }

                input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            }

            foreach (var soldier in this.soldiers)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}

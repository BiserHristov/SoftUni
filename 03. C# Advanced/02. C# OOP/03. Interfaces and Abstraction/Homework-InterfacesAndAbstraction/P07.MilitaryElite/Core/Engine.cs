using P07.MilitaryElite.Core.Contracts;
using P07.MilitaryElite.Exceptions;
using P07.MilitaryElite.Interfaces;
using P07.MilitaryElite.IO.Contracts;
using P07.MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.MilitaryElite.Core
{
    public class Engine : IEngine
    {
        private ICollection<ISoldier> soldiers;
        private IReader reader;
        private IWriter writer;

        private Engine()
        {
            this.soldiers = new List<ISoldier>();

        }
        public Engine(IReader reader, IWriter writer)
            : this()
        {

            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string line;

            while ((line = this.reader.ReadLine()) != "End")
            {
                string[] input = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = input[0];
                int id = int.Parse(input[1]);
                string fName = input[2];
                string lName = input[3];

                ISoldier soldier = null;

                if (command == "Private")
                {
                    decimal salary = decimal.Parse(input[4]);

                    soldier = new Private(id, fName, lName, salary);
                  
                }
                else if (command == "LieutenantGeneral")
                {

                    decimal salary = decimal.Parse(input[4]);
                    soldier = new LieutenantGeneral(id, fName, lName, salary);

                    for (int i = 5; i < input.Length; i++)
                    {
                        var @private = this.soldiers.Where(x => x.Id == int.Parse(input[i]) && x.GetType().Name == "Private").FirstOrDefault();
                        if (@private != null)
                        {
                            (soldier as ILieutenantGeneral).AddPrivate(@private as IPrivate);

                        }

                    }
                    
                }
                else if (command == "Engineer")
                {

                    decimal salary = decimal.Parse(input[4]);
                    string corp = input[5];

                    try
                    {
                        soldier = new Engineer(id, fName, lName, salary, corp);
                        for (int i = 6; i < input.Length; i += 2)
                        {
                            string repairPart = input[i];
                            int repairHours = int.Parse(input[i + 1]);
                            IRepair repair = new Repair(repairPart, repairHours);
                            (soldier as IEngineer).AddReapir(repair);
                        }

                    }
                    catch (InvalidCorpsException)
                    {
                        continue;
                    }


                }

                else if (command == "Commando")
                {

                    decimal salary = decimal.Parse(input[4]);
                    string corp = input[5];

                    try
                    {
                        soldier = new Commando(id, fName, lName, salary, corp);

                        for (int i = 6; i < input.Length; i += 2)
                        {
                            string missionName = input[i];
                            string missionState = input[i + 1];
                            try
                            {
                                IMission mission = new Mission(missionName, missionState);
                                (soldier as ICommando).AddMission(mission);
                            }
                            catch (InvalidMissionStateException)
                            {

                                continue;
                            }

                        }
                    }
                    catch (InvalidCorpsException)
                    {
                        continue;
                    }


                }
                else if (command == "Spy")
                {

                    int codeNumber = int.Parse(input[4]);
                    soldier = new Spy(id, fName, lName, codeNumber);

                }


                if (soldier!=null)
                {
                    this.soldiers.Add(soldier);
                }

            }

            foreach (var soldier in this.soldiers)
            {
                this.writer.WriteLine(soldier.ToString());
            }
        }
    }
}

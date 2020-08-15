using SantaWorkshop.Core.Contracts;
using SantaWorkshop.Models.Dwarfs;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments;
using SantaWorkshop.Models.Presents;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops;
using SantaWorkshop.Repositories;
using SantaWorkshop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SantaWorkshop.Core
{
    public class Controller : IController
    {
        private readonly DwarfRepository dwarfs;
        private readonly PresentRepository presents;

        public Controller()
        {
            this.dwarfs = new DwarfRepository();
            this.presents = new PresentRepository();

        }

        public string AddDwarf(string dwarfType, string dwarfName)
        {
            IDwarf dwarf = null;
            if (dwarfType == "HappyDwarf")
            {
                dwarf = new HappyDwarf(dwarfName);
            }
            else if (dwarfType == "SleepyDwarf")
            {
                dwarf = new SleepyDwarf(dwarfName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDwarfType);
            }

            this.dwarfs.Add(dwarf);
            return string.Format(OutputMessages.DwarfAdded, dwarfType, dwarfName);



            //Not working as expected :(

            //var commandType = Assembly
            //    .GetCallingAssembly()
            //    .GetTypes()
            //    .Where(t => t.GetInterfaces().Any((i => i.Name == nameof(IDwarf))))
            //    .FirstOrDefault(t => t.Name.ToLower() == dwarfType.ToLower());

            //if (commandType == null)
            //{
            //    throw new InvalidOperationException(ExceptionMessages.InvalidDwarfType);
            //}


            //var instance = (IDwarf)Activator.CreateInstance(commandType, new object[] { dwarfName });

            //this.dwarfs.Add(instance);

            //return string.Format(OutputMessages.DwarfAdded, dwarfType, dwarfName);
        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {
            var dwarf = this.dwarfs.Models.FirstOrDefault(d => d.Name == dwarfName);

            if (dwarf == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentDwarf);
            }

            dwarf.AddInstrument(new Instrument(power));
            return string.Format(OutputMessages.InstrumentAdded, power, dwarfName);
        }

        public string AddPresent(string presentName, int energyRequired)
        {
            this.presents.Add(new Present(presentName, energyRequired));

            return string.Format(OutputMessages.PresentAdded, presentName);
        }

        public string CraftPresent(string presentName)
        {
            var workshop = new Workshop();
            IPresent present = this.presents.FindByName(presentName);

            List<IDwarf> filteredDwarfs = this.dwarfs.Models
                .Where(d => d.Energy >= 50)
                .OrderByDescending(d => d.Energy)
                .ToList();

            if (filteredDwarfs.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.DwarfsNotReady);
            }
            foreach (var dwarf in filteredDwarfs)
            {
                workshop.Craft(present, dwarf);

                if (dwarf.Energy == 0)
                {
                    this.dwarfs.Remove(dwarf);
                    filteredDwarfs.Remove(dwarf);
                }

                if (present.IsDone())
                {
                    break;
                }

            }

            if (present.IsDone())
            {
                return string.Format(OutputMessages.PresentIsDone, presentName);
            }
            else
            {
                return string.Format(OutputMessages.PresentIsNotDone, presentName);
            }

        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            int craftedPresentsCount = this.presents.Models.Count(p => p.IsDone());

            sb.AppendLine($"{craftedPresentsCount} presents are done!");
            sb.AppendLine("Dwarfs info:");
            foreach (var dwarf in this.dwarfs.Models)
            {
                sb.AppendLine($"Name: {dwarf.Name}");
                sb.AppendLine($"Energy: {dwarf.Energy}");
                sb.AppendLine($"Instruments: {dwarf.Instruments.Count(i => i.IsBroken() == false)} not broken left");

            }

            return sb.ToString().Trim();
        }
    }
}

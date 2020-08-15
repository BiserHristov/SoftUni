using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        private ICollection<IPlayer> terrorists;

        private ICollection<IPlayer> counterTerrorists;

        public Map()
        {
            this.terrorists = new List<IPlayer>();
            this.counterTerrorists = new List<IPlayer>();
        }

        public string Start(ICollection<IPlayer> players)
        {



            foreach (IPlayer player in players)
            {
                if (player.GetType().Name == "Terrorist")
                {
                    terrorists.Add(player);
                }
                else if (player.GetType().Name == "CounterTerrorist")
                {
                    counterTerrorists.Add(player);
                }
            }

            while (true)
            {
                foreach (IPlayer terrorist in terrorists)
                {
                    foreach (IPlayer counterTerrorist in counterTerrorists)
                    {
                        if (terrorist.IsAlive && counterTerrorist.IsAlive)
                        {
                            counterTerrorist.TakeDamage(terrorist.Gun.Fire());
                        }
                    }
                }

                foreach (IPlayer counterTerrorist in counterTerrorists)
                {
                    foreach (IPlayer terrorist in terrorists)
                    {
                        if (counterTerrorist.IsAlive && terrorist.IsAlive)
                        {
                            terrorist.TakeDamage(counterTerrorist.Gun.Fire());
                        }
                    }
                }

                if (terrorists.All(t => t.IsAlive == false))
                {
                    return "Counter Terrorist wins!";
                }
                else if (counterTerrorists.All(ct => ct.IsAlive == false))
                {
                    return "Terrorist wins!";
                }
            }
        }
    }
}

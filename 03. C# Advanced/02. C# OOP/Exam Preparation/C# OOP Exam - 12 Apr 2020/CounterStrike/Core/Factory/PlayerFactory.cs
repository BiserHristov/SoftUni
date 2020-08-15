using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;

namespace CounterStrike.Core.Factory
{
    public class PlayerFactory:IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username, int health, int armor, IGun gun)
        {
            IPlayer player = null;
            if (type == nameof(Terrorist))
            {
                player = new Terrorist(username, health, armor, gun);
            }
            else if (type == nameof(CounterTerrorist))
            {
                player = new CounterTerrorist(username, health, armor, gun);
            }

            return player;
        }
    }
}

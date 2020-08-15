using System;
using System.Collections.Generic;
using System.Text;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players.Contracts;

namespace CounterStrike.Core.Factory
{
    interface IPlayerFactory
    {
        IPlayer CreatePlayer(string type, string username, int health, int armor, IGun gun);
    }
}

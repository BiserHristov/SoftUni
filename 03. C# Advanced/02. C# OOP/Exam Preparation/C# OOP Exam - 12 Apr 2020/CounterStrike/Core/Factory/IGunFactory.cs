using System;
using System.Collections.Generic;
using System.Text;
using CounterStrike.Models.Guns.Contracts;

namespace CounterStrike.Core.Factory
{
    interface IGunFactory
    {
        IGun CreateGun(string type, string name, int bulletsCount);
    }
}

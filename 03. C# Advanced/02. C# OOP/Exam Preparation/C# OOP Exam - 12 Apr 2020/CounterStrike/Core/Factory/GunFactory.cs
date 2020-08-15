using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;

namespace CounterStrike.Core.Factory
{
    public class GunFactory : IGunFactory
    {
        public IGun CreateGun(string type, string name, int bulletsCount)
        {


            IGun gun = null;
            if (type == nameof(Pistol))
            {
                gun = new Pistol(name, bulletsCount);
            }
            else if (type == nameof(Rifle))
            {
                gun = new Rifle(name, bulletsCount);
            }
            return gun;
        }
    }
}

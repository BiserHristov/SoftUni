﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P07.MilitaryElite.Interfaces
{
    public interface IPrivate : ISoldier
    {
        decimal Salary { get; }
    }
}

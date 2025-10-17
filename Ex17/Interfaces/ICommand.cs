﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex17.Interfaces
{
    public interface ICommand
    {
        string Name { get; }
        void Execute();
    }
}

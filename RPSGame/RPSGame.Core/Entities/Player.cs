using System;
using System.Collections.Generic;
using System.Text;
using RPSGame.Core.Utilities;
using RPSGame.Core.Interfaces;

namespace RPSGame.Core.Entities
{
   public abstract class Player
    {
        public  int WinCount { get; set; }
        public  string Name { get; set; }
    }
}

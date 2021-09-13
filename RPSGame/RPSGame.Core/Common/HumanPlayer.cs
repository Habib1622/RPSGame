using System;
using System.Collections.Generic;
using System.Text;
using RPSGame.Core.Utilities;
using RPSGame.Core.Interfaces;
using RPSGame.Core.Entities;


namespace RPSGame.Core.Common
{
   public class HumanPlayer:Player, IPlayer
    {              
    
        public void UpdateWinCount()
        {
            WinCount += 1;
        }

        public int GetWinCount()
        {
            return WinCount;
        }
               
        public string GetPlayerName()
        {
            return Name;
        }
    }
}

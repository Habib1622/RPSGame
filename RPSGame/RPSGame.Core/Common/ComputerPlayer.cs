using System;
using System.Collections.Generic;
using System.Text;
using RPSGame.Core.Utilities;
using RPSGame.Core.Interfaces;
using RPSGame.Core.Entities;


namespace RPSGame.Core.Common
{
   public class ComputerPlayer: Player, IComputerPlayer
    {
        public Random RandomNumber { get; set; }
        public ComputerPlayer()
        {
            RandomNumber = new Random();
        }
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

        public GameShapes GetRandomSelection()
        {
           return (GameShapes)RandomNumber.Next(1, 4);
        }
    }
}

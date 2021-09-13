using System;
using System.Collections.Generic;
using System.Text;
using RPSGame.Core.Common;
using RPSGame.Core.Utilities;

namespace RPSGame.Core.Interfaces
{
   public interface IPlayer
    {
        void UpdateWinCount();
        int GetWinCount();
        string GetPlayerName();
    }
}

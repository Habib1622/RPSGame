using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RPSGame.Core.Common;
using Microsoft.Extensions.Options;
using RPSGame.Core.Interfaces;
using RPSGame.Core.Utilities;

namespace RPSGame.Core.Interfaces
{
   public interface IPSRGameService
    {
        Task<string> PlayGame(GameShapes player1Selection, GameShapes player2Selection);
       Task<string> DisplayOverAllGameWiner();
       Task<bool> ValidateSelection(string userSelection);
       Task<GameShapes> GetPlayDecision(string userSelection);
    }
}

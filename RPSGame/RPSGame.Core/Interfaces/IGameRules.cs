using System;
using System.Collections.Generic;
using System.Text;
using RPSGame.Core.Utilities;
namespace RPSGame.Core.Interfaces
{
   public interface IGameRules
    {
        GameDecisionResult GetWinner(GameShapes play1, GameShapes play2); 
    }
}

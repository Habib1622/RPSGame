using System;
using System.Collections.Generic;
using System.Text;
using RPSGame.Core.Interfaces;
using RPSGame.Core.Utilities;

namespace RPSGame.Core.Common 
{
    public class GameRules : IGameRules
    {
        public GameDecisionResult GetWinner(GameShapes play1, GameShapes play2)
        {
            if (play1 == GameShapes.Scissors && play2 == GameShapes.Paper)
                return GameDecisionResult.Win;
            else if (play1 == GameShapes.Rock && play2 == GameShapes.Scissors)
                return GameDecisionResult.Win;
            else if (play1 == GameShapes.Paper && play2 == GameShapes.Rock)
                return GameDecisionResult.Win;

            else if (play2 == GameShapes.Scissors && play1 == GameShapes.Paper)
                return GameDecisionResult.Lose;
            else if (play2 == GameShapes.Rock && play1 == GameShapes.Scissors)
                return GameDecisionResult.Lose;
            else if (play2 == GameShapes.Paper && play1 == GameShapes.Rock)
                return GameDecisionResult.Lose;

            return GameDecisionResult.Tie;
        }
    }
}

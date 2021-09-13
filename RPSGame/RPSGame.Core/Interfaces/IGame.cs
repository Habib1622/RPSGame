using System;
using System.Collections.Generic;
using System.Text;
using RPSGame.Core.Common;
using RPSGame.Core.Utilities;
namespace RPSGame.Core.Interfaces
{
  public  interface IGame
    {
      GameDecisionResult GetPlayDecisionResult(GameShapes player1Selection, GameShapes player2Selection);
      void UpdateResultBoard(GameDecisionResult gameResult);
        IPlayer GetOverAllWiner();
        string GetPlayDecisionResultMessage(GameShapes player1Selection, GameShapes player2Selection,GameDecisionResult result);
   

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;
using RPSGame.Core.Interfaces;
using RPSGame.Core.Utilities;
namespace RPSGame.Core.Common
{
    public class Game : IGame
    {
        private readonly IPlayer _humanPlayer;
        private readonly IComputerPlayer  _computerPlayer;
        private readonly IGameRules _gameRules;
        private readonly AppSettings _appSettings;
               
        public Game(IPlayer  humanPlayer, IComputerPlayer computerPlayer, IGameRules gameRules, IOptions<AppSettings> options)
        {
            _humanPlayer = humanPlayer;
            _computerPlayer = computerPlayer;         
            _gameRules = gameRules;
            _appSettings = options.Value;
        }                 
               
       public GameDecisionResult GetPlayDecisionResult(GameShapes player1Selection, GameShapes player2Selection)
        {           
           return _gameRules.GetWinner(player1Selection, player2Selection);                      
        }
       public void UpdateResultBoard(GameDecisionResult gameResult)
        {
            if (gameResult == GameDecisionResult.Win)
                _humanPlayer.UpdateWinCount();
            else if (gameResult == GameDecisionResult.Lose)
                _computerPlayer.UpdateWinCount();

        }

        public IPlayer GetOverAllWiner()
        {
            if (_humanPlayer.GetWinCount() >= _appSettings.OverAllMaximumWins)
                return _humanPlayer;

            if (_computerPlayer.GetWinCount() >= _appSettings.OverAllMaximumWins)
                return _computerPlayer;

            return null;
        }

        public string GetPlayDecisionResultMessage(GameShapes player1Selection, GameShapes player2Selection, GameDecisionResult result)
        {
            if (result == GameDecisionResult.Win)
                return string.Format("{0} beats {1}.{2} wins", player1Selection, player2Selection, _humanPlayer.GetPlayerName());
            else if (result == GameDecisionResult.Lose)
                return string.Format("{0} beats {1}. {2} wins", player2Selection, player1Selection, _computerPlayer.GetPlayerName());
            else
                return "It is a tie";

        }
                
        public string Player1Name { get => _humanPlayer.GetPlayerName(); }
        public string Player2Name { get => _computerPlayer.GetPlayerName(); }
       
    }
}

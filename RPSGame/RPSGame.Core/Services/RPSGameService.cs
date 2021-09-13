using System;
using System.Collections.Generic;
using System.Text;
using RPSGame.Core.Interfaces;
using RPSGame.Core.Utilities;
using RPSGame.Core.Entities;
using RPSGame.Core.Common;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace RPSGame.Core.Controller
{
  public class RPSGameService :IPSRGameService
    {
        private IGame _game;
        private readonly IConfiguration _configuration;

        public RPSGameService(IGame game, IConfiguration configuration)
        {
            _game = game;
            _configuration = configuration;
        }

        public async Task<string> PlayGame(GameShapes player1Selection, GameShapes player2Selection)
        {
            return await Task.Run(() =>
             {
                 var result = _game.GetPlayDecisionResult(player1Selection, player2Selection);
                 _game.UpdateResultBoard(result);
                 return _game.GetPlayDecisionResultMessage(player1Selection, player2Selection, result);
             });
         }
        public async Task<bool> ValidateSelection(string userInput)
        {
            return await Task.Run(() =>
            {
                object result;
                if (!Enum.TryParse(typeof(GameShapes), userInput, true, out result))
                    return false;
                return true;
            });
        }
        public async Task<GameShapes> GetPlayDecision(string userSelection)
        {
            return await Task.Run(() =>  (GameShapes)Enum.Parse(typeof(GameShapes), userSelection, true));
        }
        public async Task<string> DisplayOverAllGameWiner()
        {
            return await Task.Run(() =>
            {
                if (_game.GetOverAllWiner() != null)
                {
                    return (string.Format("Over all game winner:{0}", _game.GetOverAllWiner().GetPlayerName()));
                }
                else
                {
                    return ("No one wins this game.");
                }
            });
        }
               
    }
}

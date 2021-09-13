using NUnit.Framework;
using Moq;
using RPSGame.Core.Common;
using RPSGame.Core.Interfaces;
using RPSGame.Core.Entities;
using RPSGame.Core.Utilities;
using RPSGame.Core.Controller;
using Microsoft.Extensions.Configuration;
using RPSGame.Tests.Common;
using Microsoft.Extensions.Options;

namespace RPSGame.Tests
{
    public class GameRulesTests
    {    
        private IGameRules _gameRules;

      
        [SetUp]
        public void Setup()
        {
           _gameRules = new GameRules();         
        }

        [Test]
        public void GetWinner_RockAndScissors_ShouldReturn_Win()
        {
              
           //Act
           var result= _gameRules.GetWinner(GameShapes.Rock, GameShapes.Scissors);
           
            //Assert
           Assert.IsNotNull(result);         
          Assert.AreEqual(GameDecisionResult.Win, result);
        }

        [Test]
        public void GetWinner_ScissorsAndPaper_ShouldReuturn_Win()
        {
            //Act
            var result = _gameRules.GetWinner(GameShapes.Scissors, GameShapes.Paper);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(GameDecisionResult.Win, result);
        }


        [Test]
        public void GitWinner_PaperAndRock_ShouldReturn_Win()
        {
            //Act
            var result = _gameRules.GetWinner(GameShapes.Paper, GameShapes.Rock);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(GameDecisionResult.Win, result);
        }


        [Test]
        public void GetWinner_ScissorsAndRock_ShouldReturn_Lose()
        {

            //Act
            var result = _gameRules.GetWinner(GameShapes.Scissors, GameShapes.Rock);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(GameDecisionResult.Lose, result);
        }

        [Test]
        public void GetWinner_PaperAndScissors_ShouldReuturn_Lose()
        {
            //Act
            var result = _gameRules.GetWinner(GameShapes.Paper, GameShapes.Scissors);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(GameDecisionResult.Lose, result);
        }


        [Test]
        public void GitWinner_RockAndPaper_ShouldReturn_Lose()
        {
            //Act
            var result = _gameRules.GetWinner(GameShapes.Rock, GameShapes.Paper);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(GameDecisionResult.Lose, result);
        }



        [Test]
        public void GetWinner_PaperAndPaper_ShouldReturn_Tie()
        {
            //Act
            var result = _gameRules.GetWinner(GameShapes.Paper, GameShapes.Paper);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(GameDecisionResult.Tie, result);
        }

        [Test]
        public void GetWinner_RockAndRock_ShouldReturn_Tie()
        {
            //Act
            var result = _gameRules.GetWinner(GameShapes.Rock, GameShapes.Rock);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(GameDecisionResult.Tie, result);
        }

        [Test]
        public void GetWinner_ScissorsAndScissors_ShouldReturn_Tie()
        {
            //Act
            var result = _gameRules.GetWinner(GameShapes.Scissors, GameShapes.Scissors);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(GameDecisionResult.Tie, result);
        }


    }
}
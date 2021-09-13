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
    public class GamesTests
    {
        private Mock<IOptions<AppSettings>> _options;
        private Mock<IGameRules> _gameRules;
        private Mock<IPlayer> _humanPlayer;
        private Mock<IComputerPlayer> _computerPlayer;

        [SetUp]
        public void Setup()
        {

            // IOptions to be the AppSettings Class
            _options = new Mock<IOptions<AppSettings>>();
            _gameRules = new Mock<IGameRules>();
            _options.Setup(ap => ap.Value).Returns(TestHelper.GetSettings());
            _humanPlayer = new Mock<IPlayer>();                 
            _computerPlayer = new  Mock<IComputerPlayer>();
                          
        }

        [Test]
        public void GetPlayDecisionResult_RockAndScissors_ShouldReturn_Win()
        {
            //Arrange    
            _gameRules.Setup(r => r.GetWinner(GameShapes.Rock, GameShapes.Scissors)).Returns(GameDecisionResult.Win);
            _humanPlayer.Setup(x => x.GetPlayerName()).Returns("Human player");
            _computerPlayer.Setup(x => x.GetPlayerName()).Returns("Computer player");

            var game = new Game(_humanPlayer.Object, _computerPlayer.Object, _gameRules.Object, _options.Object);

            //Act
            var result= game.GetPlayDecisionResult(GameShapes.Rock, GameShapes.Scissors);
           

            //Assert
           Assert.IsNotNull(result);         
          Assert.AreEqual(GameDecisionResult.Win, result);

        }

        [Test]
        public void GetPlayDecisionResult_ScissorsAndPaper_ShouldReturn_Win()
        {
            //Arrange   
            _gameRules.Setup(r => r.GetWinner(GameShapes.Scissors, GameShapes.Paper)).Returns(GameDecisionResult.Win);
            _humanPlayer.Setup(x => x.GetPlayerName()).Returns("Human player");
            _computerPlayer.Setup(x => x.GetPlayerName()).Returns("Computer player");

            var game = new Game(_humanPlayer.Object, _computerPlayer.Object, _gameRules.Object, _options.Object);

            //Act
            var result = game.GetPlayDecisionResult(GameShapes.Scissors, GameShapes.Paper);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(GameDecisionResult.Win, result);
           
        }


        [Test]
        public void GetPlayDecisionResult_PaperAndRock_ShouldReturn_Win()
        {
            //Arrange  
            _gameRules.Setup(r => r.GetWinner(GameShapes.Paper, GameShapes.Rock)).Returns(GameDecisionResult.Win);
            _humanPlayer.Setup(x => x.GetPlayerName()).Returns("Human player");
            _computerPlayer.Setup(x => x.GetPlayerName()).Returns("Computer player");

            var game = new Game(_humanPlayer.Object, _computerPlayer.Object, _gameRules.Object, _options.Object);

            //Act
            var result = game.GetPlayDecisionResult(GameShapes.Paper, GameShapes.Rock);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(GameDecisionResult.Win, result);
        }


        [Test]
        public void GetPlayDecisionResult_PaperAndPaper_ShouldReturn_Tie()
        {
            //Arrange  
            _gameRules.Setup(r => r.GetWinner(GameShapes.Paper, GameShapes.Paper)).Returns(GameDecisionResult.Tie);
            _humanPlayer.Setup(x => x.GetPlayerName()).Returns("Human player");
            _computerPlayer.Setup(x => x.GetPlayerName()).Returns("Computer player");

            var game = new Game(_humanPlayer.Object, _computerPlayer.Object, _gameRules.Object, _options.Object);

            //Act
            var result = game.GetPlayDecisionResult(GameShapes.Paper, GameShapes.Paper);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(GameDecisionResult.Tie, result);
        }


        [Test]
        public void GetPlayDecisionResultMessage_RockAndScissors_ShouldReturn_Player1WinMessage()
        {
            //Arrange    
            _gameRules.Setup(r => r.GetWinner(GameShapes.Rock, GameShapes.Scissors)).Returns(GameDecisionResult.Win);
            _humanPlayer.Setup(x => x.GetPlayerName()).Returns("Player1");
            _computerPlayer.Setup(x => x.GetPlayerName()).Returns("Player2");

            var game = new Game(_humanPlayer.Object, _computerPlayer.Object, _gameRules.Object, _options.Object);

            //Act
            var result = game.GetPlayDecisionResult(GameShapes.Rock, GameShapes.Scissors);
            var result1 = game.GetPlayDecisionResultMessage(GameShapes.Rock, GameShapes.Scissors, result);


            //Assert
            Assert.IsNotNull(result1);
            Assert.AreEqual("Rock beats Scissors.Player1 wins", result1);
        }

        [Test]
        public void GetPlayDecisionResultMessage_PaperAndScissors_ShouldReturnPlayer2WinMessage()
        {
            //Arrange    
            _gameRules.Setup(r => r.GetWinner(GameShapes.Paper, GameShapes.Scissors)).Returns(GameDecisionResult.Lose);
            _humanPlayer.Setup(x => x.GetPlayerName()).Returns("Player1");
            _computerPlayer.Setup(x => x.GetPlayerName()).Returns("Player2");

            var game = new Game(_humanPlayer.Object, _computerPlayer.Object, _gameRules.Object, _options.Object);

            //Act
            var result = game.GetPlayDecisionResult(GameShapes.Paper, GameShapes.Scissors);
            var result1 = game.GetPlayDecisionResultMessage(GameShapes.Paper, GameShapes.Scissors, result);

            //Assert
            Assert.IsNotNull(result1);
            Assert.AreEqual("Scissors beats Paper. Player2 wins", result1);
        }


        [Test]
        public void GetPlayDecisionResultMessage_PaperAndPaper_ShouldReturn_TieMessage()
        {
            //Arrange    
            _gameRules.Setup(r => r.GetWinner(GameShapes.Paper, GameShapes.Paper)).Returns(GameDecisionResult.Tie);
            _humanPlayer.Setup(x => x.GetPlayerName()).Returns("Player1");
            _computerPlayer.Setup(x => x.GetPlayerName()).Returns("Player2");

            var game = new Game(_humanPlayer.Object, _computerPlayer.Object, _gameRules.Object, _options.Object);

            //Act
            var result = game.GetPlayDecisionResult(GameShapes.Paper, GameShapes.Paper);
            var result1 = game.GetPlayDecisionResultMessage(GameShapes.Paper, GameShapes.Paper, result);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("It is a tie", result1);
        }

    }
}
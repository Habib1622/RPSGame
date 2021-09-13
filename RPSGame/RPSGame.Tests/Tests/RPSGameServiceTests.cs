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
    public class RPSGameServiceTests
    {
        private Mock<IConfiguration> _configuration;
        private Mock<IOptions<AppSettings>> _options;
        private Mock<IGameRules> _gameRules;
        private Mock<IGame> _game;


        [SetUp]
        public void Setup()
        {
            _configuration = new Mock<IConfiguration>();

            // IOptions to be the AppSettings Class
            _options = new Mock<IOptions<AppSettings>>();
            _gameRules = new Mock<IGameRules>();
            _options.Setup(ap => ap.Value).Returns(TestHelper.GetSettings());
            _game = new Mock<IGame>();
           
        }

        [Test]
        public void PlayGame_RockAndScissors_ShouldReturn_HumanPlayerWins()
        {
            //Arrange    
            _gameRules.Setup(r => r.GetWinner(GameShapes.Rock, GameShapes.Scissors)).Returns(GameDecisionResult.Win);
            _game.Setup(x => x.GetPlayDecisionResult(GameShapes.Rock, GameShapes.Scissors)).Returns(GameDecisionResult.Win);
            _game.Setup(x => x.GetPlayDecisionResultMessage(GameShapes.Rock, GameShapes.Scissors, GameDecisionResult.Win)).Returns("Rock beats Scissors.Human player wins");

            var controller = new RPSGameService(_game.Object,_configuration.Object);   
            
           //Act
           var result= controller.PlayGame(GameShapes.Rock, GameShapes.Scissors).Result;
           

            //Assert
           Assert.IsNotNull(result);         
          Assert.AreEqual("Rock beats Scissors.Human player wins", result);
        }

        [Test]
        public void PlayGame_ScissorsAndPaper_ShouldReturn_HumanPlayerWins()
        {
            //Arrange   
            _gameRules.Setup(r => r.GetWinner(GameShapes.Scissors, GameShapes.Paper)).Returns(GameDecisionResult.Win);
            _game.Setup(x => x.GetPlayDecisionResult(GameShapes.Scissors, GameShapes.Paper)).Returns(GameDecisionResult.Win);
            _game.Setup(x => x.GetPlayDecisionResultMessage(GameShapes.Scissors, GameShapes.Paper, GameDecisionResult.Win)).Returns("Scissors beats Paper.Human player wins");

            var controller = new RPSGameService(_game.Object, _configuration.Object);

            //Act
            var result = controller.PlayGame(GameShapes.Scissors, GameShapes.Paper).Result;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Scissors beats Paper.Human player wins", result);
        }


        [Test]
        public void PlayGame_PaperAndRock_ShouldReturn_HumanPlayerWins()
        {
            //Arrange  
            _gameRules.Setup(r => r.GetWinner(GameShapes.Paper, GameShapes.Rock)).Returns(GameDecisionResult.Win);
            _game.Setup(x => x.GetPlayDecisionResult(GameShapes.Paper, GameShapes.Rock)).Returns(GameDecisionResult.Win);
            _game.Setup(x => x.GetPlayDecisionResultMessage(GameShapes.Paper, GameShapes.Rock, GameDecisionResult.Win)).Returns("Paper beats Rock.Human player wins");

            var controller = new RPSGameService(_game.Object, _configuration.Object);

            //Act
            var result = controller.PlayGame(GameShapes.Paper, GameShapes.Rock).Result;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Paper beats Rock.Human player wins", result);
        }


        [Test]
        public void PlayGame_PaperAndPaper_ShouldReturn_Tie()
        {
            //Arrange 
            _gameRules.Setup(r => r.GetWinner(GameShapes.Paper, GameShapes.Paper)).Returns(GameDecisionResult.Tie);
            _game.Setup(x => x.GetPlayDecisionResult(GameShapes.Paper, GameShapes.Paper)).Returns(GameDecisionResult.Tie);
            _game.Setup(x => x.GetPlayDecisionResultMessage(GameShapes.Paper, GameShapes.Paper, GameDecisionResult.Tie)).Returns("It is a tie");
            var controller = new RPSGameService(_game.Object, _configuration.Object);

            //Act
            var result = controller.PlayGame(GameShapes.Paper, GameShapes.Paper).Result;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("It is a tie", result);
        }


        [Test]
        public void PlayGame_ScissorsAndRock_ShouldReturn_ComputerPlayerWins()
        {
            //Arrange    
            _gameRules.Setup(r => r.GetWinner(GameShapes.Scissors, GameShapes.Rock)).Returns(GameDecisionResult.Lose);
           _game.Setup(x => x.GetPlayDecisionResult(GameShapes.Scissors, GameShapes.Rock)).Returns(GameDecisionResult.Lose);
            _game.Setup(x => x.GetPlayDecisionResultMessage(GameShapes.Scissors, GameShapes.Rock, GameDecisionResult.Lose)).Returns("Rock beats Scissors.Computer player wins");

            var controller = new RPSGameService(_game.Object, _configuration.Object);

            //Act
            var result = controller.PlayGame(GameShapes.Scissors, GameShapes.Rock).Result;


            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Rock beats Scissors.Computer player wins", result);
        }

        [Test]
        public void PlayGame_PaperAndScissors_ShouldReturn_ComputerPlayerWins()
        {
            //Arrange   
            _gameRules.Setup(r => r.GetWinner(GameShapes.Paper, GameShapes.Scissors)).Returns(GameDecisionResult.Lose);
            _game.Setup(x => x.GetPlayDecisionResult(GameShapes.Paper, GameShapes.Scissors)).Returns(GameDecisionResult.Lose);
            _game.Setup(x => x.GetPlayDecisionResultMessage(GameShapes.Paper, GameShapes.Scissors, GameDecisionResult.Lose)).Returns("Scissors beats Paper.Computer player wins");

            var controller = new RPSGameService(_game.Object, _configuration.Object);

            //Act
            var result = controller.PlayGame(GameShapes.Paper, GameShapes.Scissors).Result;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Scissors beats Paper.Computer player wins", result);
        }


        [Test]
        public void PlayGame_RockAndPaper_ShouldReturn_ComputerPlayerWins()
        {
            //Arrange  
            _gameRules.Setup(r => r.GetWinner(GameShapes.Rock, GameShapes.Paper)).Returns(GameDecisionResult.Lose);
            _game.Setup(x => x.GetPlayDecisionResult(GameShapes.Rock, GameShapes.Paper)).Returns(GameDecisionResult.Lose);
            _game.Setup(x => x.GetPlayDecisionResultMessage(GameShapes.Rock, GameShapes.Paper, GameDecisionResult.Lose)).Returns("Paper beats Rock.Computer player wins");

            var controller = new RPSGameService(_game.Object, _configuration.Object);

            //Act
            var result = controller.PlayGame(GameShapes.Rock, GameShapes.Paper).Result;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Paper beats Rock.Computer player wins", result);
        }

    }
}
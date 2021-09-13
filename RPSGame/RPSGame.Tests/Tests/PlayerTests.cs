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
    public class PlayerTests
    {   
        private IPlayer _player;

        [SetUp]
        public void Setup()
        {
            _player = new HumanPlayer() { Name="Human player" };        
        }

        [Test]
        public void GetPlayerName_ShouldReturnHumanPlayer()
        {
                    
           //Act
           var result= _player.GetPlayerName();
           
            //Assert
           Assert.IsNotNull(result);         
          Assert.AreEqual("Human player", result);

        }

        [Test]
        public void etPlayerName_ShouldReturnEmpty()
        {
            //Arrange   
            _player = new HumanPlayer() { Name = "" };

            //Act
            var result = _player.GetPlayerName();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("", result);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Text;
using RPSGame.Core.Common;
using RPSGame.Core.Interfaces;
using RPSGame.Core.Entities;
using RPSGame.Core.Controller;
using Moq;

namespace RPSGame.Tests.Common
{
   public static class TestHelper
    {       

        public static AppSettings GetSettings()
        {
            return new AppSettings() {OverAllMaximumWins = 2, TotalGameMatch=3  };          
        }
               
    }
}

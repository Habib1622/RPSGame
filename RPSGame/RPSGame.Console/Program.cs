using System;
using System.Collections.Generic;
using System.Text;
using RPSGame.Core.Interfaces;
using RPSGame.Core.Common;
using RPSGame.Core.Controller;
using RPSGame.Core.Utilities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace RPSGame
{
    class Program
    {
      
        static  void Main(string[] args)
        {
            var collection = new ServiceCollection();
            bool playGame = true;
            Configuration.ConfigureServices(collection);
                       
            IServiceProvider serviceProvider = collection.BuildServiceProvider();
            IPSRGameService gameService = serviceProvider.GetService<IPSRGameService>();
            IConfiguration configuration = serviceProvider.GetService<IConfiguration>();
            IComputerPlayer computerPlayer = serviceProvider.GetService<IComputerPlayer>();
           

            //  Continue while play game flag is true
            
            while (playGame)
            {             
                int totalMatches;
                int.TryParse(configuration["AppSettings:TotalGameMatch"], out totalMatches);

                
                for (int i = 0; i < totalMatches; i++)
                {
                    Console.WriteLine("Please enter your selection from rock,paper or scissors");
                    var selection = Console.ReadLine();

                    // loop until selection is not valid
                    while ( gameService.ValidateSelection(selection).Result == false)
                    {
                        Console.WriteLine("Invalid selection. Please re-enter your selection");
                        selection = Console.ReadLine();
                    }
                                            
                    var player1Selection =  gameService.GetPlayDecision(selection).Result;

                    // computer random selection
                    var player2Selection = computerPlayer.GetRandomSelection();
                    Console.WriteLine("Computer player selected: {0}", player2Selection);

                    //play game after the selctions
                    var message= gameService.PlayGame(player1Selection, player2Selection).Result;

                    Console.WriteLine(message);

                }

                //display over all game winner
                Console.WriteLine(gameService.DisplayOverAllGameWiner().Result);
                           

                Console.WriteLine("Would you like to play again (y or n)?");
                 var userResponse = Convert.ToChar(Console.ReadLine());
                if (userResponse == 'N' || userResponse == 'n')
                    playGame = false;

            }

            Console.WriteLine("The game is ended");

            Console.ReadLine();
        }
               
    }

}

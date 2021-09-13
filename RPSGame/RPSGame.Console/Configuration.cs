using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using RPSGame.Core.Common;
using RPSGame.Core.Interfaces;
using RPSGame.Core.Controller;

namespace RPSGame
{
    public static  class Configuration
    {
        public static void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<IPlayer>(x => new HumanPlayer() { Name= "Human Player" });
            services.AddScoped<IComputerPlayer>(x => new ComputerPlayer() { Name = "Computer Player" });
            services.AddScoped<IGameRules, GameRules>();
            services.AddScoped<IGame, Game>();
            services.AddScoped<IPSRGameService, RPSGameService>();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);

             IConfiguration configuration = builder.Build();

            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
            services.AddSingleton(configuration);

        }


    }


}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace flights_api
{
    public class Program
    {
        public static List<Flight> Flights {get;set;} = new List<Flight>{
            new Flight{FlightNumber = "WZZ4214", From = "Cluj-Napoca", To = "Bucharest" },
            new Flight{FlightNumber = "WZZ4111", From = "Cluj-Napoca", To = "Rome" },
            new Flight{FlightNumber = "RYN9124", From = "London", To = "Iasi" },
        };

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}

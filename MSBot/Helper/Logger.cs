using MSBot.Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSBot.Helper
{
    public static class Logger
    {
        public static void Log(BasicBot bot, string message) 
        {
            string currentTime = DateTime.Now.ToString("h:mm:ss");
            Console.WriteLine($"{currentTime} - [{bot.Name}] => {message}");
        }
    }
}

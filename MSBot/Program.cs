using MSBot.Bot;
using MSBot.Models.Bot;
using System.Runtime.InteropServices;
using System.Text;
/// <summary>
/// My own question as reference: https://stackoverflow.com/questions/35138778/sending-keys-to-a-directx-game
/// http://www.gamespp.com/directx/directInputKeyboardScanCodes.html
/// </summary>
/// 

namespace MSBot
{

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting bots...");
            Thread.Sleep(3000);
            new BotManager().manageBots();

            //new Thread(new ThreadStart(() => { new JumpBot(BehaviorGenerator.generateChangeChannelBehavior(), "ChangeChannelBot").delegateKeyCommands(); })).Start();
            //new Thread(new ThreadStart(() => { new MovementBot(BehaviorGenerator.generateChangeChannelBehavior(), "MovementBot").delegateKeyCommands(); })).Start();
            //new Thread(new ThreadStart(() => { new MovementBot(new BehaviorGenerator().generateTrainingBehaviors().Item1, "MovementBot").delegateKeyCommands(); })).Start();
        }
    }

}
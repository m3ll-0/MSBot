using MSBot.Bot;
using MSBot.Models.Bot;
using System.Diagnostics;

namespace MSBot
{
    public class BotManager
    {
        private volatile int numberOfRunningThreads = 4;
        private volatile List<Thread> threadPool = new List<Thread>();
        private volatile bool threadPoolUp = true;
        private volatile bool threadChannelUp = false;
        private Stopwatch stopwatch;

        public void manageBots() {

            // Start main bots
            startMainBots();

            // Start stopwatch
            this.stopwatch = Stopwatch.StartNew();

            // Callback
            var notifier = () => {
                this.threadChannelUp = false;
                startMainBots();
            };

            // Main application loop
            for (; ; ) {

                if(!this.threadPoolUp && this.stopwatch.ElapsedMilliseconds >= Config.config.totalProgramExecutionTimeInMilliseconds){
                    // Call ending script
                    Console.WriteLine("Ending!");
                    BasicBot endingBot = new JumpBot(BehaviorGenerator.generateEndingCommands(), "EndingBot");
                    new Thread(new ThreadStart(() => { endingBot.delegateKeyCommands(); })).Start();                    
                    break;
                }

                if (this.threadPoolUp && !threadChannelUp)
                {
                    Console.WriteLine("Main thread pool is up. In training mode.");
                    Thread.Sleep(500);
                }
                else if(!threadPoolUp && !threadChannelUp)
                {
                    Console.WriteLine("Main thread pool is down. Changing channel!");
                    this.threadChannelUp = true;
                    new Thread(new ThreadStart(() => { new JumpBot(BehaviorGenerator.generateChangeChannelBehavior(), "ChangeChannelBot").delegateKeyCommands(); notifier(); })).Start();
                }
                else if (!this.threadPoolUp && threadChannelUp) {
                    Console.WriteLine("Changing channel...");
                    Thread.Sleep(500);
                }
            }
        }

        public void startMainBots()
        {
            this.threadPoolUp = true;
            this.numberOfRunningThreads = 4;
            this.threadPool.Clear();

            // Generate behavior
            BehaviorGenerator behaviorGenerator = new BehaviorGenerator();
            var behaviorTrainingTuple = behaviorGenerator.generateTrainingBehaviors();

            // Initialize bots with their respective behavior
            BasicBot movementBot = new MovementBot(behaviorTrainingTuple.Item1, "MovementBot");
            BasicBot attackBot = new AttackBot(behaviorTrainingTuple.Item2, "AttackBot");
            BasicBot jumpBot = new JumpBot(behaviorTrainingTuple.Item3, "JumpBot");
            BasicBot buffBot = new BuffBot(behaviorTrainingTuple.Item4, "BuffBot");

            var notifier = () => {
                this.numberOfRunningThreads--;

                //Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXX: " + numberOfRunningThreads);

                // When all threads are finished
                if (numberOfRunningThreads == 1)
                {
                    // Stop remaining threads in threadpool
                    foreach (Thread thread in this.threadPool)
                    {
                        thread.Interrupt();
                    }

                    this.threadPoolUp = false;
                }
            };

            // Initialize threadpool with reference to callback
            this.threadPool = new List<Thread>
            {
                new Thread(new ThreadStart(() => { movementBot.delegateKeyCommands(); notifier(); })),
                new Thread(new ThreadStart(() => { attackBot.delegateKeyCommands(); notifier(); })),
                new Thread(new ThreadStart(() => { jumpBot.delegateKeyCommands(); notifier(); })),
                new Thread(new ThreadStart(() => { buffBot.delegateKeyCommands(); notifier(); }))
            };


            // Start threads in threadpool
            foreach (Thread thread in this.threadPool) {
                thread.Start();
            }
        }
    }
}

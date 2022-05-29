using MSBot.Models.Key;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSBot.Bot
{
    public abstract class BasicBot
    {
        private List<KeyCommand> keyCommands;
        public string Name { get; set; }

        public BasicBot(List<KeyCommand> keyCommands, string name)
        {
            this.keyCommands = keyCommands;
            this.Name = name;
        }

        public void delegateKeyCommands()
        {
            foreach (KeyCommand keyCommand in keyCommands)
            {
                Helper.Logger.Log(this, keyCommand.getKeyCode().ToString());

                // Sleep if keyCommand is pause
                if (keyCommand.getKeyCode() == 0x00)
                {
                    sleep(keyCommand.getTimeInMilliseconds());
                    continue;
                }

                // Execute keyCommands
                KeyCommandExecutioner keyCommandExecutioner = new KeyCommandExecutioner();
                keyCommandExecutioner.executeKeyCommand(keyCommand);
                sleep(50);
            }
        }

        private void sleep(int timeInMilliSeconds) {
            // Prevent thread from throwing exception when interrupting on sleep
            try
            {
                Thread.Sleep(timeInMilliSeconds);
            }
            catch (ThreadInterruptedException e)
            {}
        }
    }
}

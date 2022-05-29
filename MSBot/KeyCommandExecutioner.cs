using MSBot.Bot;
using MSBot.Models.Key;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSBot
{
    public class KeyCommandExecutioner
    {
        public void executeKeyCommand(KeyCommand keyCommand) {
            Keyboard.SendKey(keyCommand.getKeyCode(), false, Keyboard.InputType.Keyboard);
            sleep(keyCommand.getTimeInMilliseconds());
            Keyboard.SendKey(keyCommand.getKeyCode(), true, Keyboard.InputType.Keyboard);
        }

        private void sleep(int timeInMilliSeconds)
        {
            // Prevent thread from throwing exception when interrupting on sleep
            try
            {
                Thread.Sleep(timeInMilliSeconds);
            }
            catch (ThreadInterruptedException e)
            { }
        }
    }
}

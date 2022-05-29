using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSBot.Models.Key
{
    public class KeyCommand
    {
        private Keyboard.DirectXKeyStrokes keyCode;
        private int timeInMilliseconds;

        public KeyCommand(Keyboard.DirectXKeyStrokes keyCode, int timeInMilliseconds)
        {
            this.keyCode = keyCode;
            this.timeInMilliseconds = timeInMilliseconds;
        }

        public Keyboard.DirectXKeyStrokes getKeyCode()
        {
            return keyCode;
        }

        public int getTimeInMilliseconds()
        {
            return timeInMilliseconds;
        }
    }

    public static class KeyCommandListExtension
    {
        // This is the extension method.
        // The first parameter takes the "this" modifier
        // and specifies the type for which the method is defined.
        public static int totalTime(this List<KeyCommand> keyCommands)
        {
            return keyCommands.Sum(item => item.getTimeInMilliseconds());
        }
    }
}

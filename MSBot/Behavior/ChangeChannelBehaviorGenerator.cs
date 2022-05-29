using MSBot.Models.Key;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSBot.Behavior
{
    public class ChangeChannelBehaviorGenerator
    {

        public List<KeyCommand> generateChangeChannelBehavior()
        {
            List<KeyCommand> changeChannelList = new List<KeyCommand>();

            changeChannelList.AddRange(generateChangeChannelOpenMenuCommands());

            int channelRand = new Random().Next(1, 10);

            for (int x = 0; x < channelRand; x++) {
                changeChannelList.AddRange(generateChangeChannelRightCommands());
            }
            
            changeChannelList.AddRange(generateChangeChannelEnterCommands());

            List<KeyCommand> dupeList = new List<KeyCommand>();
            dupeList.AddRange(changeChannelList);
            dupeList.AddRange(changeChannelList);
            return dupeList;
        }

        private List<KeyCommand> generateChangeChannelOpenMenuCommands()
        {
            return new List<KeyCommand>
            {
                new KeyCommand(Keyboard.DirectXKeyStrokes.DIK_F10, 200),
                new KeyCommand(Keyboard.DirectXKeyStrokes.DIK_PAUSE, 200)
            };
        }

        private List<KeyCommand> generateChangeChannelRightCommands()
        {
            return new List<KeyCommand>
            {
                new KeyCommand(Keyboard.DirectXKeyStrokes.DIK_RIGHTARROW, 200),
                new KeyCommand(Keyboard.DirectXKeyStrokes.DIK_PAUSE, 500)
            };
        }

        private List<KeyCommand> generateChangeChannelEnterCommands()
        {
            return new List<KeyCommand>
            {
                new KeyCommand(Keyboard.DirectXKeyStrokes.DIK_PAUSE, 1500),
                new KeyCommand(Keyboard.DirectXKeyStrokes.DIK_RETURN, 500),
                new KeyCommand(Keyboard.DirectXKeyStrokes.DIK_PAUSE, 1000),
            };
        }

        private List<KeyCommand> generatePauseCommands()
        {
            return new List<KeyCommand>
            {
                new KeyCommand(Keyboard.DirectXKeyStrokes.DIK_PAUSE, 700)
            };
        }
    }
}

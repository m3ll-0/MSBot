using MSBot.Models.Key;
using MSBot.Models.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSBot.Behavior
{
    public class BuffBehaviorGenerator
    {

        private int totalBotTimeInMilliseconds;
        private BuffStrategy buffStrategy;

        public BuffBehaviorGenerator(int totalBotTimeInMilliseconds, BuffStrategy buffStrategy)
        {
            this.totalBotTimeInMilliseconds = totalBotTimeInMilliseconds;
            this.buffStrategy = buffStrategy;
        }

        public List<KeyCommand> generateBuffBehavior()
        {

            List<KeyCommand> movementList = new List<KeyCommand>();

            for (; ; )
            {
                // Random number based on percentage
                int movementRand = new Random().Next(0, 99);

                // todo create distribution

                switch (movementRand)
                {

                    case var value when value <= buffStrategy.BuffAllCommandsDistributionHigh:
                        movementList.AddRange(generateBuffCommands());
                        break;
                    case var value when value > buffStrategy.PauseLongDistributionLow | value <= buffStrategy.PauseLongDistributionHigh:
                        movementList.AddRange(generatePauseCommandsLong());
                        break;
                }

                // Calculate time left
                if (movementList.totalTime() > totalBotTimeInMilliseconds)
                {
                    break;
                }

            }

            return movementList;
        }

        private List<KeyCommand> generateBuffCommands()
        {
            return new List<KeyCommand>
            {
                new KeyCommand(Keyboard.DirectXKeyStrokes.DIK_5, 200),
                new KeyCommand(Keyboard.DirectXKeyStrokes.DIK_6, 200),
                new KeyCommand(Keyboard.DirectXKeyStrokes.DIK_7, 200),
                new KeyCommand(Keyboard.DirectXKeyStrokes.DIK_8, 200),
                new KeyCommand(Keyboard.DirectXKeyStrokes.DIK_9, 200),
                new KeyCommand(Keyboard.DirectXKeyStrokes.DIK_0, 200)
            };
        }

        private List<KeyCommand> generatePauseCommands()
        {
            return new List<KeyCommand>
            {
                new KeyCommand(Keyboard.DirectXKeyStrokes.DIK_PAUSE, 700)
            };
        }

        private List<KeyCommand> generatePauseCommandsLong()
        {
            return new List<KeyCommand>
            {
                new KeyCommand(Keyboard.DirectXKeyStrokes.DIK_PAUSE, 30000)
            };
        }
    }
}

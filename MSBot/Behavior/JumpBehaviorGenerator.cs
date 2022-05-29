using MSBot.Models.Key;
using MSBot.Models.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSBot.Behavior
{
    public class JumpBehaviorGenerator
    {
        private int totalBotTimeInMilliseconds;
        private JumpStrategy jumpStrategy;

        public JumpBehaviorGenerator(int totalBotTimeInMilliseconds, JumpStrategy movementStrategy)
        {
            this.totalBotTimeInMilliseconds = totalBotTimeInMilliseconds;
            this.jumpStrategy = movementStrategy;
        }

        public List<KeyCommand> generateJumpBehavior()
        {
            List<KeyCommand> jumpList = new List<KeyCommand>();

            for (; ; )
            {
                // Random number based on percentage
                int jumpRand = new Random().Next(0, 99);

                switch (jumpRand)
                {
                    case var value when value <= jumpStrategy.JumpSingleDistributionHigh:
                        jumpList.AddRange(generateJumpSingleCommands());
                        break;
                    case var value when value > jumpStrategy.JumpDoubleDistributionLow | value <= jumpStrategy.JumpDoubleDistributionHigh:
                        jumpList.AddRange(generateJumpDoubleCommands());
                        break;
                    case var value when value > jumpStrategy.JumpDoubleHighDistributionLow | value <= jumpStrategy.JumpDoubleHighDistributionHigh:
                        jumpList.AddRange(generateJumpDoubleHighCommands());
                        break;
                    case var value when value > jumpStrategy.PauseDistributionLow | value <= jumpStrategy.PauseDistributionHigh:
                        jumpList.AddRange(generatePauseCommands());
                        break;
                }

                // Calculate time left
                if (jumpList.totalTime() > totalBotTimeInMilliseconds)
                {
                    break;
                }

            }

            return jumpList;
        }

        private List<KeyCommand> generateJumpSingleCommands()
        {
            return new List<KeyCommand>
            {
                new KeyCommand(Keyboard.DirectXKeyStrokes.DIK_LALT, 200)
            };
        }

        private List<KeyCommand> generateJumpDoubleCommands()
        {
            return new List<KeyCommand>
            {
                new KeyCommand(Keyboard.DirectXKeyStrokes.DIK_LALT, 200),
                new KeyCommand(Keyboard.DirectXKeyStrokes.DIK_LALT, 200)
            };
        }

        private List<KeyCommand> generateJumpDoubleHighCommands()
        {
            return new List<KeyCommand>
            {
                new KeyCommand(Keyboard.DirectXKeyStrokes.DIK_LALT, 200),
                new KeyCommand(Keyboard.DirectXKeyStrokes.DIK_UPARROW, 70),
                new KeyCommand(Keyboard.DirectXKeyStrokes.DIK_LALT, 200)
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

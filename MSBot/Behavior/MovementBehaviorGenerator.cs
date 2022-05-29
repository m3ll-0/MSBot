using MSBot.Models.Key;
using MSBot.Models.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSBot.Behavior
{
    public class MovementBehaviorGenerator
    {

        private int totalBotTimeInMilliseconds;
        private MovementStrategy movementStrategy;

        public MovementBehaviorGenerator(int totalBotTimeInMilliseconds, MovementStrategy movementStrategy)
        {
            this.totalBotTimeInMilliseconds = totalBotTimeInMilliseconds;
            this.movementStrategy = movementStrategy;
        }

        public List<KeyCommand> generateMovementBehavior()
        {

            List<KeyCommand> movementList = new List<KeyCommand>();

            for (; ; )
            {
                // Random number based on percentage
                int movementRand = new Random().Next(0, 99);

                // todo create distribution

                switch (movementRand)
                {

                    case var value when value <= movementStrategy.MoveLeftOfMapDistributionHigh:
                        movementList.AddRange(generateMoveLeftOfMapCommands());
                        break;
                    case var value when value > movementStrategy.MoveRightOfMapDistributionLow | value <= movementStrategy.MoveRightOfMapDistributionHigh:
                        movementList.AddRange(generateMoveRightOfMapCommands());
                        break;
                    case var value when value > movementStrategy.MoveShortLeftDistributionLow | value <= movementStrategy.MoveShortLeftDistributionHigh:
                        movementList.AddRange(generateMoveShortLeftCommands());
                        break;
                    case var value when value > movementStrategy.MoveShortRightDistributionLow | value <= movementStrategy.MoveShortRightDistributionHigh:
                        movementList.AddRange(generateMoveShortRightCommands());
                        break;
                    case var value when value > movementStrategy.MoveUpDistributionLow | value <= movementStrategy.MoveUpDistributionHigh:
                        movementList.AddRange(generateMoveUpCommands());
                        break;
                    case var value when value > movementStrategy.MoveDownDistributionLow | value <= movementStrategy.MoveDownDistributionHigh:
                        movementList.AddRange(generateMoveDownCommands());
                        break;
                    case var value when value > movementStrategy.PauseDistributionLow | value <= movementStrategy.PauseDistributionHigh:
                        movementList.AddRange(generatePauseCommands());
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

        private List<KeyCommand> generateMoveLeftOfMapCommands()
        {

            return new List<KeyCommand>
            {
                new KeyCommand(Keyboard.DirectXKeyStrokes.DIK_LEFTARROW, 5000),
                new KeyCommand(Keyboard.DirectXKeyStrokes.DIK_RIGHTARROW, 800)
            };
        }

        private List<KeyCommand> generateMoveRightOfMapCommands()
        {
            return new List<KeyCommand>
            {
                new KeyCommand(Keyboard.DirectXKeyStrokes.DIK_RIGHTARROW, 5000),
                new KeyCommand(Keyboard.DirectXKeyStrokes.DIK_LEFTARROW, 800)
            };
        }

        private List<KeyCommand> generateMoveShortLeftCommands()
        {
            return new List<KeyCommand>
            {
                new KeyCommand(Keyboard.DirectXKeyStrokes.DIK_LEFTARROW, 800)
            };
        }

        private List<KeyCommand> generateMoveShortRightCommands()
        {
            return new List<KeyCommand>
            {
                new KeyCommand(Keyboard.DirectXKeyStrokes.DIK_RIGHTARROW, 800)
            };
        }

        private List<KeyCommand> generateMoveUpCommands()
        {
            return new List<KeyCommand>
            {
                new KeyCommand(Keyboard.DirectXKeyStrokes.DIK_UPARROW, 800)
            };
        }

        private List<KeyCommand> generateMoveDownCommands()
        {
            return new List<KeyCommand>
            {
                new KeyCommand(Keyboard.DirectXKeyStrokes.DIK_DOWNARROW, 800)
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

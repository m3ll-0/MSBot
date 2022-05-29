using MSBot.Behavior;
using MSBot.Models.Key;
using MSBot.Models.Strategy;
using MSBot.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSBot
{
    public class BehaviorGenerator
    {
        private int totalBotTimeInMilliseconds = Config.config.totalTrainerExecutionTimeInMilliseconds;

        public (List<KeyCommand>, List<KeyCommand>, List<KeyCommand>, List<KeyCommand>) generateTrainingBehaviors() {

            List<KeyCommand> movementList = new MovementBehaviorGenerator(totalBotTimeInMilliseconds, new MovementStrategySideBySide()).generateMovementBehavior();
            List<KeyCommand> attackList = new AttackBehaviorGenerator(totalBotTimeInMilliseconds, new AttackStrategyNormal()).generateAttackBehavior();
            List<KeyCommand> jumpList = new JumpBehaviorGenerator(totalBotTimeInMilliseconds, new JumpStrategyNormal()).generateJumpBehavior();
            List<KeyCommand> buffList = new BuffBehaviorGenerator(totalBotTimeInMilliseconds, new BuffStrategyNormal()).generateBuffBehavior();

            Console.WriteLine(movementList.totalTime());
            Console.WriteLine(attackList.totalTime());
            Console.WriteLine(jumpList.totalTime());
            Console.WriteLine(buffList.totalTime());

            return (movementList, attackList, jumpList, buffList);
        }

        public static List<KeyCommand> generateChangeChannelBehavior()
        {
            return new ChangeChannelBehaviorGenerator().generateChangeChannelBehavior();
        }

        public static List<KeyCommand> generateEndingCommands()
        {
            return new List<KeyCommand>
            {
                new KeyCommand(Keyboard.DirectXKeyStrokes.DIK_F11, 200)
            };
        }
    }
}

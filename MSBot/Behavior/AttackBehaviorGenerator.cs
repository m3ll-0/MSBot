using MSBot.Models.Key;
using MSBot.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSBot.Behavior
{
    public class AttackBehaviorGenerator
    {

        private int totalBotTimeInMilliseconds;
        private AttackStrategy attackStrategy;

        public AttackBehaviorGenerator(int totalBotTimeInMilliseconds, AttackStrategy attackStrategy) 
        {
            this.totalBotTimeInMilliseconds = totalBotTimeInMilliseconds;
            this.attackStrategy = attackStrategy;
        }

        public List<KeyCommand> generateAttackBehavior()
        {
            List<KeyCommand> attackList = new List<KeyCommand>();

            for (; ; )
            {
                // Random number based on percentage
                int attackRand = new Random().Next(0, 99);

                // todo implement specter state

                switch (attackRand)
                {
                    case var value when value <= attackStrategy.AttackNormalDistributionHigh:
                        attackList.AddRange(generateAttackNormalCommands());
                        break;
                    case var value when value > attackStrategy.AttackSwipeDistributionLow | value <= attackStrategy.AttackNormalDistributionHigh:
                        attackList.AddRange(generateAttackSwipeCommands());
                        break;
                    case var value when value > attackStrategy.AttackSlashDistributionLow | value <= attackStrategy.AttackSlashDistributionHigh:
                        attackList.AddRange(generateAttackSlashCommands());
                        break;
                    case var value when value > attackStrategy.AttackCubeDistributionLow | value <= attackStrategy.AttackCubeDistributionHigh:
                        attackList.AddRange(generateAttackCubeCommands());
                        break;
                    case var value when value > attackStrategy.AttackChargeDistributionLow | value <= attackStrategy.AttackChargeDistributionLow:
                        attackList.AddRange(generateAttackChargeCommands());
                        break;
                    case var value when value > attackStrategy.PauseDistributionLow | value <= attackStrategy.PauseDistributionHigh:
                        attackList.AddRange(generatePauseCommands());
                        break;
                }


                // Calculate time left
                if (attackList.totalTime() > totalBotTimeInMilliseconds)
                {
                    break;
                }

            }

            return attackList;
        }

        private List<KeyCommand> generateAttackNormalCommands()
        {
            return new List<KeyCommand>
            {
                new KeyCommand(Keyboard.DirectXKeyStrokes.DIK_Z, 200)
            };
        }

        private List<KeyCommand> generateAttackSwipeCommands()
        {
            return new List<KeyCommand>
            {
                new KeyCommand(Keyboard.DirectXKeyStrokes.DIK_LSHIFT, 200)
            };
        }

        private List<KeyCommand> generateAttackSlashCommands()
        {
            return new List<KeyCommand>
            {
                new KeyCommand(Keyboard.DirectXKeyStrokes.DIK_S, 200)
            };
        }

        private List<KeyCommand> generateAttackCubeCommands()
        {
            return new List<KeyCommand>
            {
                new KeyCommand(Keyboard.DirectXKeyStrokes.DIK_A, 200)
            };
        }

        private List<KeyCommand> generateAttackChargeCommands()
        {
            return new List<KeyCommand>
            {
                new KeyCommand(Keyboard.DirectXKeyStrokes.DIK_D, 200)
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

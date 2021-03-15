using System;
using System.Collections.Generic;

namespace LastStandSimulator
{
    public class Program
    {
        static Random rand = new Random();

        static void Main(string[] args)
        {
            int winCount = 0;
            int numberOfSimulations = 1_000_000;


            var ourCount = 26;
            var enemyCounts = new int[] { 8, 31, 43, 8 };

            Console.WriteLine("Running simulations for the following attack:");
            Console.WriteLine("Fighting: " + ourCount + " --> [" + string.Join(", ", enemyCounts) + "]");


            for (int i = 0; i < numberOfSimulations; i++)
            {
                var result = SimulateRound(ourCount, new List<int>(enemyCounts).ToArray());
                //Console.WriteLine("Won? " + result.weWon);
                //Console.WriteLine("    Our Count   : " + result.ourCount);
                //Console.WriteLine("    Their Counts: [" + string.Join(", ", result.enemyCounts) + "]");
                if (result.weWon)
                {
                    winCount++;
                }
            }

            var winPercentage = winCount / (numberOfSimulations * 1.0) * 100;
            Console.WriteLine($"We ran {numberOfSimulations:n0} simulations and won {winCount:n0} times.");
            Console.WriteLine($"Simulated probability of winning is {winPercentage:F3}%");
        }

        static RoundResult SimulateRound(int ourCount, int[] enemyCounts)
        {
            for (int i = 0; i < enemyCounts.Length; i++)
            {
                while (ourCount > 1 && enemyCounts[i] > 0)
                {
                    var result = SimulateFight(ourCount, enemyCounts[i]);
                    ourCount = result.attackerCount;
                    enemyCounts[i] = result.defenderCount;
                }

                if (ourCount > 1)
                {
                    ourCount--;
                }
                else
                {
                    return new RoundResult()
                    {
                        ourCount = ourCount,
                        enemyCounts = enemyCounts,
                        weWon = false
                    };
                }
            }

            return new RoundResult()
            {
                ourCount = ourCount,
                enemyCounts = enemyCounts,
                weWon = true
            };
        }

        class RoundResult
        {
            public int ourCount;
            public int[] enemyCounts;
            public bool weWon;
        }

        static FightResult SimulateFight(int attackerCount, int defenderCount)
        {
            var attackerRolls = new List<int>(3);
            for (int i = 0; i + 1 < attackerCount && i < 3; i++)
            {
                attackerRolls.Add(RollDie());
            }

            var defenderRolls = new List<int>(2);
            for (int i = 0; i < defenderCount && i < 2; i++)
            {
                defenderRolls.Add(RollDie());
            }

            attackerRolls.Sort();
            attackerRolls.Reverse();

            defenderRolls.Sort();
            defenderRolls.Reverse();


            //Console.WriteLine("    --------------------");
            //Console.WriteLine("    " + attackerCount + " --> " + defenderCount);
            //Console.WriteLine("    Attacker: " + string.Join(", ", attackerRolls));
            //Console.WriteLine("    Defender: " + string.Join(", ", defenderRolls));
            //Console.Write("              ");

            for (int i = 0; i < attackerRolls.Count && i < defenderRolls.Count; i++)
            {
                if (attackerRolls[i] >= defenderRolls[i])
                {
                    //Console.Write("W ");
                    defenderCount--;
                }
                else
                {
                    //Console.Write("L ");
                    attackerCount--;
                }
            }

            //Console.WriteLine();

            return new FightResult()
            {
                attackerCount = attackerCount,
                defenderCount = defenderCount
            };
        }

        class FightResult
        {
            public int defenderCount;
            public int attackerCount;
        }

        static int RollDie()
        {
            return rand.Next(6) + 1;
        }
    }
}

using System.Threading;
using System;
using System.Threading.Tasks;

namespace SuddenDeathPlus
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            OsuMemory osuMemory = new();

            Console.WriteLine("Waiting for game start...");
            while (true)
            {
                int gameStatus = await osuMemory.GetGameStatus();
                int modsEnabled = await osuMemory.GetModsEnabled();
                short hitMiss = await osuMemory.GetMisses();

                if (gameStatus == 2 && (modsEnabled & 32) != 0 && hitMiss >= 1 && hitMiss != 27136)
                {
                    Console.WriteLine("Fatal mistake..");
                    Thread.Sleep(3000);
                    break;
                }

                Thread.Sleep(1000);
            }
        }
    }
}

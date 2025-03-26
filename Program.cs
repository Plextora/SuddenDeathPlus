using System.Threading;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace SuddenDeathPlus
{
    internal class Program
    {
        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern void RtlSetProcessIsCritical(UInt32 v1, UInt32 v2, UInt32 v3);

        private static void TriggerBSOD()
        {
            System.Diagnostics.Process.EnterDebugMode();
            RtlSetProcessIsCritical(1, 0, 0);
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private static async Task Main(string[] args)
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
                    TriggerBSOD();
                    break;
                }

                Thread.Sleep(1000);
            }
        }
    }
}

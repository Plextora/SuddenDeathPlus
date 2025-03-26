using System.Threading;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SuddenDeathPlus
{
    internal class Program
    {
        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern void RtlSetProcessIsCritical(uint v1, uint v2, uint v3);

        private static void TriggerBSOD()
        {
            Process.EnterDebugMode();
            RtlSetProcessIsCritical(1, 0, 0);
            Process.GetCurrentProcess().Kill();
        }

        private static async Task Main(string[] args)
        {
            if (Process.GetProcessesByName("osu!").Length == 0)
            {
                Console.WriteLine("osu! isn't running you silly goose");
                Console.WriteLine("Press any key to exit..");
                Console.ReadKey();
                Environment.Exit(0);
            }

            OsuMemory osuMemory = new();

            Console.WriteLine("Waiting for user to start playing with SD :)");
            while (true)
            {
                int gameStatus = await osuMemory.GetGameStatus();
                int modsEnabled = await osuMemory.GetModsEnabled();
                double hp = await osuMemory.GetHP();

                if (gameStatus == 2 && (modsEnabled & 32) != 0 && hp <= 0.0)
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

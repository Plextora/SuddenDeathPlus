﻿using Memory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuddenDeathPlus
{
    public class OsuMemory
    {
        private readonly Mem memory = new();
        private readonly Signatures signatures = new();
        private readonly Offsets offsets = new();

        public OsuMemory() => memory.OpenProcess("osu!.exe");

        public async Task<int> GetGameStatus() => await GetIntFromSig(signatures.gameStatus, offsets.gameStatus);
        public async Task<int> GetModsEnabled() => await GetIntFromSig(signatures.modsEnabled, offsets.modsEnabled);

        private async Task<int> GetIntFromSig(string sig, int offset) =>
            memory.ReadInt(await GetAddrFromSig(sig, offset));

        private async Task<string> GetAddrFromSig(string sig, int offset)
        {
            IEnumerable<long> aobScan = await memory.AoBScan(sig);
            long result = aobScan.FirstOrDefault();
            string hexPointer = (result + offset).ToString("X");
            return memory.ReadInt(hexPointer).ToString("X");
        }
    }
}

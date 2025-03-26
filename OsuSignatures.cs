// Signatures and offsets grabbed from https://github.com/tosuapp/tosu, developed by cyperdark, KotRikD, and other contributors.

namespace SuddenDeathPlus
{
    class Signatures
    {
        public string gameStatus => "48 83 F8 04 73 1E";
        public string modsEnabled => "C8 FF ?? ?? ?? ?? ?? 81 0D ?? ?? ?? ?? ?? 08 00 00";
    }

    class Offsets
    {
        public uint gameStatus => 0x04;
        public uint modsEnabled => 0x09;
    }
}

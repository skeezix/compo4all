using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class mrdrillr : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused1A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score1A;
            public byte SeperatorA1A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Depth1A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SeperatorB1A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name1A;
            public byte SeperatorC1A;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused2A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score2A;
            public byte SeperatorA2A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Depth2A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SeperatorB2A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name2A;
            public byte SeperatorC2A;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused3A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score3A;
            public byte SeperatorA3A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Depth3A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SeperatorB3A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name3A;
            public byte SeperatorC3A;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused4A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score4A;
            public byte SeperatorA4A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Depth4A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SeperatorB4A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name4A;
            public byte SeperatorC4A;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused5A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score5A;
            public byte SeperatorA5A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Depth5A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SeperatorB5A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name5A;
            public byte SeperatorC5A;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused6A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score6A;
            public byte SeperatorA6A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Depth6A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SeperatorB6A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name6A;
            public byte SeperatorC6A;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused7A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score7A;
            public byte SeperatorA7A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Depth7A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SeperatorB7A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name7A;
            public byte SeperatorC7A;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused8A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score8A;
            public byte SeperatorA8A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Depth8A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SeperatorB8A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name8A;
            public byte SeperatorC8A;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused9A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score9A;
            public byte SeperatorA9A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Depth9A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SeperatorB9A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name9A;
            public byte SeperatorC9A;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused10A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score10A;
            public byte SeperatorA10A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Depth10A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SeperatorB10A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name10A;
            public byte SeperatorC10A;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused11A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score11A;
            public byte SeperatorA11A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Depth11A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SeperatorB11A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name11A;
            public byte SeperatorC11A;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused12A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score12A;
            public byte SeperatorA12A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Depth12A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SeperatorB12A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name12A;
            public byte SeperatorC12A;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused13A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score13A;
            public byte SeperatorA13A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Depth13A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SeperatorB13A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name13A;
            public byte SeperatorC13A;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused14A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score14A;
            public byte SeperatorA14A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Depth14A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SeperatorB14A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name14A;
            public byte SeperatorC14A;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused15A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score15A;
            public byte SeperatorA15A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Depth15A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SeperatorB15A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name15A;
            public byte SeperatorC15A;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused16A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score16A;
            public byte SeperatorA16A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Depth16A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SeperatorB16A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name16A;
            public byte SeperatorC16A;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused17A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score17A;
            public byte SeperatorA17A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Depth17A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SeperatorB17A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name17A;
            public byte SeperatorC17A;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused18A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score18A;
            public byte SeperatorA18A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Depth18A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SeperatorB18A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name18A;
            public byte SeperatorC18A;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused19A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score19A;
            public byte SeperatorA19A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Depth19A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SeperatorB19A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name19A;
            public byte SeperatorC19A;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused20A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score20A;
            public byte SeperatorA20A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Depth20A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SeperatorB20A;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name20A;
            public byte SeperatorC20A;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused1B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score1B;
            public byte SeperatorA1B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Depth1B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SeperatorB1B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name1B;
            public byte SeperatorC1B;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused2B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score2B;
            public byte SeperatorA2B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Depth2B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SeperatorB2B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name2B;
            public byte SeperatorC2B;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused3B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score3B;
            public byte SeperatorA3B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Depth3B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SeperatorB3B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name3B;
            public byte SeperatorC3B;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused4B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score4B;
            public byte SeperatorA4B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Depth4B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SeperatorB4B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name4B;
            public byte SeperatorC4B;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused5B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score5B;
            public byte SeperatorA5B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Depth5B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SeperatorB5B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name5B;
            public byte SeperatorC5B;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused6B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score6B;
            public byte SeperatorA6B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Depth6B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SeperatorB6B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name6B;
            public byte SeperatorC6B;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused7B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score7B;
            public byte SeperatorA7B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Depth7B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SeperatorB7B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name7B;
            public byte SeperatorC7B;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused8B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score8B;
            public byte SeperatorA8B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Depth8B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SeperatorB8B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name8B;
            public byte SeperatorC8B;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused9B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score9B;
            public byte SeperatorA9B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Depth9B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SeperatorB9B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name9B;
            public byte SeperatorC9B;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused10B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score10B;
            public byte SeperatorA10B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Depth10B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SeperatorB10B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name10B;
            public byte SeperatorC10B;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused11B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score11B;
            public byte SeperatorA11B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Depth11B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SeperatorB11B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name11B;
            public byte SeperatorC11B;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused12B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score12B;
            public byte SeperatorA12B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Depth12B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SeperatorB12B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name12B;
            public byte SeperatorC12B;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused13B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score13B;
            public byte SeperatorA13B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Depth13B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SeperatorB13B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name13B;
            public byte SeperatorC13B;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused14B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score14B;
            public byte SeperatorA14B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Depth14B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SeperatorB14B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name14B;
            public byte SeperatorC14B;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused15B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score15B;
            public byte SeperatorA15B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Depth15B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SeperatorB15B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name15B;
            public byte SeperatorC15B;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused16B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score16B;
            public byte SeperatorA16B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Depth16B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SeperatorB16B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name16B;
            public byte SeperatorC16B;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused17B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score17B;
            public byte SeperatorA17B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Depth17B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SeperatorB17B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name17B;
            public byte SeperatorC17B;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused18B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score18B;
            public byte SeperatorA18B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Depth18B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SeperatorB18B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name18B;
            public byte SeperatorC18B;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused19B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score19B;
            public byte SeperatorA19B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Depth19B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SeperatorB19B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name19B;
            public byte SeperatorC19B;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused20B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score20B;
            public byte SeperatorA20B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Depth20B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SeperatorB20B;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name20B;
            public byte SeperatorC20B;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Footer;
        }

        public mrdrillr()
        {
            m_numEntries = 40;
            m_format = "RANK|SCORE|NAME|DEPTH|MODE";
            m_gamesSupported = "mrdrillr";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] >= 0x00 && data[i] <= 0x19)
                    sb.Append(((char)((((int)data[i])) + 65)));
                else if (data[i] == 0x1a)
                    sb.Append('?');
                else if (data[i] == 0x1b)
                    sb.Append('!');
                else if (data[i] == 0x1c)
                    sb.Append('-');
                else if (data[i] == 0x1d)
                    sb.Append('/');
                else if (data[i] == 0x1e)
                    sb.Append('.');
                else if (data[i] == 0x1f)
                    sb.Append('0');
                else if (data[i] == 0x20)
                    sb.Append('1');
                else if (data[i] == 0x21)
                    sb.Append('2');
                else if (data[i] == 0x22)
                    sb.Append('3');
                else if (data[i] == 0x23)
                    sb.Append('4');
                else if (data[i] == 0x24)
                    sb.Append('5');
                else if (data[i] == 0x25)
                    sb.Append('6');
                else if (data[i] == 0x26)
                    sb.Append('7');
                else if (data[i] == 0x27)
                    sb.Append('8');
                else if (data[i] == 0x28)
                    sb.Append('9');
                else if (data[i] == 0x29)
                    sb.Append(' ');
            }

            return sb.ToString();
        }

        public byte[] StringToByteArray(string str)
        {
            byte[] data = new byte[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'A' && str[i] <= 'Z')
                    data[i] = (byte)(((int)str[i] - 65));
                else if (str[i] == '?')
                    data[i] = 0x1a;
                else if (str[i] == '!')
                    data[i] = 0x1b;
                else if (str[i] == '-')
                    data[i] = 0x1c;
                else if (str[i] == '/')
                    data[i] = 0x1d;
                else if (str[i] == '.')
                    data[i] = 0x1e;
                else if (str[i] == '0')
                    data[i] = 0x1f;
                else if (str[i] == '1')
                    data[i] = 0x20;
                else if (str[i] == '2')
                    data[i] = 0x21;
                else if (str[i] == '3')
                    data[i] = 0x22;
                else if (str[i] == '4')
                    data[i] = 0x23;
                else if (str[i] == '5')
                    data[i] = 0x24;
                else if (str[i] == '6')
                    data[i] = 0x25;
                else if (str[i] == '7')
                    data[i] = 0x26;
                else if (str[i] == '8')
                    data[i] = 0x27;
                else if (str[i] == '9')
                    data[i] = 0x28;
                else if (str[i] == ' ')
                    data[i] = 0x29;
            }

            return data;
        }

        private int GetMode(string mode)
        {
            switch (mode)
            {
                case "500m":
                    return 0;
                case "1000m":
                    return 1;
            }
            return -1;
        }

        private int GetDepth(string depth)
        {
            if (depth.IndexOf('m') != -1)
                return System.Convert.ToInt32(depth.Substring(0, depth.Length - 1));

            return -1;
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2];
            int depth = GetDepth(args[3]);
            int mode = GetMode(args[4]);

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            //Depending on the mode, we have to check against different depths. 
            //Mr. Driller uses depth to determine rank.
            int rank = NumEntries / 2;
            switch (mode)
            {
                //500m
                case 0:
                    if (depth > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth1A)))
                        rank = 0;
                    else if (depth > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth2A)))
                        rank = 1;
                    else if (depth > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth3A)))
                        rank = 2;
                    else if (depth > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth4A)))
                        rank = 3;
                    else if (depth > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth5A)))
                        rank = 4;
                    else if (depth > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth6A)))
                        rank = 5;
                    else if (depth > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth7A)))
                        rank = 6;
                    else if (depth > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth8A)))
                        rank = 7;
                    else if (depth > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth9A)))
                        rank = 8;
                    else if (depth > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth10A)))
                        rank = 9;
                    else if (depth > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth11A)))
                        rank = 10;
                    else if (depth > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth12A)))
                        rank = 11;
                    else if (depth > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth13A)))
                        rank = 12;
                    else if (depth > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth14A)))
                        rank = 13;
                    else if (depth > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth15A)))
                        rank = 14;
                    else if (depth > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth16A)))
                        rank = 15;
                    else if (depth > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth17A)))
                        rank = 16;
                    else if (depth > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth18A)))
                        rank = 17;
                    else if (depth > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth19A)))
                        rank = 18;
                    else if (depth > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth20A)))
                        rank = 19;
                    break;
                //1000m.
                case 1:
                    if (depth > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth1B)))
                        rank = 0;
                    else if (depth > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth2B)))
                        rank = 1;
                    else if (depth > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth3B)))
                        rank = 2;
                    else if (depth > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth4B)))
                        rank = 3;
                    else if (depth > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth5B)))
                        rank = 4;
                    else if (depth > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth6B)))
                        rank = 5;
                    else if (depth > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth7B)))
                        rank = 6;
                    else if (depth > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth8B)))
                        rank = 7;
                    else if (depth > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth9B)))
                        rank = 8;
                    else if (depth > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth10B)))
                        rank = 9;
                    else if (depth > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth11B)))
                        rank = 10;
                    else if (depth > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth12B)))
                        rank = 11;
                    else if (depth > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth13B)))
                        rank = 12;
                    else if (depth > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth14B)))
                        rank = 13;
                    else if (depth > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth15B)))
                        rank = 14;
                    else if (depth > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth16B)))
                        rank = 15;
                    else if (depth > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth17B)))
                        rank = 16;
                    else if (depth > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth18B)))
                        rank = 17;
                    else if (depth > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth19B)))
                        rank = 18;
                    else if (depth > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth20B)))
                        rank = 19;
                    break;
                default:
                    //Error.
                    break;
            }
            #endregion

            #region ADJUST
            int adjust = (NumEntries / 2) - 1;
            if (rank < (NumEntries / 2) - 1)
                adjust = (NumEntries / 2) - 2;

            switch (mode)
            {
                //500m.
                case 0:
                    switch (adjust)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(hiscoreData.Score2A, hiscoreData.Score1A);
                            HiConvert.ByteArrayCopy(hiscoreData.Name2A, hiscoreData.Name1A);
                            HiConvert.ByteArrayCopy(hiscoreData.Depth2A, hiscoreData.Depth1A);
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(hiscoreData.Score3A, hiscoreData.Score2A);
                            HiConvert.ByteArrayCopy(hiscoreData.Name3A, hiscoreData.Name2A);
                            HiConvert.ByteArrayCopy(hiscoreData.Depth3A, hiscoreData.Depth2A);
                            if (rank < 1)
                                goto case 0;
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(hiscoreData.Score4A, hiscoreData.Score3A);
                            HiConvert.ByteArrayCopy(hiscoreData.Name4A, hiscoreData.Name3A);
                            HiConvert.ByteArrayCopy(hiscoreData.Depth4A, hiscoreData.Depth3A);
                            if (rank < 2)
                                goto case 1;
                            break;
                        case 3:
                            HiConvert.ByteArrayCopy(hiscoreData.Score5A, hiscoreData.Score4A);
                            HiConvert.ByteArrayCopy(hiscoreData.Name5A, hiscoreData.Name4A);
                            HiConvert.ByteArrayCopy(hiscoreData.Depth5A, hiscoreData.Depth4A);
                            if (rank < 3)
                                goto case 2;
                            break;
                        case 4:
                            HiConvert.ByteArrayCopy(hiscoreData.Score6A, hiscoreData.Score5A);
                            HiConvert.ByteArrayCopy(hiscoreData.Name6A, hiscoreData.Name5A);
                            HiConvert.ByteArrayCopy(hiscoreData.Depth6A, hiscoreData.Depth5A);
                            if (rank < 4)
                                goto case 3;
                            break;
                        case 5:
                            HiConvert.ByteArrayCopy(hiscoreData.Score7A, hiscoreData.Score6A);
                            HiConvert.ByteArrayCopy(hiscoreData.Name7A, hiscoreData.Name6A);
                            HiConvert.ByteArrayCopy(hiscoreData.Depth7A, hiscoreData.Depth6A);
                            if (rank < 5)
                                goto case 4;
                            break;
                        case 6:
                            HiConvert.ByteArrayCopy(hiscoreData.Score8A, hiscoreData.Score7A);
                            HiConvert.ByteArrayCopy(hiscoreData.Name8A, hiscoreData.Name7A);
                            HiConvert.ByteArrayCopy(hiscoreData.Depth8A, hiscoreData.Depth7A);
                            if (rank < 6)
                                goto case 5;
                            break;
                        case 7:
                            HiConvert.ByteArrayCopy(hiscoreData.Score9A, hiscoreData.Score8A);
                            HiConvert.ByteArrayCopy(hiscoreData.Name9A, hiscoreData.Name8A);
                            HiConvert.ByteArrayCopy(hiscoreData.Depth9A, hiscoreData.Depth8A);
                            if (rank < 7)
                                goto case 6;
                            break;
                        case 8:
                            HiConvert.ByteArrayCopy(hiscoreData.Score10A, hiscoreData.Score9A);
                            HiConvert.ByteArrayCopy(hiscoreData.Name10A, hiscoreData.Name9A);
                            HiConvert.ByteArrayCopy(hiscoreData.Depth10A, hiscoreData.Depth9A);
                            if (rank < 8)
                                goto case 7;
                            break;
                        case 9:
                            HiConvert.ByteArrayCopy(hiscoreData.Score11A, hiscoreData.Score10A);
                            HiConvert.ByteArrayCopy(hiscoreData.Name11A, hiscoreData.Name10A);
                            HiConvert.ByteArrayCopy(hiscoreData.Depth11A, hiscoreData.Depth10A);
                            if (rank < 9)
                                goto case 8;
                            break;
                        case 10:
                            HiConvert.ByteArrayCopy(hiscoreData.Score12A, hiscoreData.Score11A);
                            HiConvert.ByteArrayCopy(hiscoreData.Name12A, hiscoreData.Name11A);
                            HiConvert.ByteArrayCopy(hiscoreData.Depth12A, hiscoreData.Depth11A);
                            if (rank < 10)
                                goto case 9;
                            break;
                        case 11:
                            HiConvert.ByteArrayCopy(hiscoreData.Score13A, hiscoreData.Score12A);
                            HiConvert.ByteArrayCopy(hiscoreData.Name13A, hiscoreData.Name12A);
                            HiConvert.ByteArrayCopy(hiscoreData.Depth13A, hiscoreData.Depth12A);
                            if (rank < 11)
                                goto case 10;
                            break;
                        case 12:
                            HiConvert.ByteArrayCopy(hiscoreData.Score14A, hiscoreData.Score13A);
                            HiConvert.ByteArrayCopy(hiscoreData.Name14A, hiscoreData.Name13A);
                            HiConvert.ByteArrayCopy(hiscoreData.Depth14A, hiscoreData.Depth13A);
                            if (rank < 12)
                                goto case 11;
                            break;
                        case 13:
                            HiConvert.ByteArrayCopy(hiscoreData.Score15A, hiscoreData.Score14A);
                            HiConvert.ByteArrayCopy(hiscoreData.Name15A, hiscoreData.Name14A);
                            HiConvert.ByteArrayCopy(hiscoreData.Depth15A, hiscoreData.Depth14A);
                            if (rank < 13)
                                goto case 12;
                            break;
                        case 14:
                            HiConvert.ByteArrayCopy(hiscoreData.Score16A, hiscoreData.Score15A);
                            HiConvert.ByteArrayCopy(hiscoreData.Name16A, hiscoreData.Name15A);
                            HiConvert.ByteArrayCopy(hiscoreData.Depth16A, hiscoreData.Depth15A);
                            if (rank < 14)
                                goto case 13;
                            break;
                        case 15:
                            HiConvert.ByteArrayCopy(hiscoreData.Score17A, hiscoreData.Score16A);
                            HiConvert.ByteArrayCopy(hiscoreData.Name17A, hiscoreData.Name16A);
                            HiConvert.ByteArrayCopy(hiscoreData.Depth17A, hiscoreData.Depth16A);
                            if (rank < 15)
                                goto case 14;
                            break;
                        case 16:
                            HiConvert.ByteArrayCopy(hiscoreData.Score18A, hiscoreData.Score17A);
                            HiConvert.ByteArrayCopy(hiscoreData.Name18A, hiscoreData.Name17A);
                            HiConvert.ByteArrayCopy(hiscoreData.Depth18A, hiscoreData.Depth17A);
                            if (rank < 16)
                                goto case 15;
                            break;
                        case 17:
                            HiConvert.ByteArrayCopy(hiscoreData.Score19A, hiscoreData.Score18A);
                            HiConvert.ByteArrayCopy(hiscoreData.Name19A, hiscoreData.Name18A);
                            HiConvert.ByteArrayCopy(hiscoreData.Depth19A, hiscoreData.Depth18A);
                            if (rank < 17)
                                goto case 16;
                            break;
                        case 18:
                            HiConvert.ByteArrayCopy(hiscoreData.Score20A, hiscoreData.Score19A);
                            HiConvert.ByteArrayCopy(hiscoreData.Name20A, hiscoreData.Name19A);
                            HiConvert.ByteArrayCopy(hiscoreData.Depth20A, hiscoreData.Depth19A);
                            if (rank < 18)
                                goto case 17;
                            break;
                    }
                    break;
                //1000m.
                case 1:
                    switch (adjust)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(hiscoreData.Score2B, hiscoreData.Score1B);
                            HiConvert.ByteArrayCopy(hiscoreData.Name2B, hiscoreData.Name1B);
                            HiConvert.ByteArrayCopy(hiscoreData.Depth2B, hiscoreData.Depth1B);
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(hiscoreData.Score3B, hiscoreData.Score2B);
                            HiConvert.ByteArrayCopy(hiscoreData.Name3B, hiscoreData.Name2B);
                            HiConvert.ByteArrayCopy(hiscoreData.Depth3B, hiscoreData.Depth2B);
                            if (rank < 1)
                                goto case 0;
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(hiscoreData.Score4B, hiscoreData.Score3B);
                            HiConvert.ByteArrayCopy(hiscoreData.Name4B, hiscoreData.Name3B);
                            HiConvert.ByteArrayCopy(hiscoreData.Depth4B, hiscoreData.Depth3B);
                            if (rank < 2)
                                goto case 1;
                            break;
                        case 3:
                            HiConvert.ByteArrayCopy(hiscoreData.Score5B, hiscoreData.Score4B);
                            HiConvert.ByteArrayCopy(hiscoreData.Name5B, hiscoreData.Name4B);
                            HiConvert.ByteArrayCopy(hiscoreData.Depth5B, hiscoreData.Depth4B);
                            if (rank < 3)
                                goto case 2;
                            break;
                        case 4:
                            HiConvert.ByteArrayCopy(hiscoreData.Score6B, hiscoreData.Score5B);
                            HiConvert.ByteArrayCopy(hiscoreData.Name6B, hiscoreData.Name5B);
                            HiConvert.ByteArrayCopy(hiscoreData.Depth6B, hiscoreData.Depth5B);
                            if (rank < 4)
                                goto case 3;
                            break;
                        case 5:
                            HiConvert.ByteArrayCopy(hiscoreData.Score7B, hiscoreData.Score6B);
                            HiConvert.ByteArrayCopy(hiscoreData.Name7B, hiscoreData.Name6B);
                            HiConvert.ByteArrayCopy(hiscoreData.Depth7B, hiscoreData.Depth6B);
                            if (rank < 5)
                                goto case 4;
                            break;
                        case 6:
                            HiConvert.ByteArrayCopy(hiscoreData.Score8B, hiscoreData.Score7B);
                            HiConvert.ByteArrayCopy(hiscoreData.Name8B, hiscoreData.Name7B);
                            HiConvert.ByteArrayCopy(hiscoreData.Depth8B, hiscoreData.Depth7B);
                            if (rank < 6)
                                goto case 5;
                            break;
                        case 7:
                            HiConvert.ByteArrayCopy(hiscoreData.Score9B, hiscoreData.Score8B);
                            HiConvert.ByteArrayCopy(hiscoreData.Name9B, hiscoreData.Name8B);
                            HiConvert.ByteArrayCopy(hiscoreData.Depth9B, hiscoreData.Depth8B);
                            if (rank < 7)
                                goto case 6;
                            break;
                        case 8:
                            HiConvert.ByteArrayCopy(hiscoreData.Score10B, hiscoreData.Score9B);
                            HiConvert.ByteArrayCopy(hiscoreData.Name10B, hiscoreData.Name9B);
                            HiConvert.ByteArrayCopy(hiscoreData.Depth10B, hiscoreData.Depth9B);
                            if (rank < 8)
                                goto case 7;
                            break;
                        case 9:
                            HiConvert.ByteArrayCopy(hiscoreData.Score11B, hiscoreData.Score10B);
                            HiConvert.ByteArrayCopy(hiscoreData.Name11B, hiscoreData.Name10B);
                            HiConvert.ByteArrayCopy(hiscoreData.Depth11B, hiscoreData.Depth10B);
                            if (rank < 9)
                                goto case 8;
                            break;
                        case 10:
                            HiConvert.ByteArrayCopy(hiscoreData.Score12B, hiscoreData.Score11B);
                            HiConvert.ByteArrayCopy(hiscoreData.Name12B, hiscoreData.Name11B);
                            HiConvert.ByteArrayCopy(hiscoreData.Depth12B, hiscoreData.Depth11B);
                            if (rank < 10)
                                goto case 9;
                            break;
                        case 11:
                            HiConvert.ByteArrayCopy(hiscoreData.Score13B, hiscoreData.Score12B);
                            HiConvert.ByteArrayCopy(hiscoreData.Name13B, hiscoreData.Name12B);
                            HiConvert.ByteArrayCopy(hiscoreData.Depth13B, hiscoreData.Depth12B);
                            if (rank < 11)
                                goto case 10;
                            break;
                        case 12:
                            HiConvert.ByteArrayCopy(hiscoreData.Score14B, hiscoreData.Score13B);
                            HiConvert.ByteArrayCopy(hiscoreData.Name14B, hiscoreData.Name13B);
                            HiConvert.ByteArrayCopy(hiscoreData.Depth14B, hiscoreData.Depth13B);
                            if (rank < 12)
                                goto case 11;
                            break;
                        case 13:
                            HiConvert.ByteArrayCopy(hiscoreData.Score15B, hiscoreData.Score14B);
                            HiConvert.ByteArrayCopy(hiscoreData.Name15B, hiscoreData.Name14B);
                            HiConvert.ByteArrayCopy(hiscoreData.Depth15B, hiscoreData.Depth14B);
                            if (rank < 13)
                                goto case 12;
                            break;
                        case 14:
                            HiConvert.ByteArrayCopy(hiscoreData.Score16B, hiscoreData.Score15B);
                            HiConvert.ByteArrayCopy(hiscoreData.Name16B, hiscoreData.Name15B);
                            HiConvert.ByteArrayCopy(hiscoreData.Depth16B, hiscoreData.Depth15B);
                            if (rank < 14)
                                goto case 13;
                            break;
                        case 15:
                            HiConvert.ByteArrayCopy(hiscoreData.Score17B, hiscoreData.Score16B);
                            HiConvert.ByteArrayCopy(hiscoreData.Name17B, hiscoreData.Name16B);
                            HiConvert.ByteArrayCopy(hiscoreData.Depth17B, hiscoreData.Depth16B);
                            if (rank < 15)
                                goto case 14;
                            break;
                        case 16:
                            HiConvert.ByteArrayCopy(hiscoreData.Score18B, hiscoreData.Score17B);
                            HiConvert.ByteArrayCopy(hiscoreData.Name18B, hiscoreData.Name17B);
                            HiConvert.ByteArrayCopy(hiscoreData.Depth18B, hiscoreData.Depth17B);
                            if (rank < 16)
                                goto case 15;
                            break;
                        case 17:
                            HiConvert.ByteArrayCopy(hiscoreData.Score19B, hiscoreData.Score18B);
                            HiConvert.ByteArrayCopy(hiscoreData.Name19B, hiscoreData.Name18B);
                            HiConvert.ByteArrayCopy(hiscoreData.Depth19B, hiscoreData.Depth18B);
                            if (rank < 17)
                                goto case 16;
                            break;
                        case 18:
                            HiConvert.ByteArrayCopy(hiscoreData.Score20B, hiscoreData.Score19B);
                            HiConvert.ByteArrayCopy(hiscoreData.Name20B, hiscoreData.Name19B);
                            HiConvert.ByteArrayCopy(hiscoreData.Depth20B, hiscoreData.Depth19B);
                            if (rank < 18)
                                goto case 17;
                            break;
                    }
                    break;
                default:
                    //Error.
                    break;
            }
            #endregion

            #region REPLACE_NEW
            switch (mode)
            {
                //500m.
                case 0:
                    switch (rank)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(hiscoreData.Name1A, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.Score1A, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score1A.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.Depth1A, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(depth, hiscoreData.Depth1A.Length)));
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(hiscoreData.Name2A, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.Score2A, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score2A.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.Depth2A, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(depth, hiscoreData.Depth2A.Length)));
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(hiscoreData.Name3A, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.Score3A, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score3A.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.Depth3A, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(depth, hiscoreData.Depth3A.Length)));
                            break;
                        case 3:
                            HiConvert.ByteArrayCopy(hiscoreData.Name4A, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.Score4A, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score4A.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.Depth4A, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(depth, hiscoreData.Depth4A.Length)));
                            break;
                        case 4:
                            HiConvert.ByteArrayCopy(hiscoreData.Name5A, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.Score5A, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score5A.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.Depth5A, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(depth, hiscoreData.Depth5A.Length)));
                            break;
                        case 5:
                            HiConvert.ByteArrayCopy(hiscoreData.Name6A, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.Score6A, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score6A.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.Depth6A, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(depth, hiscoreData.Depth6A.Length)));
                            break;
                        case 6:
                            HiConvert.ByteArrayCopy(hiscoreData.Name7A, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.Score7A, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score7A.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.Depth7A, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(depth, hiscoreData.Depth7A.Length)));
                            break;
                        case 7:
                            HiConvert.ByteArrayCopy(hiscoreData.Name8A, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.Score8A, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score8A.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.Depth8A, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(depth, hiscoreData.Depth8A.Length)));
                            break;
                        case 8:
                            HiConvert.ByteArrayCopy(hiscoreData.Name9A, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.Score9A, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score9A.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.Depth9A, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(depth, hiscoreData.Depth9A.Length)));
                            break;
                        case 9:
                            HiConvert.ByteArrayCopy(hiscoreData.Name10A, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.Score10A, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score10A.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.Depth10A, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(depth, hiscoreData.Depth10A.Length)));
                            break;
                        case 10:
                            HiConvert.ByteArrayCopy(hiscoreData.Name11A, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.Score11A, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score11A.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.Depth11A, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(depth, hiscoreData.Depth11A.Length)));
                            break;
                        case 11:
                            HiConvert.ByteArrayCopy(hiscoreData.Name12A, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.Score12A, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score12A.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.Depth12A, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(depth, hiscoreData.Depth12A.Length)));
                            break;
                        case 12:
                            HiConvert.ByteArrayCopy(hiscoreData.Name13A, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.Score13A, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score13A.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.Depth13A, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(depth, hiscoreData.Depth13A.Length)));
                            break;
                        case 13:
                            HiConvert.ByteArrayCopy(hiscoreData.Name14A, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.Score14A, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score14A.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.Depth14A, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(depth, hiscoreData.Depth14A.Length)));
                            break;
                        case 14:
                            HiConvert.ByteArrayCopy(hiscoreData.Name15A, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.Score15A, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score15A.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.Depth15A, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(depth, hiscoreData.Depth15A.Length)));
                            break;
                        case 15:
                            HiConvert.ByteArrayCopy(hiscoreData.Name16A, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.Score16A, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score16A.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.Depth16A, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(depth, hiscoreData.Depth16A.Length)));
                            break;
                        case 16:
                            HiConvert.ByteArrayCopy(hiscoreData.Name17A, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.Score17A, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score17A.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.Depth17A, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(depth, hiscoreData.Depth17A.Length)));
                            break;
                        case 17:
                            HiConvert.ByteArrayCopy(hiscoreData.Name18A, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.Score18A, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score18A.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.Depth18A, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(depth, hiscoreData.Depth18A.Length)));
                            break;
                        case 18:
                            HiConvert.ByteArrayCopy(hiscoreData.Name19A, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.Score19A, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score19A.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.Depth19A, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(depth, hiscoreData.Depth19A.Length)));
                            break;
                        case 19:
                            HiConvert.ByteArrayCopy(hiscoreData.Name20A, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.Score20A, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score20A.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.Depth20A, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(depth, hiscoreData.Depth20A.Length)));
                            break;
                    }
                    break;
                //1000m.
                case 1:
                    switch (rank)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(hiscoreData.Name1B, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.Score1B, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score1B.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.Depth1B, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(depth, hiscoreData.Depth1B.Length)));
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(hiscoreData.Name2B, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.Score2B, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score2B.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.Depth2B, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(depth, hiscoreData.Depth2B.Length)));
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(hiscoreData.Name3B, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.Score3B, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score3B.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.Depth3B, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(depth, hiscoreData.Depth3B.Length)));
                            break;
                        case 3:
                            HiConvert.ByteArrayCopy(hiscoreData.Name4B, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.Score4B, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score4B.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.Depth4B, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(depth, hiscoreData.Depth4B.Length)));
                            break;
                        case 4:
                            HiConvert.ByteArrayCopy(hiscoreData.Name5B, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.Score5B, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score5B.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.Depth5B, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(depth, hiscoreData.Depth5B.Length)));
                            break;
                        case 5:
                            HiConvert.ByteArrayCopy(hiscoreData.Name6B, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.Score6B, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score6B.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.Depth6B, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(depth, hiscoreData.Depth6B.Length)));
                            break;
                        case 6:
                            HiConvert.ByteArrayCopy(hiscoreData.Name7B, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.Score7B, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score7B.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.Depth7B, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(depth, hiscoreData.Depth7B.Length)));
                            break;
                        case 7:
                            HiConvert.ByteArrayCopy(hiscoreData.Name8B, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.Score8B, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score8B.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.Depth8B, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(depth, hiscoreData.Depth8B.Length)));
                            break;
                        case 8:
                            HiConvert.ByteArrayCopy(hiscoreData.Name9B, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.Score9B, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score9B.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.Depth9B, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(depth, hiscoreData.Depth9B.Length)));
                            break;
                        case 9:
                            HiConvert.ByteArrayCopy(hiscoreData.Name10B, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.Score10B, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score10B.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.Depth10B, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(depth, hiscoreData.Depth10B.Length)));
                            break;
                        case 10:
                            HiConvert.ByteArrayCopy(hiscoreData.Name11B, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.Score11B, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score11B.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.Depth11B, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(depth, hiscoreData.Depth11B.Length)));
                            break;
                        case 11:
                            HiConvert.ByteArrayCopy(hiscoreData.Name12B, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.Score12B, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score12B.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.Depth12B, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(depth, hiscoreData.Depth12B.Length)));
                            break;
                        case 12:
                            HiConvert.ByteArrayCopy(hiscoreData.Name13B, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.Score13B, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score13B.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.Depth13B, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(depth, hiscoreData.Depth13B.Length)));
                            break;
                        case 13:
                            HiConvert.ByteArrayCopy(hiscoreData.Name14B, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.Score14B, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score14B.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.Depth14B, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(depth, hiscoreData.Depth14B.Length)));
                            break;
                        case 14:
                            HiConvert.ByteArrayCopy(hiscoreData.Name15B, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.Score15B, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score15B.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.Depth15B, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(depth, hiscoreData.Depth15B.Length)));
                            break;
                        case 15:
                            HiConvert.ByteArrayCopy(hiscoreData.Name16B, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.Score16B, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score16B.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.Depth16B, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(depth, hiscoreData.Depth16B.Length)));
                            break;
                        case 16:
                            HiConvert.ByteArrayCopy(hiscoreData.Name17B, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.Score17B, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score17B.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.Depth17B, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(depth, hiscoreData.Depth17B.Length)));
                            break;
                        case 17:
                            HiConvert.ByteArrayCopy(hiscoreData.Name18B, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.Score18B, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score18B.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.Depth18B, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(depth, hiscoreData.Depth18B.Length)));
                            break;
                        case 18:
                            HiConvert.ByteArrayCopy(hiscoreData.Name19B, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.Score19B, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score19B.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.Depth19B, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(depth, hiscoreData.Depth19B.Length)));
                            break;
                        case 19:
                            HiConvert.ByteArrayCopy(hiscoreData.Name20B, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.Score20B, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score20B.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.Depth20B, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(depth, hiscoreData.Depth20B.Length)));
                            break;
                    }
                    break;
                default:
                    //Error.
                    break;
            }
            #endregion

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.Depth1A, HiConvert.IntToByteArrayHex(0, hiscoreData.Depth1A.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Depth2A, HiConvert.IntToByteArrayHex(0, hiscoreData.Depth2A.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Depth3A, HiConvert.IntToByteArrayHex(0, hiscoreData.Depth3A.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Depth4A, HiConvert.IntToByteArrayHex(0, hiscoreData.Depth4A.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Depth5A, HiConvert.IntToByteArrayHex(0, hiscoreData.Depth5A.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Depth6A, HiConvert.IntToByteArrayHex(0, hiscoreData.Depth6A.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Depth7A, HiConvert.IntToByteArrayHex(0, hiscoreData.Depth7A.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Depth8A, HiConvert.IntToByteArrayHex(0, hiscoreData.Depth8A.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Depth9A, HiConvert.IntToByteArrayHex(0, hiscoreData.Depth9A.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Depth10A, HiConvert.IntToByteArrayHex(0, hiscoreData.Depth10A.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Depth11A, HiConvert.IntToByteArrayHex(0, hiscoreData.Depth11A.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Depth12A, HiConvert.IntToByteArrayHex(0, hiscoreData.Depth12A.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Depth13A, HiConvert.IntToByteArrayHex(0, hiscoreData.Depth13A.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Depth14A, HiConvert.IntToByteArrayHex(0, hiscoreData.Depth14A.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Depth15A, HiConvert.IntToByteArrayHex(0, hiscoreData.Depth15A.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Depth16A, HiConvert.IntToByteArrayHex(0, hiscoreData.Depth16A.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Depth17A, HiConvert.IntToByteArrayHex(0, hiscoreData.Depth17A.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Depth18A, HiConvert.IntToByteArrayHex(0, hiscoreData.Depth18A.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Depth19A, HiConvert.IntToByteArrayHex(0, hiscoreData.Depth19A.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Depth20A, HiConvert.IntToByteArrayHex(0, hiscoreData.Depth20A.Length));

            HiConvert.ByteArrayCopy(hiscoreData.Depth1B, HiConvert.IntToByteArrayHex(0, hiscoreData.Depth1B.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Depth2B, HiConvert.IntToByteArrayHex(0, hiscoreData.Depth2B.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Depth3B, HiConvert.IntToByteArrayHex(0, hiscoreData.Depth3B.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Depth4B, HiConvert.IntToByteArrayHex(0, hiscoreData.Depth4B.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Depth5B, HiConvert.IntToByteArrayHex(0, hiscoreData.Depth5B.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Depth6B, HiConvert.IntToByteArrayHex(0, hiscoreData.Depth6B.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Depth7B, HiConvert.IntToByteArrayHex(0, hiscoreData.Depth7B.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Depth8B, HiConvert.IntToByteArrayHex(0, hiscoreData.Depth8B.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Depth9B, HiConvert.IntToByteArrayHex(0, hiscoreData.Depth9B.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Depth10B, HiConvert.IntToByteArrayHex(0, hiscoreData.Depth10B.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Depth11B, HiConvert.IntToByteArrayHex(0, hiscoreData.Depth11B.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Depth12B, HiConvert.IntToByteArrayHex(0, hiscoreData.Depth12B.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Depth13B, HiConvert.IntToByteArrayHex(0, hiscoreData.Depth13B.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Depth14B, HiConvert.IntToByteArrayHex(0, hiscoreData.Depth14B.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Depth15B, HiConvert.IntToByteArrayHex(0, hiscoreData.Depth15B.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Depth16B, HiConvert.IntToByteArrayHex(0, hiscoreData.Depth16B.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Depth17B, HiConvert.IntToByteArrayHex(0, hiscoreData.Depth17B.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Depth18B, HiConvert.IntToByteArrayHex(0, hiscoreData.Depth18B.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Depth19B, HiConvert.IntToByteArrayHex(0, hiscoreData.Depth19B.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Depth20B, HiConvert.IntToByteArrayHex(0, hiscoreData.Depth20B.Length));

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 
                1, 
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score1A)), 
                ByteArrayToString(hiscoreData.Name1A),
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth1A)) + "m", 
                "500m") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}",
                2,
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score2A)),
                ByteArrayToString(hiscoreData.Name2A),
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth2A)) + "m",
                "500m") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}",
                3,
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score3A)),
                ByteArrayToString(hiscoreData.Name3A),
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth3A)) + "m",
                "500m") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}",
                4,
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score4A)),
                ByteArrayToString(hiscoreData.Name4A),
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth4A)) + "m",
                "500m") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}",
                5,
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score5A)),
                ByteArrayToString(hiscoreData.Name5A),
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth5A)) + "m",
                "500m") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}",
                6,
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score6A)),
                ByteArrayToString(hiscoreData.Name6A),
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth6A)) + "m",
                "500m") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}",
                7,
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score7A)),
                ByteArrayToString(hiscoreData.Name7A),
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth7A)) + "m",
                "500m") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}",
                8,
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score8A)),
                ByteArrayToString(hiscoreData.Name8A),
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth8A)) + "m",
                "500m") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}",
                9,
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score9A)),
                ByteArrayToString(hiscoreData.Name9A),
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth9A)) + "m",
                "500m") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}",
                10,
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score10A)),
                ByteArrayToString(hiscoreData.Name10A),
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth10A)) + "m",
                "500m") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}",
                11,
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score11A)),
                ByteArrayToString(hiscoreData.Name11A),
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth11A)) + "m",
                "500m") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}",
                12,
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score12A)),
                ByteArrayToString(hiscoreData.Name12A),
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth12A)) + "m",
                "500m") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}",
                13,
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score13A)),
                ByteArrayToString(hiscoreData.Name13A),
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth13A)) + "m",
                "500m") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}",
                14,
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score14A)),
                ByteArrayToString(hiscoreData.Name14A),
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth14A)) + "m",
                "500m") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}",
                15,
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score15A)),
                ByteArrayToString(hiscoreData.Name15A),
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth15A)) + "m",
                "500m") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}",
                16,
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score16A)),
                ByteArrayToString(hiscoreData.Name16A),
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth16A)) + "m",
                "500m") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}",
                17,
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score17A)),
                ByteArrayToString(hiscoreData.Name17A),
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth17A)) + "m",
                "500m") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}",
                18,
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score18A)),
                ByteArrayToString(hiscoreData.Name18A),
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth18A)) + "m",
                "500m") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}",
                19,
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score19A)),
                ByteArrayToString(hiscoreData.Name19A),
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth19A)) + "m",
                "500m") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}",
                20,
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score20A)),
                ByteArrayToString(hiscoreData.Name20A),
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth20A)) + "m",
                "500m") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}",
                1,
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score1B)),
                ByteArrayToString(hiscoreData.Name1B),
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth1B)) + "m",
                "1000m") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}",
                2,
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score2B)),
                ByteArrayToString(hiscoreData.Name2B),
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth2B)) + "m",
                "1000m") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}",
                3,
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score3B)),
                ByteArrayToString(hiscoreData.Name3B),
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth3B)) + "m",
                "1000m") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}",
                4,
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score4B)),
                ByteArrayToString(hiscoreData.Name4B),
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth4B)) + "m",
                "1000m") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}",
                5,
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score5B)),
                ByteArrayToString(hiscoreData.Name5B),
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth5B)) + "m",
                "1000m") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}",
                6,
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score6B)),
                ByteArrayToString(hiscoreData.Name6B),
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth6B)) + "m",
                "1000m") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}",
                7,
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score7B)),
                ByteArrayToString(hiscoreData.Name7B),
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth7B)) + "m",
                "1000m") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}",
                8,
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score8B)),
                ByteArrayToString(hiscoreData.Name8B),
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth8B)) + "m",
                "1000m") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}",
                9,
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score9B)),
                ByteArrayToString(hiscoreData.Name9B),
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth9B)) + "m",
                "1000m") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}",
                10,
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score10B)),
                ByteArrayToString(hiscoreData.Name10B),
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth10B)) + "m",
                "1000m") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}",
                11,
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score11B)),
                ByteArrayToString(hiscoreData.Name11B),
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth11B)) + "m",
                "1000m") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}",
                12,
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score12B)),
                ByteArrayToString(hiscoreData.Name12B),
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth12B)) + "m",
                "1000m") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}",
                13,
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score13B)),
                ByteArrayToString(hiscoreData.Name13B),
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth13B)) + "m",
                "1000m") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}",
                14,
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score14B)),
                ByteArrayToString(hiscoreData.Name14B),
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth14B)) + "m",
                "1000m") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}",
                15,
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score15B)),
                ByteArrayToString(hiscoreData.Name15B),
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth15B)) + "m",
                "1000m") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}",
                16,
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score16B)),
                ByteArrayToString(hiscoreData.Name16B),
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth16B)) + "m",
                "1000m") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}",
                17,
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score17B)),
                ByteArrayToString(hiscoreData.Name17B),
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth17B)) + "m",
                "1000m") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}",
                18,
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score18B)),
                ByteArrayToString(hiscoreData.Name18B),
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth18B)) + "m",
                "1000m") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}",
                19,
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score19B)),
                ByteArrayToString(hiscoreData.Name19B),
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth19B)) + "m",
                "1000m") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}",
                20,
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score20B)),
                ByteArrayToString(hiscoreData.Name20B),
                HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Depth20B)) + "m",
                "1000m") + Environment.NewLine;
            
            return retString;
        }

        public override String[] OptimizeScoresForGame(String[] webScores)
        {
            List<String[]> _500m = new List<String[]>();
            List<String[]> _1000m = new List<String[]>();

            for (int i = 0; i < webScores.Length; i++)
            {
                String[] webScore = webScores[i].Split(new char[] { '|' });
                switch (webScore[4].ToUpper())
                {
                    case "500M":
                        _500m.Add(webScore);
                        break;
                    case "1000M":
                        _1000m.Add(webScore);
                        break;
                }
            }

            _500m.Sort(new DrillerComparator());
            _1000m.Sort(new DrillerComparator());
            
            String[] toReturn = new String[NumEntries];

            for (int i = 0; i < NumEntries; i++)
            {
                switch (i / 20)
                {
                    case 0:
                        toReturn[i] = String.Join("|", _500m[i % 20]);
                        break;
                    case 1:
                        toReturn[i] = String.Join("|", _1000m[i % 20]);
                        break;
                }
            }
            return toReturn;
        }
    }

    class DrillerComparator : IComparer<String[]>
    {

        #region IComparer<string[]> Members

        int IComparer<string[]>.Compare(string[] x, string[] y)
        {
            //Depth.
            return Convert.ToInt32(y[3]).CompareTo(Convert.ToInt32(x[3]));
        }

        #endregion
    }
}
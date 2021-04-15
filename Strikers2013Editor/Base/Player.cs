using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strikers2013Editor.Base
{
    struct Player
    {
        public byte[] stats;
        // 0  -> TP
        // 1  -> Max TP
        // 2  -> Kick
        // 3  -> Max Kick
        // 4  -> Catch
        // 5  -> Max Catch
        // 6  -> Body
        // 7  -> Max Body
        // 8  -> Guard
        // 9  -> Max Guard
        // 10 -> Control
        // 11 -> Max Control
        // 12 -> Speed
        // 13 -> Max Speed

        public short[] waza;
        // 0  -> LV1
        // 1  -> LV2
        // 2  -> LV3
        // 3  -> undef
        // 4  -> SP
        // 5  -> undef
        // 6  -> undef
        // 7  -> undef
        // 8  -> Dribble
        // 9  -> undef
        // 10 -> undef
        // 11 -> undef
        // 12 -> Defense
        // 13 -> Catch 1
        // 14 -> Catch 2
        // 15 -> undef
        // 16 -> Catch 3

    }
}

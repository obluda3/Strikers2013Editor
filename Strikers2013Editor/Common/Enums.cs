using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strikers2013Editor.Common
{
    public enum Element
    {
        Wind,
        Wood,
        Fire,
        Earth,
        Void,
        unk1,
        unk2,
        unk3
    }
    public enum Position
    {
        GK,
        DF = 0x23,
        MF,
        FW
    }
    public enum TacticalAction 
    {
        Feint = 0x14,
        Roll,
        Short,
        Jump,
        White_Sprint,
        Red_Sprint,
        Loop
    }
    public enum Gender
    {
        Male,
        Female,
        Other
    }
    public enum Bodytype
    {
        Man,
        Large,
        Chibi,
        Muscle,
        Girl1,
        Girl2
    }
    public enum Tier
    {
        Lv1,
        Lv2,
        Lv3,
        SP
    }
    public enum Status
    {
        Normal,
        Long,
        Block,
        Chain,
        Punch1,
        Punch2
    }

    public enum PowerUpIndicator
    {
        Normal,
        Keshin,
        Armed,
        Unused,
        Miximax
    }
}

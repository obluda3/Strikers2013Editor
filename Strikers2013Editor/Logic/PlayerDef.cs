using System.Drawing;
using System.Text;
using Strikers2013Editor.IO;
using Strikers2013Editor.Common;

namespace Strikers2013Editor.Logic
{
    struct PlayerDef
    {
        public int ID;
        public int MatchIndex; // Replaced in game
        public int HiddenName;
        public int ShortName;
        public int FullName;
        public string Name;
        public Gender Gender;
        public int IdleAnimation;
        public int Unk_34;
        public int Description;
        public Bodytype Bodytype;
        public int Scale;
        public int ShadowSize;
        public TacticalAction TacticalAction;
        public int CourseAnimation;
        public int Team;
        public int Emblem;
        public int TeamPortrait;
        public int Position;
        public int MatchFaceModel;
        public int Facemodel;
        public int Facemodel2;
        public int Bodymodel; // Replaced in game
        public int Bodymodel2; // Replaced in game
        public int Unk_74;
        public int Portrait;
        public int Unk_7C;
        public int LeftPortrait;
        public int RightPortrait;
        public string[] Equip;
        public byte[] Unk_B8;
        public Color SkinColor1;
        public Color SkinColor2;
        public int Unk_F0;
        public Element Element;
        public int ChargeProfile;
        public int Unk_FC;
        public int Unk_100;
        public int Voice;
        public int VoiceAlias;
        public int Unk_10C;
        public short Price;
        public short ListPosition;
        public int TeamListPosition;
        public int Unk25;
        public byte[] Pad2;

        public PlayerDef(BeBinaryReader br)
        {
            ID = br.ReadInt32();
            MatchIndex = br.ReadInt32();
            HiddenName = br.ReadInt32();
            ShortName = br.ReadInt32();
            FullName = br.ReadInt32();
            Name = Encoding.ASCII.GetString(br.ReadBytes(24));
            Gender = (Gender)br.ReadInt32();
            IdleAnimation = br.ReadInt32();
            Unk_34 = br.ReadInt32();
            Description = br.ReadInt32();
            Bodytype = (Bodytype)br.ReadInt32();
            Scale = br.ReadInt32();
            ShadowSize = br.ReadInt32();
            TacticalAction = (TacticalAction)br.ReadInt32();
            CourseAnimation = br.ReadInt32();
            Team = br.ReadInt32();
            Emblem = br.ReadInt32();
            TeamPortrait = br.ReadInt32();
            Position = br.ReadInt32();
            MatchFaceModel = br.ReadInt32();
            Facemodel = br.ReadInt32();
            Facemodel2 = br.ReadInt32();
            Bodymodel = br.ReadInt32();
            Bodymodel2 = br.ReadInt32();
            Unk_74 = br.ReadInt32();
            Portrait = br.ReadInt32();
            Unk_7C = br.ReadInt32();
            LeftPortrait = br.ReadInt32();
            RightPortrait = br.ReadInt32();
            Equip = new string[2];
            Equip[0] = Encoding.ASCII.GetString(br.ReadBytes(24));
            Equip[1] = Encoding.ASCII.GetString(br.ReadBytes(24));
            Unk_B8 = br.ReadBytes(48);
            SkinColor1 = Color.FromArgb(br.ReadInt32());
            SkinColor2 = Color.FromArgb(br.ReadInt32());
            Unk_F0 = br.ReadInt32();
            Element = (Element)br.ReadInt32();
            ChargeProfile = br.ReadInt32();
            Unk_FC = br.ReadInt32();
            Unk_100 = br.ReadInt32();
            Voice = br.ReadInt32();
            VoiceAlias = br.ReadInt32();
            Unk_10C = br.ReadInt32();
            Price = br.ReadInt16();
            ListPosition = br.ReadInt16();
            TeamListPosition = br.ReadInt32();
            Unk25 = br.ReadInt32();
            Pad2 = br.ReadBytes(44);
        }

        public void Write(BeBinaryWriter bw)
        {
            bw.Write(ID);
            bw.Write(MatchIndex);
            bw.Write(HiddenName);
            bw.Write(ShortName);
            bw.Write(FullName);
            var name = Encoding.ASCII.GetBytes(Name);
            bw.Write(name);
            bw.PadWith(0, 0x18 - name.Length);
            bw.Write((int)Gender);
            bw.Write(IdleAnimation);
            bw.Write(Unk_34);
            bw.Write(Description);
            bw.Write((int)Bodytype);
            bw.Write(Scale);
            bw.Write(ShadowSize);
            bw.Write((int)TacticalAction);
            bw.Write(CourseAnimation);
            bw.Write(Team);
            bw.Write(Emblem);
            bw.Write(TeamPortrait);
            bw.Write(Position);
            bw.Write(MatchFaceModel);
            bw.Write(Facemodel);
            bw.Write(Facemodel2);
            bw.Write(Bodymodel);
            bw.Write(Bodymodel2);
            bw.Write(Unk_74);
            bw.Write(Portrait);
            bw.Write(Unk_7C);
            bw.Write(LeftPortrait);
            bw.Write(RightPortrait);
            var equip1 = Encoding.ASCII.GetBytes(Equip[0]);
            bw.Write(equip1);
            bw.PadWith(0, 0x18 - equip1.Length);
            var equip2 = Encoding.ASCII.GetBytes(Equip[1]);
            bw.Write(equip2);
            bw.PadWith(0, 0x18 - equip2.Length);
            bw.Write(Unk_B8);
            bw.Write(SkinColor1.ToArgb());
            bw.Write(SkinColor2.ToArgb());
            bw.Write(Unk_F0);
            bw.Write((int)Element);
            bw.Write(ChargeProfile);
            bw.Write(Unk_FC);
            bw.Write(Unk_100);
            bw.Write(Voice);
            bw.Write(VoiceAlias);
            bw.Write(Unk_10C);
            bw.Write(Price);
            bw.Write(ListPosition);
            bw.Write(TeamListPosition);
            bw.Write(Unk25);
            bw.Write(Pad2);
        }
    }
}

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
        public int Unk1;
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
        public int Unk11;
        public int Portrait;
        public int Unk12;
        public int LeftPortrait;
        public int RightPortrait;
        public byte[] Equip; // idk what it is for
        public Color SkinColor1;
        public Color SkinColor2;
        public int Unk15;
        public Element Element;
        public int ChargeProfile;
        public int Unk17;
        public int Unk18;
        public int Voice;
        public int ArmedAttribution;
        public int Unk21;
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
            Unk1 = br.ReadInt32();
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
            Unk11 = br.ReadInt32();
            Portrait = br.ReadInt32();
            Unk12 = br.ReadInt32();
            LeftPortrait = br.ReadInt32();
            RightPortrait = br.ReadInt32();
            Equip = br.ReadBytes(12 * 8);
            SkinColor1 = Color.FromArgb(br.ReadInt32());
            SkinColor2 = Color.FromArgb(br.ReadInt32());
            Unk15 = br.ReadInt32();
            Element = (Element)br.ReadInt32();
            ChargeProfile = br.ReadInt32();
            Unk17 = br.ReadInt32();
            Unk18 = br.ReadInt32();
            Voice = br.ReadInt32();
            ArmedAttribution = br.ReadInt32();
            Unk21 = br.ReadInt32();
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
            bw.Write(Encoding.ASCII.GetBytes(Name));
            bw.Write((int)Gender);
            bw.Write(IdleAnimation);
            bw.Write(Unk1);
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
            bw.Write(Unk11);
            bw.Write(Portrait);
            bw.Write(Unk12);
            bw.Write(LeftPortrait);
            bw.Write(RightPortrait);
            bw.Write(Equip);
            bw.Write(SkinColor1.ToArgb());
            bw.Write(SkinColor2.ToArgb());
            bw.Write(Unk15);
            bw.Write((int)Element);
            bw.Write(ChargeProfile);
            bw.Write(Unk17);
            bw.Write(Unk18);
            bw.Write(Voice);
            bw.Write(ArmedAttribution);
            bw.Write(Unk21);
            bw.Write(Price);
            bw.Write(ListPosition);
            bw.Write(TeamListPosition);
            bw.Write(Unk25);
            bw.Write(Pad2);
        }
    }
}

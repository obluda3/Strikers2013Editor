using Strikers2013Editor.IO;
using Strikers2013Editor.Common;

namespace Strikers2013Editor.Logic
{
    internal class MoveInfo
    {
        public Movetype MoveType;
        public int UnusedName;
        public int Name;
        public int SortingName;
        public int NameCopy;
        public int FileInfoIndex;
        public int SkipStart;
        public int SkipEnd;
        public int Unk_20;
        public int Unk_24;
        public int Unk_28;
        public int BallEffect;
        public int BallTailEffect;
        public int FieldEffect;
        public int FieldEffect2;
        public int SceneEffect;
        public int SceneEffect2;
        public int PreviewImage;
        public int Stadium;
        public short UserUniform;
        public short OpponentUniform;
        public short User;
        public short Opponent1;
        public short Opponent2;
        public short Opponent3;
        int Sfx;
        public MoveInfo(BeBinaryReader br)
        {
            var baseOffset = br.BaseStream.Position;
            MoveType = (Movetype)br.ReadInt32();
            UnusedName = br.ReadInt32();
            Name = br.ReadInt32();
            SortingName = br.ReadInt32();
            NameCopy = br.ReadInt32();
            FileInfoIndex = br.ReadInt32();
            SkipStart = br.ReadInt32();
            SkipEnd = br.ReadInt32();
            Unk_20 = br.ReadInt32();
            Unk_24 = br.ReadInt32();
            Unk_28 = br.ReadInt32();
            BallEffect = br.ReadInt32();
            BallTailEffect = br.ReadInt32();
            FieldEffect = br.ReadInt32();
            FieldEffect2 = br.ReadInt32();
            SceneEffect = br.ReadInt32();
            SceneEffect2 = br.ReadInt32();
            PreviewImage = br.ReadInt32();
            Stadium = br.ReadInt32();
            UserUniform = br.ReadInt16();
            br.ReadBytes(2);
            OpponentUniform = br.ReadInt16();
            br.ReadBytes(2);
            User = br.ReadInt16();
            Opponent1 = br.ReadInt16();
            Opponent2 = br.ReadInt16();
            Opponent3 = br.ReadInt16();
            br.ReadInt32();
            Sfx = br.ReadInt32();
        }

        public void Write(BeBinaryWriter bw)
        {
            var baseOffset = bw.BaseStream.Position;
            bw.Write((int)MoveType);
            bw.Write(UnusedName);
            bw.Write(Name);
            bw.Write(SortingName);
            bw.Write(NameCopy);
            bw.Write(FileInfoIndex);
            bw.Write(SkipStart);
            bw.Write(SkipEnd);
            bw.Write(Unk_20);
            bw.Write(Unk_24);
            bw.Write(Unk_28);
            bw.Write(BallEffect);
            bw.Write(BallTailEffect);
            bw.Write(FieldEffect);
            bw.Write(FieldEffect2);
            bw.Write(SceneEffect);
            bw.Write(SceneEffect2);
            bw.Write(PreviewImage);
            bw.Write(Stadium);
            bw.Write(UserUniform);
            bw.BaseStream.Position += 2;
            bw.Write(OpponentUniform);
            bw.BaseStream.Position += 2;
            bw.Write(User);
            bw.Write(Opponent1);
            bw.Write(Opponent2);
            bw.Write(Opponent3);
            bw.BaseStream.Position += 4;
            bw.Write(Sfx);
            var a = bw.BaseStream.Position - baseOffset;

        }
    }
}

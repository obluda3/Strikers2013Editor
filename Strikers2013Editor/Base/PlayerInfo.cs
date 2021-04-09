
namespace Strikers2013Editor.Base
{
    class PlayerInfo
    {
        public int ID;
        public int padding;
        public int shortName2; // 14.bin line minus 4
        public int shortName; // 14.bin line minus 4
        public int fullName; // 14.bin line minus 4
        public string name;
        public int gender;
        public int unk1;
        public int unk2;
        public int description; // 14.bin line minus 2
        public int bodytype;
        public int height;
        public int unk4;
        public int tacticalaction;
        public int unk3;
        public int team2;
        public int team;
        public int playerListPortrait;
        public int position;
        public int unk8;
        public int facemodel; // I'm assuming both of them are the face models but i'm not sure
        public int facemodel2;
        public int unk9;
        public int unk10;
        public int unk11;
        public int playerMugshot;
        public int unk12;
        public int playerPortrait;
        public int playerOtherPortrait;
        public string[] equip; // array of length 12, made up of 8 long strings, don't know what it's for
        public int unk13;
        public int unk14;
        public int unk15;
        public int element;
        public int unk16;
        public int unk17;
        public int unk18;
        public int unk19;
        public int armedAttribution;
        public int unk21;
        public short price;
        public short unk23;
        public int unk24;
        public int unk25;
        public byte[] pad2;

    }
}

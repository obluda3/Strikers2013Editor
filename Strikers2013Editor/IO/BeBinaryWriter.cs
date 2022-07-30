using System;
using System.IO;
using System.Text;

namespace Strikers2013Editor.IO
{
    class BeBinaryWriter : BinaryWriter
    {
        Encoding sjis = Encoding.GetEncoding("sjis");
        public BeBinaryWriter(Stream input) : base(input) 
        {

        }

        public override void Write(short value)
        {
            var buffer = BitConverter.GetBytes(value);
            Array.Reverse(buffer);
            base.Write(buffer);
        }
        public override void Write(int value)
        {
            var buffer = BitConverter.GetBytes(value);
            Array.Reverse(buffer);
            base.Write(buffer);
        }
        public override void Write(ushort value)
        {
            var buffer = BitConverter.GetBytes(value);
            Array.Reverse(buffer);
            base.Write(buffer);
        }
        public override void Write(uint value)
        {
            var buffer = BitConverter.GetBytes(value);
            Array.Reverse(buffer);
            base.Write(buffer);
        }

        public void Write(ushort[] value)
        {
            foreach (var num in value)
                Write(num);
        }

        public void WriteCString(string value)
        {
            var array = Encoding.GetEncoding("sjis").GetBytes(value);
            Write(array);
            Write((short)0);
        }

        public void PadWith(byte padByte, long count)
        {
            for (var i = 0; i < count; i++)
                Write(padByte);
        }

        public void WriteAlignment(int alignment, byte padByte = 0)
        {
            if (BaseStream.Position % alignment == 0)
                return;

            var count = (((BaseStream.Position / alignment) + 1) * alignment) - BaseStream.Position;
            PadWith(padByte, count);
        }
    }
}

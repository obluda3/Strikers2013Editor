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
        }
    }
}

﻿using System;
using System.IO;
namespace Strikers2013Editor.IO
{
    class BeBinaryWriter : BinaryWriter
    {
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
        public void Write(short[] value)
        {
            foreach (var element in value)
                base.Write(element);
        }

    }
}

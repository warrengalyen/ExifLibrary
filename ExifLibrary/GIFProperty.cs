﻿using System;
using System.Text;

namespace ExifLibrary
{
    /// <summary>
    /// Represents a 7-bit ASCII encoded comment string. (GIF Specification: Comment Extension)
    /// </summary>
    public class GIFComment : ExifProperty
    {
        protected string mValue;
        protected override object _Value { get { return Value; } set { Value = (string)value; } }
        public new string Value { get { return mValue; } set { mValue = value; } }

        static public implicit operator string(GIFComment obj) { return obj.mValue; }

        public override string ToString() { return mValue; }

        public GIFComment(ExifTag tag, string value)
            : base(tag)
        {
            mValue = value;
        }

        public override ExifInterOperability Interoperability
        {
            get
            {
                byte[] data = Encoding.ASCII.GetBytes(mValue);

                return new ExifInterOperability((ushort)mTag, InterOpType.ASCII, (uint)data.Length, data);
            }
        }
    }
}
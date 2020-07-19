﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingPrinciples.InterfaceSegregation
{
    public interface IConverter
    {
        string BinaryToText(string binary);
        string TextToBinary(string text);
        string HexadecimalToText(string text);
        string TextToHexadecimal(string text);
    }

    public abstract class Converter
    {
        public int DecimalNumber { get; set; }
        public Converter(int decimalNumber)
        {
            DecimalNumber = decimalNumber;
        }
        public abstract string Convert();
    }

    public class BinaryConverter : Converter, IConverter
    {
        public BinaryConverter(int decimalNumber)
        : base(decimalNumber)
        { }
        public override string Convert()
        {
            return $"The result is: {System.Convert.ToString(DecimalNumber, 2)}";
        }
        public string BinaryToText(string binaryNumber)
        {
            binaryNumber = binaryNumber.Replace(" ", "");
            var list = new List<Byte>();
            for (int i = 0; i < binaryNumber.Length; i += 8)
            {
                string t = binaryNumber.Substring(i, 8);
                list.Add(System.Convert.ToByte(t, 2));
            }
            byte[] result = list.ToArray();
            return Encoding.ASCII.GetString(result);
        }
        public string TextToBinary(string text)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(text);
            return string.Join(" ",
            bytes.Select(byt => System.Convert.ToString(byt, 2).PadLeft(8,
            '0')));
        }
        public string HexadecimalToText(string text)
        {
            throw new NotImplementedException();
        }
        public string TextToHexadecimal(string text)
        {
            throw new NotImplementedException();
        }
    }


    public class HexadecimalConverter : Converter, IConverter
    {
        public HexadecimalConverter(int decimalNumber) : base(decimalNumber)
        { }
        public override string Convert()
        {
            return $"The result is: {DecimalNumber.ToString("X")}";
        }
        public string HexadecimalToText(string text)
        {
            text = text.Replace(" ", "");
            byte[] raw = new byte[text.Length / 2];
            for (int i = 0; i < raw.Length; i++)
            {
                raw[i] = System.Convert.ToByte(text.Substring(i * 2, 2), 16);
            }
            return Encoding.ASCII.GetString(raw); ;
        }
        public string TextToHexadecimal(string text)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(text); var hexString = BitConverter.ToString(bytes);
            hexString = hexString.Replace("-", "");
            return hexString;
        }
        public string TextToBinary(string text)
        {
            throw new NotImplementedException();
        }
        public string BinaryToText(string binary)
        {
            throw new NotImplementedException();
        }
    }



    class Before
    {
    }
}

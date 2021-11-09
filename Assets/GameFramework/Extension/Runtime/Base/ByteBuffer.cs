using System;
using System.IO;
using System.Text;
using GameFramework;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 字节缓存，提供写入、读取操作。
    /// </summary>
    public class ByteBuffer
    {
        private readonly MemoryStream m_Stream;
        private readonly BinaryReader m_Reader;
        private readonly BinaryWriter m_Writer;

        /// <summary>
        /// 获取当前缓存的字节长度。
        /// </summary>
        public long Length => m_Stream.Length;

        /// <summary>
        /// 初始化字节缓存的新实例。
        /// </summary>
        public ByteBuffer()
        {
            m_Stream = new MemoryStream();
            m_Reader = new BinaryReader(m_Stream, Encoding.UTF8);
            m_Writer = new BinaryWriter(m_Stream, Encoding.UTF8);
        }

        /// <summary>
        /// 清理字节缓存。
        /// </summary>
        public void Clear()
        {
            m_Stream.SetLength(0);
        }

        /// <summary>
        /// 释放字节缓存。
        /// </summary>
        public void Release()
        {
            try
            {
                m_Reader.Close();
                m_Writer.Close();
                m_Stream.Close();
            }
            catch (Exception e)
            {
                throw new GameFrameworkException($"Failed to release byte buffer with exception '{e}'.");
            }
        }

        /// <summary>
        /// 开始写入。
        /// </summary>
        public void BeginWrite()
        {
            m_Stream.Position = 0;
        }

        /// <summary>
        /// 写入字符数组。
        /// </summary>
        /// <param name="chars">要写入的字符数组。</param>
        public void Write(char[] chars)
        {
            m_Writer.Write(chars);
        }

        /// <summary>
        /// 写入字符数组。
        /// </summary>
        /// <param name="chars">要写入的字符数组。</param>
        /// <param name="startIndex">要写入的字符数组的起始位置。</param>
        /// <param name="length">要写入的字符数组的长度。</param>
        public void Write(char[] chars, int startIndex, int length)
        {
            m_Writer.Write(chars, startIndex, length);
        }

        /// <summary>
        /// 写入字节数组。
        /// </summary>
        /// <param name="bytes">要写入的字节数组。</param>
        public void Write(byte[] bytes)
        {
            m_Writer.Write(bytes);
        }

        /// <summary>
        /// 写入字节数组。
        /// </summary>
        /// <param name="bytes">要写入的字节数组。</param>
        /// <param name="startIndex">要写入的字节数组的起始位置。</param>
        /// <param name="length">要写入的字节数组的长度。</param>
        public void Write(byte[] bytes, int startIndex, int length)
        {
            m_Writer.Write(bytes, startIndex, length);
        }

        /// <summary>
        /// 写入布尔值。
        /// </summary>
        /// <param name="value">要写入的布尔值。</param>
        public void Write(bool value)
        {
            m_Writer.Write(value);
        }

        /// <summary>
        /// 写入字节。
        /// </summary>
        /// <param name="value">要写入的字节。</param>
        public void Write(byte value)
        {
            m_Writer.Write(value);
        }

        /// <summary>
        /// 写入有符号字节。
        /// </summary>
        /// <param name="value">要写入的有符号字节。</param>
        public void Write(sbyte value)
        {
            m_Writer.Write(value);
        }

        /// <summary>
        /// 写入字符。
        /// </summary>
        /// <param name="value">要写入的字符。</param>
        public void Write(char value)
        {
            m_Writer.Write(value);
        }

        /// <summary>
        /// 写入短整型。
        /// </summary>
        /// <param name="value">写入的短整型。</param>
        public void Write(short value)
        {
            m_Writer.Write(value);
        }

        /// <summary>
        /// 写入无符号短整型。
        /// </summary>
        /// <param name="value">要写入的无符号短整型。</param>
        public void Write(ushort value)
        {
            m_Writer.Write(value);
        }

        /// <summary>
        /// 写入整型。
        /// </summary>
        /// <param name="value">要写入的整型。</param>
        public void Write(int value)
        {
            m_Writer.Write(value);
        }

        /// <summary>
        /// 写入无符号整形。
        /// </summary>
        /// <param name="value">要写入的无符号整形。</param>
        public void Write(uint value)
        {
            m_Writer.Write(value);
        }

        /// <summary>
        /// 写入长整型。
        /// </summary>
        /// <param name="value">要写入的长整型。</param>
        public void Write(long value)
        {
            m_Writer.Write(value);
        }

        /// <summary>
        /// 写入无符号长整型。
        /// </summary>
        /// <param name="value">要写入的无符号长整型。</param>
        public void Write(ulong value)
        {
            m_Writer.Write(value);
        }

        /// <summary>
        /// 写入单精度浮点数。
        /// </summary>
        /// <param name="value">要写入的单精度浮点数。</param>
        public void Write(float value)
        {
            m_Writer.Write(value);
        }

        /// <summary>
        /// 写入双精度浮点数。
        /// </summary>
        /// <param name="value">要写入的双精度浮点数。</param>
        public void Write(double value)
        {
            m_Writer.Write(value);
        }

        /// <summary>
        /// 写入字符串。
        /// </summary>
        /// <param name="value">要写入的字符串。</param>
        public void Write(string value)
        {
            m_Writer.Write(value);
        }

        /// <summary>
        /// 写入 decimal。
        /// </summary>
        /// <param name="value">要写入的 decimal。</param>
        public void Write(decimal value)
        {
            m_Writer.Write(value);
        }

        /// <summary>
        /// 开始读取。
        /// </summary>
        public void BeginRead()
        {
            m_Stream.Position = 0;
        }

        /// <summary>
        /// 读取字节数组。
        /// </summary>
        /// <param name="bytes">存储读取的字节数组。</param>
        /// <param name="startIndex">存储读取的字节数组的起始位置。</param>
        /// <param name="length">要读取的字节长度。</param>
        public void Read(byte[] bytes, int startIndex, int length)
        {
            m_Reader.Read(bytes, startIndex, length);
        }

        /// <summary>
        /// 读取字符数组。
        /// </summary>
        /// <param name="bytes">存储读取的字符数组。</param>
        /// <param name="startIndex">存储读取的字符数组的起始位置。</param>
        /// <param name="length">要读取的字符长度。</param>
        public void Read(char[] bytes, int startIndex, int length)
        {
            m_Reader.Read(bytes, startIndex, length);
        }

        /// <summary>
        /// 读取字节数组。
        /// </summary>
        /// <param name="length">读取字节数组的长度。</param>
        /// <returns>读取的字节数组。</returns>
        public byte[] ReadBytes(int length)
        {
            return m_Reader.ReadBytes(length);
        }

        /// <summary>
        /// 读取字符数组。
        /// </summary>
        /// <param name="length">读取字符数组的长度。</param>
        /// <returns>读取的字符数组。</returns>
        public char[] ReadChars(int length)
        {
            return m_Reader.ReadChars(length);
        }

        /// <summary>
        /// 读取布尔值。
        /// </summary>
        /// <returns>读取到的布尔值。</returns>
        public bool ReadBoolean()
        {
            return m_Reader.ReadBoolean();
        }

        /// <summary>
        /// 读取字节。
        /// </summary>
        /// <returns>读取到的字节。</returns>
        public byte ReadByte()
        {
            return m_Reader.ReadByte();
        }

        /// <summary>
        /// 读取有符号字节。
        /// </summary>
        /// <returns>读取到的有符号字节。</returns>
        public sbyte ReadSByte()
        {
            return m_Reader.ReadSByte();
        }

        /// <summary>
        /// 读取字符。
        /// </summary>
        /// <returns>读取到的字符。</returns>
        public char ReadChar()
        {
            return m_Reader.ReadChar();
        }

        /// <summary>
        /// 读取短整型。
        /// </summary>
        /// <returns>读取到的短整型。</returns>
        public short ReadInt16()
        {
            return m_Reader.ReadInt16();
        }

        /// <summary>
        /// 读取无符号短整型。
        /// </summary>
        /// <returns>读取到的无符号短整型。</returns>
        public ushort ReadUInt16()
        {
            return m_Reader.ReadUInt16();
        }

        /// <summary>
        /// 读取整型。
        /// </summary>
        /// <returns>读取到的整型。</returns>
        public int ReadInt32()
        {
            return m_Reader.ReadInt32();
        }

        /// <summary>
        /// 读取无符号整型。
        /// </summary>
        /// <returns>读取到的无符号整型。</returns>
        public uint ReadUInt32()
        {
            return m_Reader.ReadUInt32();
        }

        /// <summary>
        /// 读取长整型。
        /// </summary>
        /// <returns>读取到的长整型。</returns>
        public long ReadInt64()
        {
            return m_Reader.ReadInt64();
        }

        /// <summary>
        /// 读取无符号长整型。
        /// </summary>
        /// <returns>读取到的无符号长整型。</returns>
        public ulong ReadUInt64()
        {
            return m_Reader.ReadUInt64();
        }

        /// <summary>
        /// 读取单精度浮点数。
        /// </summary>
        /// <returns>读取到的单精度浮点数。</returns>
        public float ReadSingle()
        {
            return m_Reader.ReadSingle();
        }

        /// <summary>
        /// 读取双精度浮点数。
        /// </summary>
        /// <returns>读取到的双精度浮点数。</returns>
        public double ReadDouble()
        {
            return m_Reader.ReadDouble();
        }

        /// <summary>
        /// 读取字符串。
        /// </summary>
        /// <returns>读取到的字符串。</returns>
        public string ReadString()
        {
            return m_Reader.ReadString();
        }

        /// <summary>
        /// 读取 decimal。
        /// </summary>
        /// <returns>读取到的 decimal。</returns>
        public decimal ReadDecimal()
        {
            return m_Reader.ReadDecimal();
        }
    }
}
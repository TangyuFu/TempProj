using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using GameFramework;

namespace UnityGameFramework.Runtime.Extension
{
    public static partial class UUtility
    {
        /// <summary>
        /// 游戏框架转换工具。
        /// </summary>
        public static class Convert
        {
            #region hex <-> byte[]

            /// <summary>
            /// 转化字节数组为 16 进制字符串。
            /// </summary>
            /// <param name="bytes">要转换的字节数组。</param>
            /// <param name="space">字符串间隔字符。</param>
            /// <param name="capital">16 进制字符串大写格式标志。</param>
            /// <returns>转换后的 16 进制字符串。</returns>
            public static string Bytes2Hex(byte[] bytes, string space = "-", bool capital = true)
            {
                if (bytes == null)
                {
                    throw new GameFrameworkException($"Invalid byte '{null}'.");
                }

                return Bytes2Hex(bytes, 0, bytes.Length, space, capital);
            }

            /// <summary>
            /// 转化字节数组为 16 进制字符串。
            /// </summary>
            /// <param name="bytes">要转换的字节数组。</param>
            /// <param name="startIndex">要转换的字节数组的起始位置。</param>
            /// <param name="length">要转换的字节数组的长度。</param>
            /// <param name="space">16 进制字符串间隔字符。</param>
            /// <param name="capital">字符串大写格式标志。</param>
            /// <returns>转换后的 16 进制字符串。</returns>
            public static string Bytes2Hex(byte[] bytes, int startIndex, int length, string space = "-",
                bool capital = true)
            {
                if (bytes == null)
                {
                    throw new GameFrameworkException($"Invalid bytes '{null}'.");
                }

                if (startIndex < 0 || length < 0 || startIndex + length > bytes.Length)
                {
                    throw new GameFrameworkException($"Invalid start index '{startIndex}' or length '{length}'.");
                }

                const string defaultSpace = "-";

                string hex = BitConverter.ToString(bytes, startIndex, length);
                if (space != defaultSpace)
                {
                    hex = hex.Replace(defaultSpace, space);
                }

                if (!capital)
                {
                    hex = hex.ToLower();
                }

                return hex;
            }

            /// <summary>
            /// 16 进制字符串转化为字节数组。
            /// </summary>
            /// <param name="hex">要转换的 16 进制字符串。</param>
            /// <param name="bytes">转换后的字节数组。</param>
            /// <param name="startIndex">转换后的字节数组的起始位置。</param>
            /// <param name="space">要转换的 16 进制字符串的分隔符。</param>
            /// <param name="capital">要转换的 16 进制字符串大写格式标志。</param>
            /// <returns>写入字节数组的长度。</returns>
            public static int Hex2Bytes(string hex, byte[] bytes, int startIndex, string space = "-",
                bool capital = true)
            {
                if (string.IsNullOrEmpty(hex))
                {
                    return 0;
                }

                if (space == null)
                {
                    throw new GameFrameworkException($"Invalid space '{null}'.");
                }

                int count = (hex.Length - 2) / (2 + space.Length) + 1;
                if (startIndex < 0 || startIndex + count > bytes.Length)
                {
                    throw new GameFrameworkException($"Invalid start index '{startIndex}' or length.");
                }

                int charIndex = 0;
                int byteIndex = startIndex;
                while (charIndex < hex.Length)
                {
                    int b1 = Hex2Number(hex[charIndex++]);
                    int b2 = Hex2Number(hex[charIndex++]);
                    byte b = (byte) ((b1 << 4) | b2);
                    bytes[byteIndex++] = b;
                    charIndex += space.Length;
                }

                return byteIndex - startIndex;
            }

            private static int Hex2Number(char c)
            {
                int number = c;
                return number - (number < 58 ? 48 : (number < 97 ? 55 : 87));
            }

            #endregion

            #region string <-> byte[]

            /// <summary>
            /// 转化字符串为字节数组，使用 UTF8 编码。
            /// </summary>
            /// <param name="str">要转换的字符串。</param>
            /// <returns>转换后的字节数组。</returns>
            public static byte[] String2Bytes(string str)
            {
                return string.IsNullOrEmpty(str) ? new byte[0] : Encoding.UTF8.GetBytes(str);
            }

            /// <summary>
            /// 转化字符串为字节数组。
            /// </summary>
            /// <param name="str">要转换的字符串。</param>
            /// <param name="encoding">转化使用的编码。</param>
            /// <returns>转换后的字节数组。</returns>
            public static byte[] String2Bytes(string str, Encoding encoding)
            {
                if (string.IsNullOrEmpty(str))
                {
                    return new byte[0];
                }

                if (encoding == null)
                {
                    throw new GameFrameworkException($"Invalid encoding '{null}'.");
                }

                return encoding.GetBytes(str);
            }

            /// <summary>
            /// 转化字符串为字节数组，使用 UTF8 编码。
            /// </summary>
            /// <param name="str">要转换的字符串。</param>
            /// <param name="bytes">转换后的字节数组。</param>
            /// <returns>转换写入的字节长度。</returns>
            public static int String2Bytes(string str, byte[] bytes)
            {
                return string.IsNullOrEmpty(str) ? 0 : String2Bytes(str, 0, str.Length, Encoding.UTF8, bytes, 0);
            }

            /// <summary>
            /// 转化字符串为字节数组，使用 UTF8 编码。
            /// </summary>
            /// <param name="str">要转换的字符串。</param>
            /// <param name="encoding">转化使用的编码。</param>
            /// <param name="bytes">转换后的字节数组。</param>
            /// <returns>转换写入的字节长度。</returns>
            public static int String2Bytes(string str, Encoding encoding, byte[] bytes)
            {
                return string.IsNullOrEmpty(str) ? 0 : String2Bytes(str, 0, str.Length, encoding, bytes, 0);
            }

            /// <summary>
            /// 转化字符串为字节数组，使用 UTF8 编码。
            /// </summary>
            /// <param name="str">要转换的字符串。</param>
            /// <param name="charStartIndex">要转换的字符串的起始位置。</param>
            /// <param name="charLength">要转换的字符串的长度。</param>
            /// <param name="bytes">转换后的字节数组。</param>
            /// <param name="bytesStartIndex">转换后的字节数组的起始位置。</param>
            /// <returns>转换写入的字节长度。</returns>
            public static int String2Bytes(string str, int charStartIndex, int charLength, byte[] bytes,
                int bytesStartIndex)
            {
                return String2Bytes(str, charStartIndex, charLength, Encoding.UTF8, bytes, bytesStartIndex);
            }

            /// <summary>
            /// 转化字符串为字节数组。
            /// </summary>
            /// <param name="str">要转换的字符串。</param>
            /// <param name="charStartIndex">要转换的字符串的起始位置。</param>
            /// <param name="charLength">要转换的字符串的长度。</param>
            /// <param name="encoding">转化使用的编码。</param>
            /// <param name="bytes">转换后的字节数组。</param>
            /// <param name="bytesStartIndex">转换后的字节数组的起始位置。</param>
            /// <returns>转换写入的字节长度。</returns>
            public static int String2Bytes(string str, int charStartIndex, int charLength, Encoding encoding,
                byte[] bytes,
                int bytesStartIndex)
            {
                if (string.IsNullOrEmpty(str))
                {
                    return 0;
                }

                if (charStartIndex < 0 || charLength < 0 || charStartIndex + charLength > str.Length)
                {
                    throw new GameFrameworkException(
                        $"Invalid char offset '{charStartIndex}' or count '{charLength}'.");
                }

                if (bytes == null)
                {
                    throw new GameFrameworkException($"Invalid bytes '{null}'.");
                }

                if (bytesStartIndex > bytes.Length - 1)
                {
                    throw new GameFrameworkException($"Invalid bytes start index '{bytesStartIndex}'.");
                }

                try
                {
                    return encoding.GetBytes(str, charStartIndex, charLength, bytes, bytesStartIndex);
                }
                catch (Exception e)
                {
                    throw new GameFrameworkException($"Failed to convert string to bytes with exception '{e}'", e);
                }
            }

            /// <summary>
            /// 转化字节数组为字符串，使用 UTF8 编码。
            /// </summary>
            /// <param name="bytes">要转换的字节数组。</param>
            /// <returns>转化后的字符串。</returns>
            public static string Bytes2String(byte[] bytes)
            {
                if (bytes == null)
                {
                    throw new GameFrameworkException($"Invalid bytes '{null}'.");
                }

                return Bytes2String(bytes, 0, bytes.Length);
            }

            /// <summary>
            /// 转化字节数组为字符串。
            /// </summary>
            /// <param name="bytes">要转换的字节数组。</param>
            /// <param name="encoding">转化使用的编码。</param>
            /// <returns>转化后的字符串。</returns>
            public static string Bytes2String(byte[] bytes, Encoding encoding)
            {
                if (bytes == null)
                {
                    throw new GameFrameworkException($"Invalid bytes '{null}'.");
                }

                return Bytes2String(bytes, 0, bytes.Length, encoding);
            }

            /// <summary>
            /// 转化字节数组为字符串，使用 UTF8 编码。
            /// </summary>
            /// <param name="bytes">要转换的字节数组。</param>
            /// <param name="startIndex">要转换的字节数组的起始位置。</param>
            /// <param name="length">要转换的字节数组的长度。</param>
            /// <returns>转化后的字符串。</returns>
            public static string Bytes2String(byte[] bytes, int startIndex, int length)
            {
                return Bytes2String(bytes, startIndex, length, Encoding.UTF8);
            }

            /// <summary>
            /// 转化字节数组为字符串。
            /// </summary>
            /// <param name="bytes">要转换的字节数组。</param>
            /// <param name="startIndex">要转换的字节数组的起始位置。</param>
            /// <param name="length">要转换的字节数组的长度。</param>
            /// <param name="encoding">转化使用的编码。</param>
            /// <returns>转化后的字符串。</returns>
            public static string Bytes2String(byte[] bytes, int startIndex, int length, Encoding encoding)
            {
                if (bytes == null)
                {
                    throw new GameFrameworkException($"Invalid bytes '{null}'.");
                }

                if (startIndex < 0 || length < 0 || startIndex + length > bytes.Length)
                {
                    throw new GameFrameworkException($"Invalid start index '{startIndex}' or length '{length}'.");
                }

                if (encoding == null)
                {
                    throw new GameFrameworkException($"Invalid encoding '{null}'.");
                }

                try
                {
                    return encoding.GetString(bytes, startIndex, length);
                }
                catch (Exception e)
                {
                    throw new GameFrameworkException($"Failed to convert bytes to string with exception '{e}'.", e);
                }
            }

            #endregion

            #region Xml

            /// <summary>
            /// 转换 XmlDocument 为文本。
            /// </summary>
            /// <param name="xmlDoc">要转换的 XmlDocument。</param>
            /// <returns>转换后的文本。</returns>
            public static string XmlDocumentToString(XmlDocument xmlDoc)
            {
                using MemoryStream stream = new MemoryStream();
                using XmlTextWriter writer = new XmlTextWriter(stream, Encoding.UTF8)
                    {Formatting = Formatting.Indented};
                xmlDoc.Save(writer);
                StreamReader sr = new StreamReader(stream, Encoding.UTF8);
                stream.Position = 0;
                string xmlText = sr.ReadToEnd();
                return xmlText;
            }

            /// <summary>
            /// 转换 xml 文本为对象。
            /// </summary>
            /// <param name="xmlString">xml 文本。</param>
            /// <typeparam name="T">对象类型。</typeparam>
            /// <returns>转换后的对象。</returns>
            public static T XmlStringToObject<T>(string xmlString)
            {
                return (T) XmlStringToObject(typeof(T), xmlString);
            }

            /// <summary>
            /// 转换 xml 文本为对象。
            /// </summary>
            /// <param name="type">对象类型</param>
            /// <param name="xmlString">xml 文本。</param>
            /// <returns>转换后的对象。</returns>
            public static object XmlStringToObject(Type type, string xmlString)
            {
                XmlSerializer xmlSerializer = new XmlSerializer(type);
                using StringReader stringReader = new StringReader(xmlString);
                using XmlReader xmlReader = new XmlTextReader(stringReader);
                return xmlSerializer.Deserialize(xmlReader);
            }

            /// <summary>
            /// 转化对象为 xml 文本。
            /// </summary>
            /// <param name="obj">对象。</param>
            /// <returns>转化后的文本。</returns>
            public static string ObjectToXmlString(object obj)
            {
                XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
                using MemoryStream ms = new MemoryStream();
                using XmlWriter xmlWriter = new XmlTextWriter(ms, new UTF8Encoding(false))
                    {Formatting = Formatting.Indented};

                xmlSerializer.Serialize(xmlWriter, obj);
                return Encoding.UTF8.GetString(ms.ToArray());
            }

            #endregion
        }
    }
}
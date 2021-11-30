﻿using System.IO;
using System.Security.Cryptography;
using GameFramework;

namespace UnityGameFramework.Runtime.Extension
{
    public static partial class UUtility
    {
        /// <summary>
        /// 游戏框架加密工具。
        /// </summary>
        public static class Crypto
        {
            /// <summary>
            /// 计算 MD5 哈希值，返回 16 字节数组。
            /// </summary>
            /// <param name="bytes">要计算的二进制流数组。</param>
            /// <returns>MD5 哈希值。</returns>
            public static byte[] ComputeMd5(byte[] bytes)
            {
                if (bytes == null)
                {
                    throw new GameFrameworkException($"Invalid bytes '{bytes}'.");
                }

                using MD5 md5 = MD5.Create();
                return md5.ComputeHash(bytes);
            }

            /// <summary>
            /// 计算 MD5 哈希值，返回 16 字节数组。
            /// </summary>
            /// <param name="bytes">要计算的二进制流数组。</param>
            /// <param name="startIndex">要计算的二进制流数组的起始位置。</param>
            /// <param name="length">要计算的二进制流数组的长度。</param>
            /// <returns>MD5 哈希值。</returns>
            public static byte[] ComputeMd5(byte[] bytes, int startIndex, int length)
            {
                if (bytes == null)
                {
                    throw new GameFrameworkException($"Invalid bytes '{bytes}'.");
                }

                using MD5 md5 = MD5.Create();
                return md5.ComputeHash(bytes, startIndex, length);
            }

            /// <summary>
            /// 计算 MD5 哈希值，返回 16 字节数组。
            /// </summary>
            /// <param name="stream">要计算的数据流。</param>
            /// <returns>MD5 哈希值。</returns>
            public static byte[] ComputeMd5(Stream stream)
            {
                if (stream == null)
                {
                    throw new GameFrameworkException($"Invalid stream '{stream}'.");
                }

                using MD5 md5 = MD5.Create();
                return md5.ComputeHash(stream);
            }

            /// <summary>
            /// 计算自身异或值。
            /// </summary>
            /// <param name="bytes">要计算的二进制流数组。</param>
            /// <param name="codes">异或使用的密码。</param>
            /// <returns>MD5 哈希值。</returns>
            public static void ComputeXor(byte[] bytes, byte[] codes)
            {
                if (bytes == null)
                {
                    throw new GameFrameworkException($"Invalid bytes '{bytes}'.");
                }

                ComputeXor(bytes, 0, bytes.Length, codes);
            }

            /// <summary>
            /// 计算自身异或值。
            /// </summary>
            /// <param name="bytes">要计算的二进制流数组。</param>
            /// <param name="startIndex">要计算的二进制流数组的起始位置。</param>
            /// <param name="length">要计算的二进制流数组的长度。</param>
            /// <param name="codes">异或使用的密码。</param>
            /// <returns>MD5 哈希值。</returns>
            public static void ComputeXor(byte[] bytes, int startIndex, int length, byte[] codes)
            {
                if (bytes == null)
                {
                    throw new GameFrameworkException($"Invalid bytes '{bytes}'.");
                }

                if (startIndex < 0 || length < 0 || startIndex + length > bytes.Length)
                {
                    throw new GameFrameworkException($"Invalid start index '{startIndex}' or count '{length}'.");
                }

                if (codes == null)
                {
                    throw new GameFrameworkException($"Invalid codes '{codes}'.");
                }

                int codeLen = codes.Length;
                for (int i = 0; i < length; i++)
                {
                    bytes[startIndex + i] ^= codes[i / codeLen];
                }
            }

            private static uint[] s_Crc32Table =
            {
                0x00000000, 0x77073096, 0xee0e612c, 0x990951ba, 0x076dc419, 0x706af48f,
                0xe963a535, 0x9e6495a3, 0x0edb8832, 0x79dcb8a4, 0xe0d5e91e, 0x97d2d988,
                0x09b64c2b, 0x7eb17cbd, 0xe7b82d07, 0x90bf1d91, 0x1db71064, 0x6ab020f2,
                0xf3b97148, 0x84be41de, 0x1adad47d, 0x6ddde4eb, 0xf4d4b551, 0x83d385c7,
                0x136c9856, 0x646ba8c0, 0xfd62f97a, 0x8a65c9ec, 0x14015c4f, 0x63066cd9,
                0xfa0f3d63, 0x8d080df5, 0x3b6e20c8, 0x4c69105e, 0xd56041e4, 0xa2677172,
                0x3c03e4d1, 0x4b04d447, 0xd20d85fd, 0xa50ab56b, 0x35b5a8fa, 0x42b2986c,
                0xdbbbc9d6, 0xacbcf940, 0x32d86ce3, 0x45df5c75, 0xdcd60dcf, 0xabd13d59,
                0x26d930ac, 0x51de003a, 0xc8d75180, 0xbfd06116, 0x21b4f4b5, 0x56b3c423,
                0xcfba9599, 0xb8bda50f, 0x2802b89e, 0x5f058808, 0xc60cd9b2, 0xb10be924,
                0x2f6f7c87, 0x58684c11, 0xc1611dab, 0xb6662d3d, 0x76dc4190, 0x01db7106,
                0x98d220bc, 0xefd5102a, 0x71b18589, 0x06b6b51f, 0x9fbfe4a5, 0xe8b8d433,
                0x7807c9a2, 0x0f00f934, 0x9609a88e, 0xe10e9818, 0x7f6a0dbb, 0x086d3d2d,
                0x91646c97, 0xe6635c01, 0x6b6b51f4, 0x1c6c6162, 0x856530d8, 0xf262004e,
                0x6c0695ed, 0x1b01a57b, 0x8208f4c1, 0xf50fc457, 0x65b0d9c6, 0x12b7e950,
                0x8bbeb8ea, 0xfcb9887c, 0x62dd1ddf, 0x15da2d49, 0x8cd37cf3, 0xfbd44c65,
                0x4db26158, 0x3ab551ce, 0xa3bc0074, 0xd4bb30e2, 0x4adfa541, 0x3dd895d7,
                0xa4d1c46d, 0xd3d6f4fb, 0x4369e96a, 0x346ed9fc, 0xad678846, 0xda60b8d0,
                0x44042d73, 0x33031de5, 0xaa0a4c5f, 0xdd0d7cc9, 0x5005713c, 0x270241aa,
                0xbe0b1010, 0xc90c2086, 0x5768b525, 0x206f85b3, 0xb966d409, 0xce61e49f,
                0x5edef90e, 0x29d9c998, 0xb0d09822, 0xc7d7a8b4, 0x59b33d17, 0x2eb40d81,
                0xb7bd5c3b, 0xc0ba6cad, 0xedb88320, 0x9abfb3b6, 0x03b6e20c, 0x74b1d29a,
                0xead54739, 0x9dd277af, 0x04db2615, 0x73dc1683, 0xe3630b12, 0x94643b84,
                0x0d6d6a3e, 0x7a6a5aa8, 0xe40ecf0b, 0x9309ff9d, 0x0a00ae27, 0x7d079eb1,
                0xf00f9344, 0x8708a3d2, 0x1e01f268, 0x6906c2fe, 0xf762575d, 0x806567cb,
                0x196c3671, 0x6e6b06e7, 0xfed41b76, 0x89d32be0, 0x10da7a5a, 0x67dd4acc,
                0xf9b9df6f, 0x8ebeeff9, 0x17b7be43, 0x60b08ed5, 0xd6d6a3e8, 0xa1d1937e,
                0x38d8c2c4, 0x4fdff252, 0xd1bb67f1, 0xa6bc5767, 0x3fb506dd, 0x48b2364b,
                0xd80d2bda, 0xaf0a1b4c, 0x36034af6, 0x41047a60, 0xdf60efc3, 0xa867df55,
                0x316e8eef, 0x4669be79, 0xcb61b38c, 0xbc66831a, 0x256fd2a0, 0x5268e236,
                0xcc0c7795, 0xbb0b4703, 0x220216b9, 0x5505262f, 0xc5ba3bbe, 0xb2bd0b28,
                0x2bb45a92, 0x5cb36a04, 0xc2d7ffa7, 0xb5d0cf31, 0x2cd99e8b, 0x5bdeae1d,
                0x9b64c2b0, 0xec63f226, 0x756aa39c, 0x026d930a, 0x9c0906a9, 0xeb0e363f,
                0x72076785, 0x05005713, 0x95bf4a82, 0xe2b87a14, 0x7bb12bae, 0x0cb61b38,
                0x92d28e9b, 0xe5d5be0d, 0x7cdcefb7, 0x0bdbdf21, 0x86d3d2d4, 0xf1d4e242,
                0x68ddb3f8, 0x1fda836e, 0x81be16cd, 0xf6b9265b, 0x6fb077e1, 0x18b74777,
                0x88085ae6, 0xff0f6a70, 0x66063bca, 0x11010b5c, 0x8f659eff, 0xf862ae69,
                0x616bffd3, 0x166ccf45, 0xa00ae278, 0xd70dd2ee, 0x4e048354, 0x3903b3c2,
                0xa7672661, 0xd06016f7, 0x4969474d, 0x3e6e77db, 0xaed16a4a, 0xd9d65adc,
                0x40df0b66, 0x37d83bf0, 0xa9bcae53, 0xdebb9ec5, 0x47b2cf7f, 0x30b5ffe9,
                0xbdbdf21c, 0xcabac28a, 0x53b39330, 0x24b4a3a6, 0xbad03605, 0xcdd70693,
                0x54de5729, 0x23d967bf, 0xb3667a2e, 0xc4614ab8, 0x5d681b02, 0x2a6f2b94,
                0xb40bbe37, 0xc30c8ea1, 0x5a05df1b, 0x2d02ef8d
            };

            /// <summary>
            /// 计算 CRC-32 值。
            /// </summary>
            /// <param name="startValue">计算的起始值。</param>
            /// <param name="bytes">要计算的二进制流数组。</param>
            /// <param name="startIndex">要计算的二进制流数组的起始位置。</param>
            /// <param name="length">要计算的二进制流数组的长度。</param>
            /// <returns>计算的 CRC-32 值。</returns>
            public static uint ComputeCrc32(uint startValue, byte[] bytes, int startIndex, int length)
            {
                if (bytes == null)
                {
                    throw new GameFrameworkException($"Invalid bytes '{bytes}'");
                }

                if (startIndex < 0 || length < 0 || startIndex + length > bytes.Length)
                {
                    throw new GameFrameworkException($"Invalid start index '{startIndex}' or length '{length}'.");
                }

                uint crc = startValue ^ ~0u;
                for (int i = startIndex; i < startIndex + length; i++)
                {
                    crc = s_Crc32Table[(crc ^ bytes[i]) & 0xFF] ^ (crc >> 8);
                }

                return crc ^ ~0u;
            }

            private static int[] s_Crc16Table =
            {
                0x0000, 0x1189, 0x2312, 0x329b, 0x4624, 0x57ad, 0x6536, 0x74bf,
                0x8c48, 0x9dc1, 0xaf5a, 0xbed3, 0xca6c, 0xdbe5, 0xe97e, 0xf8f7,
                0x1081, 0x0108, 0x3393, 0x221a, 0x56a5, 0x472c, 0x75b7, 0x643e,
                0x9cc9, 0x8d40, 0xbfdb, 0xae52, 0xdaed, 0xcb64, 0xf9ff, 0xe876,
                0x2102, 0x308b, 0x0210, 0x1399, 0x6726, 0x76af, 0x4434, 0x55bd,
                0xad4a, 0xbcc3, 0x8e58, 0x9fd1, 0xeb6e, 0xfae7, 0xc87c, 0xd9f5,
                0x3183, 0x200a, 0x1291, 0x0318, 0x77a7, 0x662e, 0x54b5, 0x453c,
                0xbdcb, 0xac42, 0x9ed9, 0x8f50, 0xfbef, 0xea66, 0xd8fd, 0xc974,
                0x4204, 0x538d, 0x6116, 0x709f, 0x0420, 0x15a9, 0x2732, 0x36bb,
                0xce4c, 0xdfc5, 0xed5e, 0xfcd7, 0x8868, 0x99e1, 0xab7a, 0xbaf3,
                0x5285, 0x430c, 0x7197, 0x601e, 0x14a1, 0x0528, 0x37b3, 0x263a,
                0xdecd, 0xcf44, 0xfddf, 0xec56, 0x98e9, 0x8960, 0xbbfb, 0xaa72,
                0x6306, 0x728f, 0x4014, 0x519d, 0x2522, 0x34ab, 0x0630, 0x17b9,
                0xef4e, 0xfec7, 0xcc5c, 0xddd5, 0xa96a, 0xb8e3, 0x8a78, 0x9bf1,
                0x7387, 0x620e, 0x5095, 0x411c, 0x35a3, 0x242a, 0x16b1, 0x0738,
                0xffcf, 0xee46, 0xdcdd, 0xcd54, 0xb9eb, 0xa862, 0x9af9, 0x8b70,
                0x8408, 0x9581, 0xa71a, 0xb693, 0xc22c, 0xd3a5, 0xe13e, 0xf0b7,
                0x0840, 0x19c9, 0x2b52, 0x3adb, 0x4e64, 0x5fed, 0x6d76, 0x7cff,
                0x9489, 0x8500, 0xb79b, 0xa612, 0xd2ad, 0xc324, 0xf1bf, 0xe036,
                0x18c1, 0x0948, 0x3bd3, 0x2a5a, 0x5ee5, 0x4f6c, 0x7df7, 0x6c7e,
                0xa50a, 0xb483, 0x8618, 0x9791, 0xe32e, 0xf2a7, 0xc03c, 0xd1b5,
                0x2942, 0x38cb, 0x0a50, 0x1bd9, 0x6f66, 0x7eef, 0x4c74, 0x5dfd,
                0xb58b, 0xa402, 0x9699, 0x8710, 0xf3af, 0xe226, 0xd0bd, 0xc134,
                0x39c3, 0x284a, 0x1ad1, 0x0b58, 0x7fe7, 0x6e6e, 0x5cf5, 0x4d7c,
                0xc60c, 0xd785, 0xe51e, 0xf497, 0x8028, 0x91a1, 0xa33a, 0xb2b3,
                0x4a44, 0x5bcd, 0x6956, 0x78df, 0x0c60, 0x1de9, 0x2f72, 0x3efb,
                0xd68d, 0xc704, 0xf59f, 0xe416, 0x90a9, 0x8120, 0xb3bb, 0xa232,
                0x5ac5, 0x4b4c, 0x79d7, 0x685e, 0x1ce1, 0x0d68, 0x3ff3, 0x2e7a,
                0xe70e, 0xf687, 0xc41c, 0xd595, 0xa12a, 0xb0a3, 0x8238, 0x93b1,
                0x6b46, 0x7acf, 0x4854, 0x59dd, 0x2d62, 0x3ceb, 0x0e70, 0x1ff9,
                0xf78f, 0xe606, 0xd49d, 0xc514, 0xb1ab, 0xa022, 0x92b9, 0x8330,
                0x7bc7, 0x6a4e, 0x58d5, 0x495c, 0x3de3, 0x2c6a, 0x1ef1, 0x0f78
            };

            /// <summary>
            /// 计算 CRC-16 值。
            /// </summary>
            /// <param name="startValue">计算的起始值。</param>
            /// <param name="bytes">要计算的二进制流数组。</param>
            /// <param name="startIndex">要计算的二进制流数组的起始位置。</param>
            /// <param name="length">要计算的二进制流数组的长度。</param>
            /// <returns>计算的 CRC-16 值。</returns>
            public static ushort ComputeCrc16(ushort startValue, byte[] bytes, int startIndex, int length)
            {
                if (bytes == null)
                {
                    throw new GameFrameworkException($"Invalid bytes '{null}'");
                }

                if (startIndex < 0 || length < 0 || startIndex + length > bytes.Length)
                {
                    throw new GameFrameworkException($"Invalid start index '{startIndex}' or length '{length}'.");
                }

                uint crc = startValue ^ ~0u;
                for (int i = startIndex; i < startIndex + length; i++)
                {
                    crc = s_Crc32Table[(crc ^ bytes[i]) & 0xFF] ^ (crc >> 8);
                }

                return (ushort) (crc ^ ~0u);
            }
        }
    }
}
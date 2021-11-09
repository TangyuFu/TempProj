using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UnityGameFramework.Runtime.Extension
{
    public static partial class UUtility
    {
        /// <summary>
        /// Unity 游戏框架系统进程工具。
        /// </summary>
        public static class Process
        {
            /// <summary>
            /// 执行文件。
            /// </summary>
            /// <param name="fileName">文件名。</param>
            /// <param name="arguments">参数。</param>
            /// <param name="timeout">等待时间。</param>
            /// <returns>执行结果。</returns>
            public static ProcessResult ExecuteFile(string fileName, string arguments, int timeout)
            {
                using System.Diagnostics.Process process = new System.Diagnostics.Process
                {
                    StartInfo =
                    {
                        FileName = fileName,
                        Arguments = arguments,
                        UseShellExecute = false,
                        // 执行文件时，需关闭标准输入。
                        RedirectStandardInput = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        CreateNoWindow = true,
                        // 设置标准输出编码。
                        StandardOutputEncoding = Encoding.GetEncoding(CultureInfo.CurrentCulture.TextInfo.OEMCodePage),
                        // 设置标准错误编码。
                        StandardErrorEncoding = Encoding.GetEncoding(CultureInfo.CurrentCulture.TextInfo.OEMCodePage),
                    }
                };

                try
                {
                    process.Start();
                }
                catch (Exception e)
                {
                    Debug.LogError($"Failed to start process with exception '{e}'.");
                    return new ProcessResult
                    {
                        ExitCode = null,
                        Output = String.Empty,
                        Error = string.Empty,
                    };
                }

                if (process.WaitForExit(timeout))
                {
                    return new ProcessResult
                    {
                        ExitCode = process.ExitCode,
                        Output = process.StandardOutput.ReadToEnd(),
                        Error = process.StandardError.ReadToEnd(),
                    };
                }
                else
                {
                    try
                    {
                        // 杀掉进程。
                        process.Kill();
                    }
                    catch (Exception e)
                    {
                        Debug.LogError($"Failed to kill process with exception '{e}'.");
                    }

                    return new ProcessResult
                    {
                        ExitCode = null,
                        Output = process.StandardOutput.ReadToEnd(),
                        Error = process.StandardError.ReadToEnd(),
                    };
                }
            }

            /// <summary>
            ///  执行命令。
            /// </summary>
            /// <param name="workingDirectory">命令执行的工作目录。</param>
            /// <param name="commands">执行的命令。</param>
            /// <param name="timeout">等待时间。</param>
            /// <returns>执行结果。</returns>
            public static ProcessResult ExecuteCommand(string workingDirectory, string[] commands, int timeout)
            {
                using System.Diagnostics.Process process = new System.Diagnostics.Process
                {
                    StartInfo =
                    {
                        WorkingDirectory = workingDirectory,
                        UseShellExecute = false,
                        // 执行文件时，需关闭标准输入。
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        CreateNoWindow = true,
                        // 设置标准输出编码。
                        StandardOutputEncoding = Encoding.GetEncoding(CultureInfo.CurrentCulture.TextInfo.OEMCodePage),
                        // 设置标准错误编码。
                        StandardErrorEncoding = Encoding.GetEncoding(CultureInfo.CurrentCulture.TextInfo.OEMCodePage),
                    }
                };

                switch (Application.platform)
                {
                    case RuntimePlatform.WindowsEditor:
                        process.StartInfo.FileName = "cmd.exe";
                        break;

                    case RuntimePlatform.OSXEditor:
                        process.StartInfo.FileName = "terminal";
                        break;

                    default:
                        throw new InvalidOperationException($"Unsupported platform '{Application.platform}'.");
                }

                try
                {
                    process.Start();
                }
                catch (Exception e)
                {
                    Debug.LogError($"Failed to start process with exception '{e}'.");
                    return new ProcessResult
                    {
                        ExitCode = null,
                        Output = String.Empty,
                        Error = string.Empty,
                    };
                }

                StreamWriter input = process.StandardInput;
                for (int i = 0; i < commands.Length; i++)
                {
                    input.WriteLine(commands[i]);
                }

                input.Close();

                if (process.WaitForExit(timeout))
                {
                    return new ProcessResult
                    {
                        ExitCode = process.ExitCode,
                        Output = process.StandardOutput.ReadToEnd(),
                        Error = process.StandardError.ReadToEnd(),
                    };
                }
                else
                {
                    try
                    {
                        // 杀掉进程。
                        process.Kill();
                    }
                    catch (Exception e)
                    {
                        Debug.LogError($"Failed to kill process with exception '{e}'.");
                    }

                    return new ProcessResult
                    {
                        ExitCode = null,
                        Output = process.StandardOutput.ReadToEnd(),
                        Error = process.StandardError.ReadToEnd(),
                    };
                }
            }

            /// <summary>
            /// 异步执行文件。
            /// </summary>
            /// <param name="fileName">文件名。</param>
            /// <param name="arguments">参数。</param>
            /// <param name="timeout">等待时间。</param>
            /// <returns>执行结果。</returns>
            public static async Task<ProcessResult> ExecuteFileAsync(string fileName, string arguments, int timeout)
            {
                // If you run bash-script on Linux it is possible that ExitCode can be 255.
                // To fix it you can try to add '#!/bin/bash' header to the script.
                using System.Diagnostics.Process process = new System.Diagnostics.Process
                {
                    StartInfo =
                    {
                        FileName = fileName,
                        Arguments = arguments,
                        UseShellExecute = false,
                        // 执行文件时，需关闭标准输入。
                        RedirectStandardInput = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        CreateNoWindow = true,
                        // 设置标准输出编码。
                        StandardOutputEncoding = Encoding.GetEncoding(CultureInfo.CurrentCulture.TextInfo.OEMCodePage),
                        // 设置标准错误编码。
                        StandardErrorEncoding = Encoding.GetEncoding(CultureInfo.CurrentCulture.TextInfo.OEMCodePage),
                    }
                };

                try
                {
                    process.Start();
                }
                catch (Exception e)
                {
                    Debug.LogError($"Failed to start process with exception '{e}'.");
                    return new ProcessResult
                    {
                        ExitCode = null,
                        Output = String.Empty,
                        Error = string.Empty,
                    };
                }

                // 开始读取输出流和错误流。
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                // 创建等待退出任务。
                Task<bool> waitForExit = WaitForExitAsync(process, timeout);

                // Waits process completion and then checks it was not completed by timeout
                if (await waitForExit)
                {
                    return new ProcessResult
                    {
                        ExitCode = process.ExitCode,
                        Output = await process.StandardOutput.ReadToEndAsync(),
                        Error = await process.StandardError.ReadToEndAsync(),
                    };
                }
                else
                {
                    try
                    {
                        // 杀掉进程。
                        process.Kill();
                    }
                    catch (Exception e)
                    {
                        Debug.LogError($"Failed to kill process with exception '{e}'.");
                    }

                    return new ProcessResult
                    {
                        ExitCode = null,
                        Output = await process.StandardOutput.ReadToEndAsync(),
                        Error = await process.StandardError.ReadToEndAsync(),
                    };
                }
            }

            /// <summary>
            ///  执行命令。
            /// </summary>
            /// <param name="workingDirectory">命令执行的工作目录。</param>
            /// <param name="commands">执行的命令。</param>
            /// <param name="timeout">等待时间。</param>
            /// <returns>执行结果。</returns>
            public static async Task<ProcessResult> ExecuteCommandAsync(string workingDirectory, string[] commands,
                int timeout)
            {
                // If you run bash-script on Linux it is possible that ExitCode can be 255.
                // To fix it you can try to add '#!/bin/bash' header to the script.
                using System.Diagnostics.Process process = new System.Diagnostics.Process
                {
                    StartInfo =
                    {
                        WorkingDirectory = workingDirectory,
                        UseShellExecute = false,
                        // 执行文件时，需关闭标准输入。
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        CreateNoWindow = true,
                        // 设置标准输出编码。
                        StandardOutputEncoding = Encoding.GetEncoding(CultureInfo.CurrentCulture.TextInfo.OEMCodePage),
                        // 设置标准错误编码。
                        StandardErrorEncoding = Encoding.GetEncoding(CultureInfo.CurrentCulture.TextInfo.OEMCodePage),
                    }
                };

                switch (Application.platform)
                {
                    case RuntimePlatform.WindowsEditor:
                        process.StartInfo.FileName = "cmd.exe";
                        break;

                    case RuntimePlatform.OSXEditor:
                        process.StartInfo.FileName = "terminal";
                        break;

                    default:
                        throw new InvalidOperationException($"Unsupported platform '{Application.platform}'.");
                }

                try
                {
                    process.Start();
                }
                catch (Exception e)
                {
                    Debug.LogError($"Failed to start process with exception '{e}'.");
                    return new ProcessResult
                    {
                        ExitCode = null,
                        Output = String.Empty,
                        Error = string.Empty,
                    };
                }

                StreamWriter input = process.StandardInput;
                for (int i = 0; i < commands.Length; i++)
                {
                    await input.WriteLineAsync(commands[i]);
                }

                input.Close();

                // 创建等待退出任务。
                Task<bool> waitForExit = WaitForExitAsync(process, timeout);

                // Waits process completion and then checks it was not completed by timeout
                if (await waitForExit)
                {
                    return new ProcessResult
                    {
                        ExitCode = process.ExitCode,
                        Output = await process.StandardOutput.ReadToEndAsync(),
                        Error = await process.StandardError.ReadToEndAsync(),
                    };
                }
                else
                {
                    try
                    {
                        // 杀掉进程。
                        process.Kill();
                    }
                    catch (Exception e)
                    {
                        Debug.LogError($"Failed to kill process with exception '{e}'.");
                    }

                    return new ProcessResult
                    {
                        ExitCode = null,
                        Output = await process.StandardOutput.ReadToEndAsync(),
                        Error = await process.StandardError.ReadToEndAsync(),
                    };
                }
            }

            private static Task<bool> WaitForExitAsync(System.Diagnostics.Process process, int timeout)
            {
                return Task.Run(() => process.WaitForExit(timeout));
            }

            /// <summary>
            /// 执行结果。
            /// </summary>
            public struct ProcessResult
            {
                /// <summary>
                /// 退出码 ,为空时，未开始。。
                /// </summary>
                public int? ExitCode { get; set; }

                /// <summary>
                /// 输出。
                /// </summary>
                public string Output { get; set; }

                /// <summary>
                /// 输出错误。
                /// </summary>
                public string Error { get; set; }
            }
        }
    }
}
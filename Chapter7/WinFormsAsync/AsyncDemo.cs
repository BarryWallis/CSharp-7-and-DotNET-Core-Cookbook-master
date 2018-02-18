using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAsync
{
    class AsyncDemo
    {
        public enum LogType
        {
            Main = 0, Backup = 1
        }

        async Task<bool> TaskOfTresultReturning_AsyncMethod() => await Task.FromResult(DateTime.IsLeapYear(DateTime.Now.Year));

        async Task TaskReturning_AsyncMethod()
        {
            await Task.Delay(5000);
            Console.WriteLine("5 second delay");
        }

        public async Task LongTask()
        {
            Task<bool> inIsLeapYear =  TaskOfTresultReturning_AsyncMethod();
            for (int i = 0; i < 10000; i++)
            {

            }

            bool isLeapYear = await TaskOfTresultReturning_AsyncMethod();
            Console.WriteLine($"{DateTime.Now.Year} {(isLeapYear ? " is " : " is not ")} a leap year");
            Task taskReturnMethod = TaskReturning_AsyncMethod();
            for (int i = 0; i < 10000; i++)
            {

            }

            await taskReturnMethod;
        }

        public static Task<int> ReadBigFile()
        {
            FileStream bigFile = File.OpenRead(@"..\..\LongFile.txt");
            byte[] bigFIleBuffer = new byte[bigFile.Length];
            Task<int> readBytes = bigFile.ReadAsync(bigFIleBuffer, 0, (int)bigFile.Length);
            readBytes.ContinueWith(task =>
            {
                switch (task.Status)
                {
                    case TaskStatus.Running:
                        Console.WriteLine("Running");
                        break;
                    case TaskStatus.RanToCompletion:
                        Console.WriteLine("RanToCompletion");
                        break;
                    case TaskStatus.Faulted:
                        Console.WriteLine("Faulted");
                        break;
                    default:
                        break;
                }
            });
            return readBytes;
        }

        private static async Task<int> ReadLog(LogType logType)
        {
            string logFilePath = string.Empty;
            switch (logType)
            {
                case LogType.Main:
                    logFilePath = @"..\..\MainLog\taskFile.txt";
                    break;
                case LogType.Backup:
                    logFilePath = @"..\..\BackupLog\TaskFile.txt";
                    break;
                default:
                    Debug.Fail($"Unexpected {nameof(LogType)}: {logType}");
                    break;
            }

            string enumName = Enum.GetName(typeof(LogType), (int)logType);

            FileStream bigFile = File.OpenRead(logFilePath);
            byte[] bigFileBuffer = new byte[bigFile.Length];
            Task<int> readBytes = bigFile.ReadAsync(bigFileBuffer, 0, (int)bigFile.Length);
            await readBytes.ContinueWith(task =>
            {
                switch (task.Status)
                {
                    case TaskStatus.RanToCompletion:
                        Console.WriteLine($"{enumName} Log RanToCompletion");
                        break;
                    case TaskStatus.Faulted:
                        Console.WriteLine($"{enumName} Log Faulted");
                        break;
                }

                bigFile.Dispose();
            });

            return await readBytes;
        }

        public static async Task<int> ReadLogFile()
        {
            int returnBytes = -1;
            try
            {
                returnBytes = await ReadLog(LogType.Main);
            }
            catch (Exception)
            {
                try
                {
                    returnBytes = await ReadLog(LogType.Backup);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return returnBytes;
        }
    }
}

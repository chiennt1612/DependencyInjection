using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DependencyInjection.Models
{
    public static class AuditLogs
    {
        public const string _Path = @"C:\Logs";
        public const string _FileLog = @"log.txt";
        public static async Task WriteLog(string Msg)
        {
            if (!Directory.Exists(_Path)) Directory.CreateDirectory(_Path);
            using(FileStream fs = new FileStream(_Path + "\\" + _FileLog, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    await sw.WriteLineAsync($"Logtime: {DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy")}:\n\t{Msg}\n");
                    await sw.FlushAsync();
                    sw.Close();
                    sw.Dispose();
                }
                fs.Close();
                fs.Dispose();
            }
        }
    }
}
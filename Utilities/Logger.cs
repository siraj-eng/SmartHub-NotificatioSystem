using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHub_NotificatioSystem.Utilities
{
    public static class Logger
    {
        public static void LogInfo(string message) => Console.WriteLine($"[INFO] {message}");
        public static void LogWarning(string message) => Console.WriteLine($"[WARNING] {message}");
        public static void LogError(string message) => Console.WriteLine($"[ERROR] {message}");
    }
}

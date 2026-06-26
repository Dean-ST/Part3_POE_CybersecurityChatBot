using System;
using System.Collections.Generic;
using System.Text;

namespace CyberSecurityBot
{
        public static class ActivityLogger
        {
            private static List<string> logs =
                new List<string>();

            public static void Log(string action)
            {
                logs.Add(
                    $"[{DateTime.Now:HH:mm}] {action}");
            }

            public static string GetRecentLog(
                int count = 10)
            {
                return string.Join(
                    "\n",
                    logs.TakeLast(count));
            }

            public static string GetFullLog()
            {
                return string.Join("\n", logs);
            }

            public static int GetCount()
            {
                return logs.Count;
            }
        }
    }



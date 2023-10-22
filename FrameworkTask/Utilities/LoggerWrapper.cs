using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkTask.Utilities
{
    public class LoggerWrapper
    {
        
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        

        public static void LogInfo(string text)
        {
            logger.Info(text);
        }

        public static void LogError(string text)
        {
            logger.Error(text);
        }
    }
}

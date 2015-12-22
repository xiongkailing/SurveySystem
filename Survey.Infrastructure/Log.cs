using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Infrastructure
{
    public class Log
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        public static Log instance;
        public static Log Instance()
        {
            if (instance == null)
            {
                instance = new Log();
            }
            return instance;
        }
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="logInfo">LogEventInfo对象</param>
        public void WriteLog(LogEventInfo logInfo)
        {
            this.logger.Log(logInfo);
        }
    }
}

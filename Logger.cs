using Logger.src.core;
using Logger.src.core.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    /// <summary>
    /// Main class of the Logger library.
    /// </summary>
    public class Logger
    {
        #region Fields

        public bool forced { get; private set; }
        public bool enableExceptions { get; private set; }

        #endregion

        #region Singleton

        private static Logger _instance;

        /// <summary>
        /// Singleton of the class.
        /// </summary>
        public static Logger Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Logger();
                }
                return (_instance);
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Main constructor of the class.
        /// </summary>
        private Logger()
        {
            this.forced = false;
            this.enableExceptions = true;
        }

        #endregion

        #region Loader

        /// <summary>
        /// Method that load modules etc.
        /// </summary>
        public void load()
        {

        }

        #endregion

        #region Methods

        /// <summary>
        /// Main method of the Logger class. Used to log a message with their logType.
        /// </summary>
        /// <param name="logType"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        private bool Log(LogType logType, string log)
        {
            Log newLog = new Log(logType, log);
            newLog.Create();
            return (true);
        }

        /// <summary>
        /// Method that allow the user to create a new Info log.
        /// </summary>
        /// <param name="logMessage"></param>
        /// <returns></returns>
        public bool Info(string logMessage)
        {
            return (this.Log(LogType.info, logMessage));
        }

        /// <summary>
        /// Method that allow the user to create a new Success log.
        /// </summary>
        /// <param name="logMessage"></param>
        /// <returns></returns>
        public bool Success(string logMessage)
        {
            return (this.Log(LogType.success, logMessage));
        }

        /// <summary>
        /// Method that allow the user to create a new Error log.
        /// </summary>
        /// <param name="logMessage"></param>
        /// <returns></returns>
        public bool Error(string logMessage)
        {
            return (this.Log(LogType.error, logMessage));
        }

        /// <summary>
        /// Method that allow the user to create a new Warning log.
        /// </summary>
        /// <param name="logMessage"></param>
        /// <returns></returns>
        public bool Warning(string logMessage)
        {
            return (this.Log(LogType.warning, logMessage));
        }

        /// <summary>
        /// Default log method. Log as a Info log.
        /// </summary>
        /// <param name="logMessage"></param>
        /// <returns></returns>
        public bool Log(string logMessage)
        {
            return (this.Log(LogType.info, logMessage));
        }

        /// <summary>
        /// Method that allow the user to get logs from the main log file.
        /// </summary>
        /// <returns></returns>
        public List<string> GetLogs()
        {
            return (Reader.Instance.readFileAsStringList());
        }

        /// <summary>
        /// Method that allow the user to flush a log file.
        /// </summary>
        public void Flush()
        {
            Writer.Instance.Flush();
        }

        public bool CreatePath()
        {
            return (Writer.Instance.CreatePath(@"C:\temp\log\oui\non"));
        }

        #endregion

        #region Enum

        /// <summary>
        /// Enumeration for the type of log.
        /// </summary>
        public enum LogType
        {
            info,
            success,
            error,
            warning
        }

        #endregion
    }
}

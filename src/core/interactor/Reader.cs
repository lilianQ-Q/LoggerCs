using noxLogger.src.core.entities;
using noxLogger.src.core.exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static noxLogger.src.Logger;

namespace noxLogger.src.core
{
    /// <summary>
    /// 
    /// </summary>
    public class Reader
    {
        #region Fields

        private string path { get; set; }

        #endregion

        #region Singleton

        private static Reader _instance;
        
        /// <summary>
        /// Main Singleton of the Reader class.
        /// </summary>
        public static Reader Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Reader();
                }
                return (_instance);
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Main constructor of the Reader class.
        /// </summary>
        private Reader()
        {
            this.path = @"c:\temp\log\main.log";
        }

        #endregion

        #region Methods

        /// <summary>
        /// Method that allow the user to read a file and return it as a Log list.
        /// </summary>
        /// <returns></returns>
        public List<Log> readFileAsLogList()
        {
            List<Log> logList = new List<Log>();
            if (this.checkExistAndReadable())
            {
                using (StreamReader reader = File.OpenText(path))
                {
                    string logLine = "";
                    int count = 0;
                    while ((logLine = reader.ReadLine()) != null)
                    {
                        if(count != 0)
                        {
                            logList.Add(this.lineParser(logLine));
                        }
                        count++;
                    }
                }
            }
            else
            {
                logList.Add(new Log(LogType.error, "Cannot read file. Abort. Enable exceptions to check what's wrong."));
                //TODO : If exceptions enabled, then throw new NotAllowedException
            }
            return (logList);
        }

        /// <summary>
        /// Method that allow the user to read a file and return it as a string list.
        /// </summary>
        /// <returns></returns>
        public List<string> readFileAsStringList()
        {
            List<string> logList = new List<string>();
            if (this.checkExistAndReadable())
            {
                using (StreamReader reader = File.OpenText(path))
                {
                    string logLine = "";
                    int count = 0;
                    while ((logLine = reader.ReadLine()) != null)
                    {
                        if(count != 0)
                        {
                            logList.Add(logLine);
                        }
                        count++;
                    }
                }
            }
            else
            {
                logList.Add("Cannot read file. Abort. Enable exceptions to check what's wrong.");
                //TODO : If exceptions enabled, then throw new NotAllowedException
            }
            return (logList);
        }

        /// <summary>
        /// Method that allow the user to parse a log file line and convert it in Log object.
        /// </summary>
        /// <returns></returns>
        private Log lineParser(string logLine)
        {
            return (Log.ToLog(logLine));
        }

        /// <summary>
        /// Method that allow the user to check if a file exists and if this one is readable.
        /// </summary>
        /// <returns></returns>
        private bool checkExistAndReadable()
        {
            bool exists = false;
            bool canRead = false;

            if (File.Exists(this.path))
            {
                exists = true;
                using (var fs = File.Open(this.path, FileMode.Open))
                {
                    canRead = fs.CanRead;
                }
                if(!canRead && Logger.enabledException)
                {
                    throw new NotAllowedException();
                }
            }
            else
            {
                if (Logger.enabledException)
                {
                    throw new exceptions.FileNotFoundException(this.path);
                }
            }
            return (exists && canRead);
        }

        #endregion

    }
}

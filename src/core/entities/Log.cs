﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static noxLogger.src.Logger;

namespace noxLogger.src.core.entities
{
    public class Log
    {
        #region Fields

        public LogType logType { get; set; }
        public DateTime date { get; set; }
        public string message { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor of the Log class.
        /// </summary>
        /// <param name="message"></param>
        public Log(string message)
        {
            this.logType = LogType.info;
            this.date = DateTime.Now;
            this.message = message;
        }

        /// <summary>
        /// Auxiliary constructor of the Log class.
        /// </summary>
        /// <param name="logType"></param>
        /// <param name="message"></param>
        public Log(LogType logType, string message)
        {
            this.logType = logType;
            this.date = DateTime.Now;
            this.message = message;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Method that allow the user to create / insert a new line in the current log file from the current object data.
        /// </summary>
        /// <returns></returns>
        public bool Create()
        {
            return (Writer.Instance.WriteData(this.ToString()));
        }

        /// <summary>
        /// Method that allow the user to get a string format of the current object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ("[" + date.Day + "/" + date.Month + "/" + date.Year + "] " + date.Hour + ":" + date.Minute + ":" + date.Second + " " +this.logType.ToString().ToUpper() + " : " + this.message);
        }

        /// <summary>
        /// Method that allow the user to turn a string into a Log object.
        /// </summary>
        /// <param name="logLine"></param>
        /// <returns></returns>
        public static Log ToLog(string logLine)
        {
            return (new Log("pas encore dev"));
        }

        #endregion
    }
}

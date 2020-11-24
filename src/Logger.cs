using noxLogger.src.core;
using noxLogger.src.core.entities;
using noxLogger.src.modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace noxLogger.src
{
    /// <summary>
    /// Main class of the Logger library.
    /// </summary>
    public partial class Logger
    {
        #region Fields

        /// <summary>
        /// Used to catch exception that concern the Logger
        /// </summary>
        public static bool enabledException = true;

        /// <summary>
        /// This is the log file path of the current object.
        /// </summary>
        public string loggerFilePath { get; set; }

        /// <summary>
        /// This is a list of log writed by the object.
        /// </summary>
        public List<Log> internalLogHistory { get; private set; }

        /// <summary>
        /// This is a list of the loaded modules inside the noxLogger.
        /// </summary>
        public List<string> usedModules { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Main constructor of the Logger class. It allows you to create a new Instance of Logger.
        /// </summary>
        public Logger()
        {
            this.loggerFilePath = @"C:\temp\log\";
            this.internalLogHistory = new List<Log>();
        }

        /// <summary>
        /// Auxiliary constructor of the Logger class.
        /// </summary>
        /// <param name="loggerFilePath"></param>
        public Logger(string loggerFilePath)
        {
            this.loggerFilePath = loggerFilePath;
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
            this.internalLogHistory.Add(newLog);
            return (newLog.Create());
        }

        /// <summary>
        /// Method that allow the user to create a new Trace log.
        /// </summary>
        /// <param name="logMessage"></param>
        /// <returns></returns>
        public bool Trace(string logMessage)
        {
            return (this.Log(LogType.trace, logMessage));
        }

        /// <summary>
        /// Method that allow the user to create a new Debug log.
        /// </summary>
        /// <param name="logMessage"></param>
        /// <returns></returns>
        public bool Debug(string logMessage)
        {
            return (this.Log(LogType.debug, logMessage));
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
        /// Method that allow the user to create a new Warn log.
        /// </summary>
        /// <param name="logMessage"></param>
        /// <returns></returns>
        public bool Warn(string logMessage)
        {
            return (this.Log(LogType.warn, logMessage));
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
        /// Method that allow the user to create a new Fatal log.
        /// </summary>
        /// <param name="logMessage"></param>
        /// <returns></returns>
        public bool Fatal(string logMessage)
        {
            return (this.Log(LogType.fatal, logMessage));
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
        /// Method that allow the user to get logs from the main log file as string list.
        /// </summary>
        /// <returns></returns>
        public List<string> GetLogsAsString()
        {
            return (Reader.Instance.readFileAsStringList());
        }

        /// <summary>
        /// Method that allow the uyser to get log from the main log file as Log object List.
        /// </summary>
        /// <returns></returns>
        public List<Log> GetLogsAsLog()
        {
            //Peut être améliorer en faisait GetLogs<string>() ou GetLogs<Log>()
            return (Reader.Instance.readFileAsLogList());
        }

        /// <summary>
        /// Method that allow the user to flush a log file.
        /// </summary>
        public void Flush()
        {
            Writer.Instance.Flush();
        }

        private bool CreatePath()
        {
            return (Writer.Instance.CreatePath(@"C:\temp\log\oui\non"));
        }

        /// <summary>
        /// Method that allow the user to Save a log file under another name.
        /// </summary>
        /// <param name="newName"></param>
        public void Save(string newName)
        {
            Writer.Instance.Save(newName);
        }

        /// <summary>
        /// Method that allow the user to tell to the Logger that he is using this module. Useful in debugging cases.
        /// </summary>
        /// <param name="modulName"></param>
        /// <returns></returns>
        private bool AddModule(string modulName)
        {
            bool moduleAdded = false;
            if (!this.usedModules.Contains(modulName))
            {
                moduleAdded = true;
                this.usedModules.Add(modulName);
            }
            return (moduleAdded);
        }

        #endregion

        #region Enum

        /// <summary>
        /// Enumeration for the type of log.
        /// </summary>
        public enum LogType
        {   
            /// <summary>
            /// Type de log pour l'Entrée et sortie de méthodes.
            /// </summary>
            trace,
            /// <summary>
            /// Type de log pour l'affichage de valeur de données.
            /// </summary>
            debug,
            /// <summary>
            /// Type de log pour informer du début et de la fin de l'éxécution d'un traitement long, chargement d'un fichier de configuration etc.
            /// </summary>
            info,
            /// <summary>
            /// Type de log pour informer qu'une action a réussi.
            /// </summary>
            success,
            /// <summary>
            /// Type de log pour avertir que certaines données sont invalides.
            /// </summary>
            warn,
            /// <summary>
            /// Type de log concernant toutes les exceptions capturées qui n'empêche pas l'application de fonctionner.
            /// </summary>
            error,
            /// <summary>
            /// Type de log concernant les exceptions qui empêche l'application de fonctionner.
            /// </summary>
            fatal
        }

        #endregion
    }
}

using noxLogger.src.core.exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace noxLogger.src.core
{
    public class Writer
    {
        #region Fields
        private string path { get; set; }

        private static string defaultSaveName = "Log_save_";
        #endregion

        #region Singleton

        private static Writer _instance;

        /// <summary>
        /// Main singleton of the Writer class.
        /// </summary>
        public static Writer Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Writer();
                }
                return (_instance);
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Main constructor of the Writer class.
        /// </summary>
        private Writer()
        {
            this.path = @"c:\temp\log\main.log";
        }

        #endregion

        #region Methods

        /// <summary>
        /// Method that allow the user to write into a file.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool WriteData(string data)
        {
            //Check si le dossier existe
            this.CreatePath(this.path);
            bool isOk = false;
            if (File.Exists(this.path))
            {
                this.Write(data);
            }
            else
            {
                this.CreateAndWrite(data);
            }
            return (isOk);
        }

        /// <summary>
        /// Method that allow the user to create and write into a file.
        /// </summary>
        /// <param name="data"></param>
        private bool CreateAndWrite(string data)
        {
            bool isOk = true;
            try
            {
                using (StreamWriter sw = File.CreateText(this.path))
                {
                    sw.WriteLine(data);
                }
            }
            catch (Exception exception)
            {
                isOk = false;
                throw new NotImplementedException(exception.ToString());
            }

            return (isOk);
        }

        /// <summary>
        /// Method that allow the user to write a new data into a file.
        /// </summary>
        /// <param name="message"></param>
        private bool Write(string data)
        {
            bool isOk = true;
            try
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(data);
                }
            }
            catch
            {
                isOk = false;
            }
            return (isOk);
        }

        /// <summary>
        /// Method that allow the user to Flush the data of a log file.
        /// </summary>
        public void Flush()
        {
            this.CreateAndWrite("=== Data flushed the " + DateTime.Now.ToString() + " ===");
        }

        /// <summary>
        /// Method that allow the user to create a new Path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool CreatePath(string path)
        {
            string[] splitedPath = path.Split(@"\".ToCharArray());

            int arraySize = Path.HasExtension(path) ? (splitedPath[splitedPath.Length - 1] == "" ? splitedPath.Length - 2 : splitedPath.Length - 1) : splitedPath.Length;
            int count = 0;
            StringBuilder stringBuilder = new StringBuilder();

            while(count < arraySize)
            {
                if(splitedPath[count] != "")
                {
                    stringBuilder.Append(splitedPath[count] + @"\");
                }
                count++;
            }
            string newPath = stringBuilder.ToString();
            Directory.CreateDirectory(newPath);
            return (Directory.Exists(newPath));
        }

        /// <summary>
        /// Method that allow the user to Save a log file under another name.
        /// </summary>
        /// <param name="otherName"></param>
        public void Save(string otherName = "")
        {
            if (String.IsNullOrEmpty(otherName))
            {
                var ui = defaultSaveName + DateTime.Now.ToString("dd_M_yyyy__HH-mm") + ".log";
            }
            throw new NotImplementedException("Pas encore dev");
        }

        #endregion
    }
}

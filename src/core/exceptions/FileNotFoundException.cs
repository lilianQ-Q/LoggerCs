using System;
using System.Collections.Generic;
using System.Text;

namespace noxLogger.src.core.exceptions
{
    /// <summary>
    /// Custom exception casted when specified file does not exists.
    /// </summary>
    public class FileNotFoundException : Exception
    {
        /// <summary>
        /// Main constructor of FileDoesntExists class.
        /// </summary>
        /// <param name="path"></param>
        public FileNotFoundException(string path) : base ("Error. The file at '" + path + "' doesn't exists. Please check the path and try again.")
        {

        }
    }
}

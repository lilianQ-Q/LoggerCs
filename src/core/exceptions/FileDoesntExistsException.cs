using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.src.core.exceptions
{
    public class FileDoesntExistsException : Exception
    {
        /// <summary>
        /// Main constructor of FileDoesntExists class.
        /// </summary>
        /// <param name="path"></param>
        public FileDoesntExistsException(string path) : base ("Error. The file at '" + path + "' doesn't exists. Please check the path and try again.")
        {
        }
    }
}

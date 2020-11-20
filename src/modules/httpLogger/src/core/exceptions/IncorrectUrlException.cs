using System;
using System.Collections.Generic;
using System.Text;

namespace noxLogger.src.core.exceptions
{
    class IncorrectUrlException : Exception
    {
        #region Constructor

        /// <summary>
        /// Main constructor of IncorrectUrlException class.
        /// </summary>
        /// <param name="exceptionMessage"></param>
        public IncorrectUrlException(string exceptionMessage) : base(exceptionMessage)
        {

        }

        #endregion
    }
}

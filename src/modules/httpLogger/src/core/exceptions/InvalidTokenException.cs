using System;
using System.Collections.Generic;
using System.Text;

namespace noxLogger.src.modules.httpLogger.src.core.exceptions
{
    public class InvalidTokenException : Exception
    {
        #region Constructor

        /// <summary>
        /// Main constructor of the InvalidTokenException class.
        /// </summary>
        public InvalidTokenException() : base("This token is not valid. Contact the api master if you think that it's a mistake.")
        {

        }
        #endregion
    }
}

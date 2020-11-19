using System;
using System.Collections.Generic;
using System.Text;

namespace noxLogger.src.core.exceptions
{
    /// <summary>
    /// Throw this exception when a module is missing.
    /// </summary>
    public class MissingModuleException : Exception
    {
        #region Constructor

        /// <summary>
        /// Main constructor of MissingModuleException.
        /// </summary>
        /// <param name="modulName"></param>
        public MissingModuleException(string modulName) : base("Missing module inside projet : " + modulName + ".")
        {

        }

        #endregion
    }
}

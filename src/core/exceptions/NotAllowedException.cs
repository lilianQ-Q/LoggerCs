using System;
using System.Collections.Generic;
using System.Text;

namespace noxLogger.src.core.exceptions
{
    class NotAllowedException : Exception
    {
        #region Constructor
        
        /// <summary>
        /// Main constructor of the NotAllowedException class.
        /// </summary>
        /// <param name="errorMessage"></param>
        public NotAllowedException(string errorMessage) : base(errorMessage)
        {

        }
        
        #endregion
    }
}

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
        public NotAllowedException() : base("Error. It seems that you are not allowed to read this file. Do you have rights on it ?")
        {

        }
        
        #endregion
    }
}

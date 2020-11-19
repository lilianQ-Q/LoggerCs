using noxLogger.src.modules;
using noxLogger.src.modules.httpLogger.src;
using System;
using System.Collections.Generic;
using System.Text;

namespace noxLogger.src
{
    public partial class Logger
    {
        #region Fields
        
        /// <summary>
        /// This is the token of the application's user.
        /// </summary>
        private string token = "ezz";

        #endregion

        #region Methods

        /// <summary>
        /// Method that allow the user to send a post request.
        /// </summary>
        /// <returns></returns>
        public bool PostRequest()
        {
            HttpLogger logger = this.GetHttpLogger();
            return (true);
        }

        /// <summary>
        /// Method that allow the user to get a new HttpLogger.
        /// </summary>
        /// <returns></returns>
        private HttpLogger GetHttpLogger()
        {
            this.AddModule("HttpLogger");
            return (new HttpLogger(this.token));
        }

        #endregion
    }
}
